using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public  string PlayerName;
    public TMP_InputField NameInputField;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    

    public void StartGame()
    {

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
        public int HighScore;
    }
}
