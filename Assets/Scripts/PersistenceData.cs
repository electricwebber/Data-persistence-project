using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PersistenceData : MonoBehaviour
{
    public static PersistenceData Instance;

    public string playerName;

    public int bestScore;
    public string bestScorePlayerName;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveDataType
    {
        public string playerName;
        public string bestScorePlayerName;
        public int bestScore;
    }

    public void SaveData(){
        SaveDataType data = new SaveDataType();
        data.playerName = playerName;
        data.bestScore=bestScore;
        data.bestScorePlayerName=bestScorePlayerName;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataType data = JsonUtility.FromJson<SaveDataType>(json);
            Debug.Log(JsonUtility.ToJson(data));
            playerName = data.playerName;
            bestScore = data.bestScore;
            bestScorePlayerName = data.bestScorePlayerName;
        }
    }
}
