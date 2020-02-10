using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    public PauseMenu pause;
    public void LoadScene(int buildIndex)
    {
        LoaderManager.Instance.LoadLevel(buildIndex);
    }

    public void LoadSimple(int buildIndex)
    {
        LoaderManager.Instance.SimpleLoad(buildIndex);
        LoaderManager.gameOver = false;
    }

    public void LoadGame(int game)
    {
        LoaderManager.Instance.LoadGame(game);
    }

    public void SaveGame(int game)
    {
        LoaderManager.Instance.SaveGame(game);
        pause.ShowPausePanel();

    }

    public void Restart()
    {
        LoaderManager.Instance.RestartLevel();
        LoaderManager.gameOver = false;
    }

    public void QuitGame()
    {
        LoaderManager.Instance.QuitGame();
    }
    
    public void Enlace()
    {
        Application.OpenURL("Link to the making of");
    }
}
