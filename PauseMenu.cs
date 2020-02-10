using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    

    public GameObject pauseMenu;

    public GameObject panelGeneral;

    public GameObject saveGame;

    public GameObject losePanel;

    public GameObject winPanel;


    

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) && !LoaderManager.gameOver)
        {

            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        panelGeneral.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void Pause()
    {
        panelGeneral.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ShowSavePanel()
    {
        pauseMenu.SetActive(false);
        saveGame.SetActive(true);
    }

    public void ShowPausePanel()
    {
        saveGame.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ShowLosePanel()
    {
        panelGeneral.SetActive(true);
        losePanel.SetActive(true);
    }

    public void ShowWinPanel()
    {
        panelGeneral.SetActive(true);
        winPanel.SetActive(true);
    }

    public void DontShowLosePanel()
    {
        panelGeneral.SetActive(false);
        losePanel.SetActive(false);
    }

    public void DontShowWinPanel()
    {
        panelGeneral.SetActive(false);
        winPanel.SetActive(false);
    }
}
