using UnityEngine;

public class Node : MonoBehaviour
{
	[SerializeField] private Color _hoverColor = new Color();
	[SerializeField] private Color _notEnoughtMoneyColor = new Color(); // Couleur si le joueur n'a pas assez de'argent pour construire un item
	[SerializeField] private Vector3 _positionOffset = Vector3.zero;

	private Transform _thisTranform = null;
	private Renderer _rend = null;                              // Permet de changer la couleur de la node selon l'interaction du joueur
	private Color _startColor = new Color();
	private BuildManager _buildManager = null;                  // Référence pour construire un item

	public Vector3 BuildPosition => _thisTranform.position + _positionOffset;
	public Vector3 Position
	{
		get
		{
			if (!_thisTranform)
			{
				_thisTranform = transform;
			}
			return _thisTranform.position;
		}
	}

	[field:SerializeField] public GameObject Occupied { get; set; }

	// private void Awake()
	// {
	// 	_thisTranform = transform;
	// 	_rend = GetComponent<Renderer>();
	// 	_startColor = _rend.material.color;
	// }
	//
	// private void Start() => _buildManager = BuildManager.Instance;
	//
	// // Quand le joueur choisi une node pour placer un objet
	// private void OnMouseDown()
	// {
	// 	// Si le curseur est au dessus des boutons du shop et d'une node,
	// 	// le hover de la node n'est pas appliquée
	// 	if (EventSystem.current.IsPointerOverGameObject())
	// 		return;
	//
	// 	if (!_buildManager) { return; }
	//
	// 	if (!_buildManager.CanBuild)
	// 	{
	// 		Debug.Log("Null Object or No Selected Object.");
	// 		return;
	// 	}
	//
	// 	if (Occupied)
	// 	{
	// 		Debug.Log("Seat Already Taken.");
	// 		return;
	// 	}
	//
	// 	if (_buildManager.HasEnoughMoney)
	// 	{
	// 		ChangeColor(_startColor);
	// 	}
	// 	else
	// 	{
	// 		ChangeColor(_notEnoughtMoneyColor);
	// 	}
	//
	// 	_buildManager.BuildItemOn(this);
	// }
	//
	// // Hover la node
	// private void OnMouseEnter()
	// {
	// 	// Si le curseur est au dessus des boutons du shop et d'une node,
	// 	// le hover de la node n'est pas appliquée
	// 	if (EventSystem.current.IsPointerOverGameObject())
	// 		return;
	//
	// 	if (!_buildManager) { return; }
	//
	// 	// Si le joueur a choisi un item
	// 	if (_buildManager.CanBuild)
	// 		return;
	//
	// 	if (Occupied)
	// 		return;
	//
	// 	if (!_buildManager.CanBuild)
	// 	{
	// 		ChangeColor(_hoverColor);
	// 		return;
	// 	}
	//
	// 	if (_buildManager.HasEnoughMoney)
	// 	{
	// 		ChangeColor(_hoverColor);
	// 	}
	// 	else
	// 	{
	// 		ChangeColor(_notEnoughtMoneyColor);
	// 	}
	// }
	//
	// // Reset la couleur de la node
	// private void OnMouseExit() => ChangeColor(_startColor);
	//
	// public void ActiveHoverColor() => ChangeColor(_hoverColor);

	// public void ResetColor() => ChangeColor(_startColor);

	// public void ChangeColor(Color newColor) => _rend.material.color = newColor;
}