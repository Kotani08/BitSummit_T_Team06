using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//using PlayerSaveData;

namespace PlayerSaveData
{
    [CreateAssetMenu(menuName = "MyScriptable/PlayerData")]

    [System.Serializable]
    public class PlayerData : ScriptableObject
    {
        public int playerOxygen;
        public int playerHealth;
        public int[] SetSkillId = new int[3];
        public bool Toggle = false;

    }

    public class SaveDataEditor
    {
        [SerializeField]
        private PlayerData _save;
        string json;

        private void OnApplicationQuit()
        {
            SaveGameData();
            Debug.Log(" OnApplicationQuit");
        }
        private void OnDisable()
        {
            SaveGameData();
            Debug.Log(" OnDisable");
        }


        public void SaveGameData()
        {
            //string getFilePath() { return Application.persistentDataPath + "/PaintData" + ".json"; }
            string getFilePath = Directory.GetCurrentDirectory();
            getFilePath += ("/" + "save.json");

            json = JsonUtility.ToJson(_save);
            using (var sw = new StreamWriter(getFilePath, false))
            {
                try
                {
                    sw.Write(json);
                    //Debug.Log(json);
                }
                catch (Exception e) //���s�������̏���
                {
                    Debug.Log(e);
                }
            }
        }

        public void LoadGameData()
        {
            JsonUtility.FromJsonOverwrite(json, _save);
        }
    }
}