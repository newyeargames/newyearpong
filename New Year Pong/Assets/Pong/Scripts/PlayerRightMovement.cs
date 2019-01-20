using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRightMovement : MonoBehaviour
{
	public float sideSpeed = 0f;

    public void PlayerMove(string direction)
    {
        if (direction[1] == 'l')
        {
            transform.position -= transform.up * Time.deltaTime * sideSpeed * (direction[2]-48);
        }
        else
        {
            transform.position += transform.up * Time.deltaTime * sideSpeed * (direction[2]-48);
        }
    }

}
