using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

// Affiche l'argent disponible
public class MoneyUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _moneyText = null;
	[SerializeField] private PlayerState playerState = null;
    
	private void Start() => UpdateUI();


    private void OnEnable() => playerState.OnMoneyChange += UpdateUI;
	private void OnDisable() => playerState.OnMoneyChange -= UpdateUI;

	private void UpdateUI() => _moneyText.SetText($"${playerState.Money}");
}
