using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftMovement : MonoBehaviour
{
	public float sideSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= transform.up * Time.deltaTime * sideSpeed;
		}

		if (Input.GetKey(KeyCode.W))
		{
			transform.position += transform.up * Time.deltaTime * sideSpeed;
		}
    }
}
