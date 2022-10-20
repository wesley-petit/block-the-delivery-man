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
    
    public static Vector3 DirFromAngle(float angleInDegrees, Transform ownerTransform)
    {
        angleInDegrees += ownerTransform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
