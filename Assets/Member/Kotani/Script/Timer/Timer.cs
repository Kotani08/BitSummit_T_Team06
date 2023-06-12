using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour,IPointerUpHandler
{
	private float totalTime;//経過時間計測
	private float maxTime;//制限時間の上限とカウント開始時間 のち非シリアライズ
	public bool timerStop;//タイマーが動いてるかの判断
	[SerializeField]
	private Text timerText;//時間をテキスト表示するため
	private int seconds;//テキスト表示用

	public void SetMaxTime(float Value)
	{
		maxTime = Value;
	}

	//取得用関数
	public float GetTotalTime()
	{
		return totalTime;
	}
	public float GetMaxTime()
	{
		return maxTime;
	}

	// Use this for initialization
	void Start()
	{
		timerText.text = maxTime.ToString();
		maxTime = maxTime + 1 ;
		totalTime = maxTime;
		timerStop = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (totalTime >= 1 && timerStop == false)
		{
			totalTime -= Time.deltaTime;
			seconds = (int)totalTime;
			timerText.text = seconds.ToString();
		}
		else
		{
			timerStop = true;
		}

		
		if (Input.GetKeyDown(KeyCode.B))//クールタイムリセット
		{
			totalTime = maxTime;
			timerStop = false;
		}
		if (Input.GetKeyDown(KeyCode.A))//タイマー
		{
			TimerStop();
		}
		if (Input.GetKeyDown(KeyCode.S))//タイマー
		{
			TimerRestart();
		}
	}

	public void OnPointerUp(PointerEventData pointerEventData)
    {
		TimerReset();
	}

	#region リセット、ストップ、リスタート
	public void TimerReset()
	{
		totalTime = maxTime;
		timerStop = false;
	}

	public void TimerStop()
    {
		timerStop = true;
	}

	public void TimerRestart()
	{
		timerStop = false;
	}
	#endregion
}