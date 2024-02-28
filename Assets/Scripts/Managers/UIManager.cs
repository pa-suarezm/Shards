using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : SingletonBehavior<UIManager>
{
	[SerializeField] private TextMeshProUGUI _tooltipText;

	public void SetTooltipText(string newTooltip)
	{
		_tooltipText.text = newTooltip;
	}

	public void SetObjectiveText()
	{
		Debug.LogWarning("Objective Text not yet implemented!");
	}
}
