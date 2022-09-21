﻿using UnityEngine;

// Contient les informations classiques d'un item
[System.Serializable]
[CreateAssetMenu(fileName = "New Item Blueprint", menuName = "Item Blueprint")]
public class ItemBlueprint : ScriptableObject
{
	[SerializeField] private GameObject _prefab = null;
	[SerializeField] private int _cost = 0;
	[SerializeField] private Sprite _sprite = null;

	public GameObject Prefab => _prefab;
	public int Cost => _cost;
	public Sprite Sprite => _sprite;
}
