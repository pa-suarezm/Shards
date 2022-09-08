using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    public float movementSpeed = 7f;
    public float rotationSpeed = 3f;
    public bool is3D = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("HI THERE");
        float translation = (Input.GetAxis("Vertical") * movementSpeed) * Time.deltaTime;
        float rotation = (Input.GetAxis("Horizontal") * rotationSpeed) * Time.deltaTime;

        if (is3D)
        {
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
        else
        {
            transform.Translate(rotation, translation, 0);
        }
    }

    public void CandiceReceiveDamage(float damage)
    {
        Debug.Log("Received " + damage.ToString() + " damage.");
    }
}
