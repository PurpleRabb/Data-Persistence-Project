using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;
    private string inputName="";
    BestScoreRecord bestRecord = null;

    [System.Serializable]
    class BestScoreRecord
    {
        public string name;
        public int score;
    }

    public void Awake()
    {
        if (Instance != null)
        {
            bestRecord = null;
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            bestRecord = new BestScoreRecord();
            LoadData();
            Debug.Log("DontDestroyOnLoad");
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetName(string name)
    {
        inputName = name;
    }

    public string GetName()
    {
        return bestRecord.name;
    }

    public int GetBestScore()
    {
        return bestRecord.score;
    }

    public void SaveData(int score)
    {
        if (bestRecord.score < score)
        {
            bestRecord.name = inputName;
            bestRecord.score = score;
            string json = JsonUtility.ToJson(bestRecord);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            Debug.Log(Application.persistentDataPath + "/savefile.json");
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestRecord = JsonUtility.FromJson<BestScoreRecord>(json);
            Debug.Log(bestRecord.name+"#"+bestRecord.score);
        }
        else
        {
            bestRecord.name = "";
            bestRecord.score = 0;
            Debug.Log(bestRecord.name + "@" + bestRecord.score);
        }
    }
}
