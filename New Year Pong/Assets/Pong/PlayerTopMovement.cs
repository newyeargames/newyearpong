using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopMovement : MonoBehaviour
{
    public float sideSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * Time.deltaTime * sideSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime * sideSpeed;
        }

    }
}
