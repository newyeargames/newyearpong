using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public static int numberOfBalls = 0;
	private static float speed = 0;
	private static int lastState = 0;

    // Start is called before the first frame update
	public Transform duplicatingPrefab;
    public float initialSpeed = 6f;
	public float maxSpeed = 100f;
	public float acceleration = 0.25f;
	public int maxNumberOfBalls = 8;

    void Start()
    {
		if (numberOfBalls == 0) 
		{
			numberOfBalls = 1;
			speed = initialSpeed;
			lastState = 0;
		}

		float startingAngle;

		switch (lastState) 
		{
		case 1: // Top Player
			startingAngle = Mathf.PI * (UnityEngine.Random.value - 1f);
			break;
		case 2: // Right Player
			startingAngle = Mathf.PI * (UnityEngine.Random.value + 0.5f);
			break;
		case 3: // Bottom Player
			startingAngle = Mathf.PI * UnityEngine.Random.value;
			break;
		case 4: // Left Player
			startingAngle = Mathf.PI * (UnityEngine.Random.value - 0.5f);
			break;
		default: 
			startingAngle = 2 * Mathf.PI * UnityEngine.Random.value;
			break;
		}

       	// Initial Velocity
		GetComponent<Rigidbody2D>().velocity = speed * (Vector2.up * Mathf.Sin(startingAngle) + Vector2.right * Mathf.Cos(startingAngle));
	
    }

    float hitFactorTopBottom(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return 2 * (ballPos.x - racketPos.x) / racketWidth;
    }

	float hitFactorLeftRight(Vector2 ballPos, Vector2 racketPos, float racketWidth)
	{
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return 2 * (ballPos.y - racketPos.y) / racketWidth;
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
			lastState = 3;

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

			if (numberOfBalls < maxNumberOfBalls && transform.position.y > col.transform.position.y)
			{
				numberOfBalls += 1;
				Instantiate(duplicatingPrefab, transform.position, transform.rotation);
			}
		}
			
        if (col.gameObject.name == "PlayerTop")
        {
			lastState = 1;

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

			if (numberOfBalls < maxNumberOfBalls && transform.position.y < col.transform.position.y)
			{
				numberOfBalls += 1;
				Instantiate(duplicatingPrefab, transform.position, transform.rotation);
			}
        }

		if (col.gameObject.name == "PlayerLeft")
		{
			lastState = 4;

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

			if (numberOfBalls < maxNumberOfBalls && transform.position.x > col.transform.position.x)
			{
				numberOfBalls += 1;
				Instantiate(duplicatingPrefab, transform.position, transform.rotation);
			}
		}

		if (col.gameObject.name == "PlayerRight")
		{
			lastState = 2;

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

			if (numberOfBalls < maxNumberOfBalls && transform.position.y < col.transform.position.y)
			{
				numberOfBalls += 1;
				Instantiate(duplicatingPrefab, transform.position, transform.rotation);
			}
		}
    }

}
