using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialSpeed = 5f;
	public float maxSpeed = 5f;
	public float acceleration = 5f;
	private float speed;

    void Start()
    {
		speed = initialSpeed;
		float startingAngle = 2 * Mathf.PI * UnityEngine.Random.value;
        // Initial Velocity
		GetComponent<Rigidbody2D>().velocity = initialSpeed * (Vector2.down * Mathf.Sin(startingAngle) + Vector2.right * Mathf.Cos(startingAngle));
    }

    float hitFactorTopBottom(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.x - racketPos.x) / racketWidth;
    }

	float hitFactorLeftRight(Vector2 ballPos, Vector2 racketPos, float racketWidth)
	{
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos.y - racketPos.y) / racketWidth;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        if (col.gameObject.name == "PlayerBottom")
        {
			// Increase speed
			if (speed < maxSpeed)
			{
				speed += acceleration;
			}

            // Calculate hit Factor
            float x = hitFactorTopBottom(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
			
        if (col.gameObject.name == "PlayerTop")
        {
			// Increase speed
			if (speed < maxSpeed)
			{
				speed += acceleration;
			}

            // Calculate hit Factor
            float x = hitFactorTopBottom(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, -1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

		if (col.gameObject.name == "PlayerLeft")
		{
			// Increase speed
			if (speed < maxSpeed)
			{
				speed += acceleration;
			}

			// Calculate hit Factor
			float y = hitFactorLeftRight(transform.position,
				col.transform.position,
				col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(1, y).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}

		if (col.gameObject.name == "PlayerRight")
		{
			// Increase speed
			if (speed < maxSpeed)
			{
				speed += acceleration;
			}

			// Calculate hit Factor
			float y = hitFactorLeftRight(transform.position,
				col.transform.position,
				col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
    }

}
