using System;
using TMPro;
using UnityEngine;

public class ChangePathAlgorithm : MonoBehaviour
{
    [SerializeField] private IntGameEvent onSwitchAlgorithm;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable() => onSwitchAlgorithm.RegisterListener(DisplayAlgorithmName);

    private void OnDisable() => onSwitchAlgorithm.UnregisterListener(DisplayAlgorithmName);

    private void DisplayAlgorithmName(int val)
    {
        if (val == 0)
        {
            _text.SetText("A*");
        }
        else
        {
            _text.SetText("Dijkstra");
        }
    }
}
