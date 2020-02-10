using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public PauseMenu pauseMenu;

    public GameObject[] panels;

    public void Lose()
    {
        LoaderManager.gameOver = true;
        Time.timeScale = 0;
        pauseMenu.ShowLosePanel();
    }

    public void Win()
    {
        LoaderManager.gameOver = true;
        Time.timeScale = 0;
        pauseMenu.ShowWinPanel();
    }


    public void ActivarPanel(int panelActivar)
    {
        panels[panelActivar].SetActive(true);
    }

    public void DesactivarPanel (int panelDesactivar)
    {

        panels[panelDesactivar].SetActive(false);
    }
}
