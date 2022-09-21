using TMPro;
using UnityEngine;

// Change le text d'un élément selon son nom
public class GetFName : MonoBehaviour
{
	private TMP_Text _tmpText;

	private void OnValidate()
	{
		if (!TryGetComponent(out _tmpText) || !_tmpText)
			return;

		_tmpText.text = gameObject.name;
	}
}
