using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void SaveGame(int partida)
    {
        SaveSystem.SaveGame(partida);
    }


    public void cargarScena(int scene)
    {

        SceneManager.LoadScene(scene);
    }

    public void LoadGame(int partida)
    {
        SceneManager.LoadScene(SaveSystem.LoadGame(partida).level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
