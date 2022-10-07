using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPanelOption : MonoBehaviour
{
    [SerializeField] private GameObject ButtonOpenOption;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Vector3 open;
    [SerializeField] private Vector3 close;
    [SerializeField] private float duration = 2;
    private bool callClose = false;
    private bool callOpen = false;
    public void OpenPanel()
    {
        if (!callClose && !callOpen)
        {
            callOpen = true;
            Panel.SetActive(true);
            //Panel.GetComponent<RectTransform>().rect.;
            LeanTween.move(Panel.GetComponent<RectTransform>(), Panel.GetComponent<RectTransform>().anchoredPosition3D + open, duration).setEase(LeanTweenType.easeOutQuad).setDelay(0.1f); // D�placement
            StartCoroutine(OpenPanel_IEnum());
        }
       
    }
    private IEnumerator OpenPanel_IEnum()
    {
 
        yield return new WaitForSeconds(duration);
        callOpen = false;
        StopCoroutine(OpenPanel_IEnum());
    }


    public void ClosePanel()
    {
        if (!callOpen & !callClose)
        {
            callClose = true;
            LeanTween.move(Panel.GetComponent<RectTransform>(), Panel.GetComponent<RectTransform>().anchoredPosition3D + close, duration).setEase(LeanTweenType.easeOutQuad).setDelay(0); // D�placement
            StartCoroutine(ClosePanel_IEnum());

        }
         
    }
    private IEnumerator ClosePanel_IEnum()
    {
        //V�rifie que le panel est bien ferm� avant de d�sactiver l'�l�ment

        yield return new WaitForSeconds(duration);
        Panel.SetActive(false);
        callClose = false;

        StopCoroutine(ClosePanel_IEnum());

    }

}
