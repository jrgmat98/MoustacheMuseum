using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderManager : MonoBehaviour
{
    public static LoaderManager Instance;

    public static bool gameOver = false;

    

    private bool _loadingLevel;
    private int currentLevel;
    private Image loadPanel;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            


        }
        if (transform.childCount > 0)
        {
            loadPanel = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }
        if (loadPanel)
        {
        }

    }

   
    public void LoadLevel(int buildIndex)
    {

        if (!_loadingLevel)
        {
            StartCoroutine(LoadLevelCoroutine(buildIndex));
        }
        
    }

    IEnumerator LoadLevelCoroutine(int buildIndex)
    {

        
        _loadingLevel = true;
        yield return StartCoroutine(FadeIn());
        SceneManager.LoadScene(buildIndex);
        
        yield return StartCoroutine(FadeOut());

        _loadingLevel = false;
        
        gameOver = false;
        Time.timeScale = 1;

    }

    IEnumerator FadeIn()
    {

        for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
        {

            loadPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        
        for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime)
        {
            
            loadPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    public void RestartLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (!_loadingLevel)
        {
            StartCoroutine(LoadLevelCoroutine(buildIndex));
            SceneManager.LoadScene(buildIndex);
        }

        
    }

    public void LoadGame(int partida)
    {
        SceneManager.LoadScene(SaveSystem.LoadGame(partida).level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveGame(int partida)
    {
        SaveSystem.SaveGame(partida);
        
    }

    

    IEnumerator WaitVictoria()
    {
        yield return new WaitForSeconds(5f);
    }

    public void SimpleLoad(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
