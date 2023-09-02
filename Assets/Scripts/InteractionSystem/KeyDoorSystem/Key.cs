using StarterAssets;
using UnityEngine;

public class Key : MonoBehaviour, InteractableEntity
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Press 'E' to pickup key"); // TODO Change debug to on-screen tooltip system
			FirstPersonController.OnInteract = OnInteract;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log(""); // TODO Change debug to on-screen tooltip system
			FirstPersonController.OnInteract = null;
		}
	}

	public void OnInteract()
	{
		InventoryManager.Instance.AddItem(this, ItemType.SMALL_KEYS);
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		Debug.Log(""); // TODO Change debug to on-screen tooltip system
		FirstPersonController.OnInteract = null;
	}
}
