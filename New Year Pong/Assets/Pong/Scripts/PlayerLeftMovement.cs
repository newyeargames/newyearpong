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

    public void PlayerMove(char direction)
    {
        if (direction == 'l')
        {
            transform.position -= transform.up * Time.deltaTime * sideSpeed;
        }
        else
        {
            transform.position -= transform.up * Time.deltaTime * sideSpeed;
        }
    }
}
