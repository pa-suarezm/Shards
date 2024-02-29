using StarterAssets;
using UnityEngine;

public class Key : MonoBehaviour, InteractableEntity
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			UIManager.Instance.SetTooltipText("Press 'E' to pickup key");
			FirstPersonController.OnInteract = OnInteract;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			UIManager.Instance.SetTooltipText("");
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
		if (UIManager.Instance != null)
		{
			UIManager.Instance.SetTooltipText("");
		}
		FirstPersonController.OnInteract = null;
	}
}
