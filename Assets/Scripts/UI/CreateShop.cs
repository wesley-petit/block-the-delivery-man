using UnityEngine;

// S'occupe de crée et d'initialiser les différents ShopSlot
public class CreateShop : MonoBehaviour
{
	private ItemBlueprint[] _items = new ItemBlueprint[0];
	[SerializeField] private ShopSlot _prefabSlot = null;

	private void Awake()
	{
		// Charge tous les assets
		_items = Resources.LoadAll<ItemBlueprint>("ItemBlueprints");

		CreateShopScreen();
	}

	private void CreateShopScreen()
	{
		for (int i = 0; i < _items.Length; i++)
		{
			if (!_items[i])
			{
				Debug.LogError($"L'item d'index : {i} est null.");
				continue;
			}

			ShopSlot slot = Instantiate(_prefabSlot, transform);
			slot.AddBlueprint(_items[i]);
			slot.name = _items[i].name;
		}
	}
}