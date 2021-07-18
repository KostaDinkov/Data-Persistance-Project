using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public  string PlayerName;
    public string BestPlayerName;
    public int HighestScore;
    public TMP_InputField NameInputField;
    private string saveFilePath;
    private void Awake()
    {
        this.saveFilePath = Application.persistentDataPath + "/savefile.json";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    

    public void StartGame()
    {
        this.LoadHighScore();
        this.PlayerName = this.NameInputField.text;
        
        if (string.IsNullOrEmpty(this.PlayerName))
        {
            this.NameInputField.placeholder.GetComponent<TextMeshProUGUI>().text = "You must provide name";
            
            return;
        }
        else if (this.PlayerName.Length > 30)
        {
            this.NameInputField.text = "";
            this.NameInputField.placeholder.GetComponent<TextMeshProUGUI>().text = "Name too long (max 15)";
            return;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }


    class SaveData
    {
        public string BestPlayerName;
        public int HighestScore;
    }

    public void LoadHighScore()
    {
        
        if (File.Exists(this.saveFilePath))
        {
            var json = File.ReadAllText(this.saveFilePath);
            SaveData highScores = JsonUtility.FromJson<SaveData>(json);
            this.BestPlayerName = highScores.BestPlayerName;
            this.HighestScore = highScores.HighestScore;
        }
    }

    public void SaveHighScore()
    {
        
        var highScore = new SaveData();
        highScore.BestPlayerName = this.PlayerName;
        highScore.HighestScore = this.HighestScore;
        var json = JsonUtility.ToJson(highScore);
        File.WriteAllText(this.saveFilePath, json);

    }
}
