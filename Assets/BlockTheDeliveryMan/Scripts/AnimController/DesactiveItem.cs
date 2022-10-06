using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveItem : MonoBehaviour
{
    // Ce Script est à mettre sur l'élément parent à desactivé comportant l'animator
    // Il doit se faire appeler avec une animation

    private void OnEnable()
    {
        this.GetComponent<Animator>().StopPlayback();
        this.GetComponent<Animator>().Update(0f);
        this.GetComponent<Animator>().enabled = false;
        this.gameObject.SetActive(false);
    }
}
