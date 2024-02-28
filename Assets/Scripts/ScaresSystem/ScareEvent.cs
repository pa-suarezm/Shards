using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareEvent : MonoBehaviour
{
	public Transform startingPoint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			ScareStart();
		}
	}

	protected virtual void ScareStart()
	{
		if (!ScaresManager.Instance.CanScareStart(this))
			return;

		ScaresManager.Instance.SetScareEventAsUsed(this);
	}
}
