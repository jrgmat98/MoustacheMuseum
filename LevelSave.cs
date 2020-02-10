using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class LevelSave
{
    public int level;

    public LevelSave()
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }
}
