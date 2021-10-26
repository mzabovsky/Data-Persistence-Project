using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.LoadBestScore();
        bestScoreText.text = "Best score: " + ScoreManager.Instance.highScore + " (" + ScoreManager.Instance.bestPlayerName + ")";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //ScoreManager.Instance.playerName = playerNameText.GetParsedText();
        ScoreManager.Instance.playerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
