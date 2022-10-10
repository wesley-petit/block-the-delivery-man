using UnityEngine;

/// <summary>
/// List of generic function and utilities which doesn't belong to a specific class
/// </summary>
public static class Helpers 
{
    #region UI & Options
    public static LoadingProgress LoadingProgress;
    public static void LoadScene(int index)
    {
        LoadingProgress.LoadScene(index);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    #endregion

}
