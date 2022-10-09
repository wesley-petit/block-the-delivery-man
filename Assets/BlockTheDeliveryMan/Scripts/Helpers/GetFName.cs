using TMPro;
using UnityEngine;

/// <summary>
/// Copy game object name to the text mesh pro it contains
/// </summary>
public class GetFName : MonoBehaviour
{
	private TMP_Text _tmpText;

	private void OnValidate()
	{
		if (!TryGetComponent(out _tmpText) || !_tmpText)
			return;

		_tmpText.SetText(gameObject.name);
	}
}
