using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Ball")
        {
			Destroy(other.gameObject);
            Ball.numberOfBalls -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
