using UnityEngine;

public class DesactiveItem : MonoBehaviour
{
    // Ce Script est � mettre sur l'�l�ment parent � desactiv� comportant l'animator
    // Il doit se faire appeler avec une animation

    private void OnEnable()
    {
        GetComponent<Animator>().StopPlayback();
        GetComponent<Animator>().Update(0f);
        GetComponent<Animator>().enabled = false;
        gameObject.SetActive(false);
    }
}
