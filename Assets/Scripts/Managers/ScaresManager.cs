using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaresManager : SingletonBehavior<ScaresManager>
{
	[SerializeField] private List<ScareEvent> _scaresEvent = new List<ScareEvent>();

	private List<bool> _scareIsUsed = new List<bool>();

	private void Start()
	{
		foreach(ScareEvent scare in _scaresEvent)
		{
			_scareIsUsed.Add(false);
		}
	}

	public void SetScareEventAsUsed(ScareEvent sEvent)
	{
		_scareIsUsed[_scaresEvent.IndexOf(sEvent)] = true;
	}

	public bool CanScareStart(ScareEvent sEvent)
	{
		return !_scareIsUsed[_scaresEvent.IndexOf(sEvent)];
	}
}
