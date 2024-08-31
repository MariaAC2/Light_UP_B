using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject optionsMenuPanel;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
