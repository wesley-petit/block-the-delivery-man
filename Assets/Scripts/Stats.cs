using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats")]
public class Stats : ScriptableObject
{
	[SerializeField] private int _money = 400;
	[SerializeField] private int _startMoney = 400;

	public Action OnMoneyChange;								// Variable nécessaire à l'UI afin de ne pas changer un texte toutes les frames

	public int Money
	{
		get => _money;
		private set
		{
			_money = value;
			if (_money < 0)
			{
				_money = 0;
			}
			OnMoneyChange?.Invoke();
		}
	}

	// Reset l'argent afficher sur l'éditeur
	private void OnDisable() => _money = _startMoney;

	public void Work(int salary) => Money += salary;

	public void Buy(int cost) => Money -= cost;
}
