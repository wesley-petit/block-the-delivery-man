using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveItem : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<GameObject>().SetActive(false);
    }
}
