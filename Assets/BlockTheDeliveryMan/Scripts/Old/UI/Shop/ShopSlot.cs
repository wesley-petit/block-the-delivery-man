using TMPro;
using UnityEngine;
using UnityEngine.UI;

// S'occupe des liens des boutons de shop
public class ShopSlot : MonoBehaviour
{
	[SerializeField] private Image _image = null;				// Pour changer de sprite d'item
	[SerializeField] private TMP_Text _costText = null;         // Pour actualiser l'ui de coût

	private ItemBlueprint _itemBlueprint = null;

	public void AddBlueprint(ItemBlueprint newBlueprint)
	{
		_itemBlueprint = newBlueprint;
		_image.sprite = newBlueprint.Sprite;
		_costText.SetText($"${newBlueprint.Cost}");
	}
	
	public void SelectItem() => BuildManager.Instance.SelectItemToBuild(_itemBlueprint);
}
