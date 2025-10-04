using UnityEngine;

/// <summary>
/// Simple MonoBehaviour to show build version in a UI label.
/// </summary>
public class UI_BuildVersionLabel : MonoBehaviour
{
	[SerializeField]
	TMPro.TMP_Text buildVersionLabel;

	void Start()
	{
		buildVersionLabel.text = $"v{Application.version}";
	}
}
