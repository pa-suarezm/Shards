using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareEvent : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			ScareStart();
		}
	}

	public virtual void ScareStart()
	{
		if (!ScaresManager.Instance.CanScareStart(this))
			return;

		ScaresManager.Instance.SetScareEventAsUsed(this);
	}

	public virtual void OnScareEnd()
	{
		gameObject.SetActive(false);
	}
}
