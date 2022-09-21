using TMPro;
using UnityEngine;

// Affiche l'argent disponible
public class MoneyUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _moneyText = null;
	[SerializeField] private Stats _playerStats = null;
    
	private void Start() => UpdateUI();


    private void OnEnable() => _playerStats.OnMoneyChange += UpdateUI;
	private void OnDisable() => _playerStats.OnMoneyChange -= UpdateUI;

	private void UpdateUI() => _moneyText.SetText($"${_playerStats.Money}");
}
