using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;
	public static int topPlayerScore = 0;
	public static int bottomPlayerScore = 0;
	public static int leftPlayerScore = 0;
	public static int rightPlayerScore = 0;
	public static bool isGameOver = false;

	public Text topPlayerScoreText;
	public Text bottomPlayerScoreText;
	public Text leftPlayerScoreText;
	public Text rightPlayerScoreText;

    // Start is called before the first frame update
    void Awake()
    {
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void incrementTopPlayerScore()
	{
		if (!isGameOver)
		{
			topPlayerScore += 1;
			topPlayerScoreText.text = ("" + topPlayerScore);
		}
	}
		
	public void incrementBottomPlayerScore()
	{
		if (!isGameOver)
		{
			bottomPlayerScore += 1;
			bottomPlayerScoreText.text =("" + bottomPlayerScore);
		}
	}

	public void incrementLeftPlayerScore()
	{
		if (!isGameOver)
		{
			leftPlayerScore += 1;
			leftPlayerScoreText.text = ("" + leftPlayerScore);
		}
	}

	public void incrementRightPlayerScore()
	{
		if (!isGameOver)
		{
			rightPlayerScore += 1;
			rightPlayerScoreText.text = ("" + rightPlayerScore);
		}
	}

	public void gameOver()
	{
		isGameOver = true;

		// Add delay here;

		isGameOver = false;
		topPlayerScore = 0;
		bottomPlayerScore = 0;
		leftPlayerScore = 0;
		rightPlayerScore = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
