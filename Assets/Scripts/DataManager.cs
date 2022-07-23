using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Data
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        public string playerName;
        public int highScore;
        public string highScoreOwner;

        // Start is called before the first frame update
        private void Awake()
        {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        [System.Serializable]
        class SaveData
        {
            public int hisgScore;
            public string highScoreOwner;
        }

        public void PersistData()
        {
            SaveData data = new SaveData();
            data.hisgScore = highScore;
            data.highScoreOwner = highScoreOwner;
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
        }

        public void loadData()
        {
            string path = Application.persistentDataPath + "/saveData.json";
            if (File.Exists(path)) {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                highScore = data.hisgScore;
                highScoreOwner = data.highScoreOwner;
            }
        }
    }
}