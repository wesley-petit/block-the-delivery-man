using UnityEngine;

// S'occupe de l'item choisi par le joueur et de le construire sur les nodes
public class BuildManager : MonoBehaviour
{
	// public static BuildManager Instance { get; private set; }
	//
	// [SerializeField] private Stats _playerStats = null;
	//
	// private ItemBlueprint _itemToBuild = null;
	//
	// public bool CanBuild => _itemToBuild != null;                       // Si le joueur a choisi un item
	// public bool HasEnoughMoney => _itemToBuild.Cost <= _playerStats.Money;  // Possède assez d'argent pour construire l'item
	//
	// // Initialise le singleton et Vérifie PlayerStats
	// private void Awake()
	// {
	// 	if (Instance != null)
	// 	{
	// 		Debug.LogError($"Deux Instance d'un singleton de type {typeof(BuildManager)}.");
	// 		Destroy(this);
	// 	}
	// 	Instance = this;
	//
	// 	if (!_playerStats)
	// 	{
	// 		Debug.LogError("Player Stats n'est pas définie.");
	// 		return;
	// 	}
	// }
	//
	// // Définie l'item choisi par le joueur
	// public void SelectItemToBuild(ItemBlueprint itemSelected) => _itemToBuild = itemSelected;
	//
	// // Construit l'item sur la node correspondante
	// public void BuildItemOn(Node node)
	// {
	// 	// Pas assez d'argent
	// 	if (_playerStats.Money < _itemToBuild.Cost)
	// 	{
	// 		Debug.Log($"Not enough money to build : {_itemToBuild.Prefab.name}");
	// 		return;
	// 	}
	//
	// 	_playerStats.Buy(_itemToBuild.Cost);
	//
	// 	GameObject item = Instantiate(_itemToBuild.Prefab, node.BuildPosition, node.transform.rotation, transform);
	// 	node.Occupied = item;
	//
	// 	// In case of Custom Build
	// 	IBuilder itemBuilder = item.GetComponent<IBuilder>();
	// 	if (itemBuilder != null)
	// 	{
	// 		itemBuilder.Build(node);
	// 	}
	// }
}