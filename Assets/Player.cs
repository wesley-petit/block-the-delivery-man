using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private IntGameEvent onSwitchPathAlgorithm;
    [SerializeField] private PathController _pathController;

    private int currentAlgorithm = 0;
    
    private void Awake()
    {
        _pathController = FindObjectOfType<PathController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("F1");
            _pathController.TogglePathVisibility();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("F2");
            currentAlgorithm++;
            currentAlgorithm %= 2;
            onSwitchPathAlgorithm.Raise(currentAlgorithm);
        }
    }
}
