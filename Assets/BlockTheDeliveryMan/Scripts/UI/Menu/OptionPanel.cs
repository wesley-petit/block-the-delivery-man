using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    public void BackMenu(int index)
    {
        Helpers.LoadScene(index); // return to menu
    }
}
