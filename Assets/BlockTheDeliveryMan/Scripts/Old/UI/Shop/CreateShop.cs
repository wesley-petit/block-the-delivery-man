using System;
using UnityEngine;

/// <summary>
/// Create a shop with all items available
/// </summary>
public class CreateShop : MonoBehaviour
{
	[SerializeField] private ShopSlot _prefabSlot;

	private ItemBlueprint[] _items = Array.Empty<ItemBlueprint>();

	private void Awake()
	{
		_items = Resources.LoadAll<ItemBlueprint>("ItemBlueprints");
		CreateShopScreen();
	}

	/// <summary>
	/// Create and initialize all shop slot
	/// </summary>
	private void CreateShopScreen()
	{
		for (int i = 0; i < _items.Length; i++)
		{
			ShopSlot slot = Instantiate(_prefabSlot, transform);
			slot.AddBlueprint(_items[i]);
			slot.name = _items[i].name;
		}
	}
}