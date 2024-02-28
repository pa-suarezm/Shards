using StarterAssets;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, InteractableEntity
{
	[SerializeField]
	private float openAngle = 86.0f;

	[SerializeField]
	private float openingDuration = 0.75f;

	private bool isUnlocked = false;
	private bool isOpen = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (isUnlocked)
			{
				var msg = isOpen ? "Press 'E' to close door" : "Press 'E' to open door";
				UIManager.Instance.SetTooltipText(msg);
				FirstPersonController.OnInteract = OnInteract;
			}
			else
			{
				if (InventoryManager.Instance.HasSmallKey())
				{
					UIManager.Instance.SetTooltipText("Press 'E' to open door");
					FirstPersonController.OnInteract = OnInteract;
				}
				else
				{
					UIManager.Instance.SetTooltipText("You need a key open this door");
				}
			}
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
		if (isUnlocked)
		{
			ToggleDoorState();
		}
		else
		{
			InventoryManager.Instance.UseSmallKey();
			isUnlocked = true;
			ToggleDoorState();
		}
	}

	private void ToggleDoorState()
	{
		isOpen = !isOpen;

		Vector3 currentRotation = transform.rotation.eulerAngles;
		if (isOpen)
		{
			currentRotation.y += openAngle;
		}
		else
		{
			currentRotation.y -= openAngle;
		}
		transform.DORotate(currentRotation, openingDuration);

		var msg = isOpen ? "Press 'E' to close door" : "Press 'E' to open door";
		UIManager.Instance.SetTooltipText(msg);
		FirstPersonController.OnInteract = ToggleDoorState;
	}
}
