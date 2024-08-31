using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsMenuPanel;

    public static bool GameIsPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
