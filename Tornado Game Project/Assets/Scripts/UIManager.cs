using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public int finalScor;
    public TextMeshProUGUI SkorUI;
    public GameObject gameOver;
    static public int skor;
    public AudioSource audioSource;

    private void Awake(){
        skor = 0;
        finalScor = 0;
        Time.timeScale = 1;
        gameOver.SetActive(false);
        audioSource.Play();
    }

    private void Update()
    {
        Debug.Log(finalScor);
        SkorUI.text = "SKOR: " + skor.ToString();
        
        if(skor == finalScor)
            GameOver();
    }

    private void GameOver(){
        gameOver.SetActive(true);
        Time.timeScale = 0;
        audioSource.Stop();

        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }
}
