using UnityEngine;

public class Menu : MonoBehaviour
{
    public void LoadScene(int index)
    {
        Helpers.LoadScene(index);
    }
    
    //TODO A modifier plus tard
    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
    
    public void Quit()
    {
        Helpers.QuitGame();
    }
}
