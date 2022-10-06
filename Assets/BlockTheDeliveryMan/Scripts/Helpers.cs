using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Helpers 
{
    #region UI & Options
    public static LoadingProgress loadingProgress;
    public static void LoadScene(int index)
    {
        loadingProgress.LoadScene(index);
    }
    public static void QuitGame()
    {
        
        Application.Quit();
    }

    #endregion
}
