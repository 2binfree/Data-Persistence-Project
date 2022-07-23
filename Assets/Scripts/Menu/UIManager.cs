using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject inputName;
    public Text bestScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Data.DataManager.Instance.loadData();
        string highScoreOwner = Data.DataManager.Instance.highScoreOwner;
        int highScore = Data.DataManager.Instance.highScore;
        bestScoreDisplay.text = $"Best Score : {highScoreOwner} : {highScore}";        
        inputName.GetComponent<TMP_InputField>().text = highScoreOwner;
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GetPlayerName()
    {
        Data.DataManager.Instance.playerName = inputName.GetComponent<TMP_InputField>().text;
    }

}
