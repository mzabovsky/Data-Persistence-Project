using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int highScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveScore
    {
        public string playerName;
        public int score;
    }

    public void SaveBestScore()
    {
        SaveScore bestScore = new SaveScore();
        bestScore.playerName = bestPlayerName;
        bestScore.score = highScore;

        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScore bestScore = JsonUtility.FromJson<SaveScore>(json);

            bestPlayerName = bestScore.playerName;
            highScore = bestScore.score;
        } else
        {
            bestPlayerName = "";
            highScore = 0;
        }
    }

}
