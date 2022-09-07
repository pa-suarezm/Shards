using UnityEngine;

namespace OccaSoftware.GhostShader.Demo
{
	public class RotateCamera : MonoBehaviour
	{
		[SerializeField] Transform target;

		void Update()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			if (Input.GetMouseButton(0))
            {
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;

				transform.LookAt(target.position);
				transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * 90f);

				float yInput = -Input.GetAxis("Mouse Y");
				if (transform.position.y < 0.3f)
					yInput = Mathf.Max(0f, yInput);

				transform.RotateAround(target.position, transform.right, yInput * Time.deltaTime * 90f);
			}
		}
	}

}