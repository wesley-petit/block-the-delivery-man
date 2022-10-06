using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void LoadScene(int index)
    {
        Helpers.LoadScene(index);
    }
    private void OnApplicationQuit() // A modifier plus tard
    {
        StopAllCoroutines();
    }
    public void Quit()
    {
        Helpers.QuitGame();
    }
}
