using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPanelOption : MonoBehaviour
{
    [SerializeField] private GameObject ButtonOpenOption;
    [SerializeField] private GameObject Panel;
    public void OpenPanel()
    {
        Panel.SetActive(true);
        Panel.GetComponent<Animator>().enabled = true;
        Panel.GetComponent<Animator>().SetBool("Open",true);
    }
    public void ClosePanel()
    {
        Panel.GetComponent<Animator>().SetBool("Open", false);
        // l'animator se charge de désactiver le panel
    }
}
