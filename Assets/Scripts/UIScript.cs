using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    public Text TimeText;
    public Text ScoreText;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;
    public Text GameOverText;
    public Text FinalScoreText;
    private float currentTime;
    private float highScore = 0;
    private float score = 0;
    private bool gameStart = false;

	// Use this for initialization
	void Start () {
        // Hide game over objects
        GameOverText.gameObject.SetActive(false);
        FinalScoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameStart == true) // Wait for start button
        {
            // Increment game clock
            currentTime += Time.deltaTime;

            if (60 - currentTime <= 0) // Game over when time = 0
            {
                gameOver();
            }
            else // Update user on time left
            {
                TimeText.text = string.Format("Time Left: {0,0:N0}", 60 - currentTime);
            }
        }

	}

    // Method for player scoring, to be called by main game script
   public void playerScored() 
    {
        ScoreText.text = string.Format("Score: {0}", ++score);
    }

    // Method for when game ends
    void gameOver()
    {
        // Unhide game over objects
        gameOverPanel.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        if (score > highScore) // Check if hide score
        {
            highScore = score;
        }
        FinalScoreText.gameObject.SetActive(true);
        FinalScoreText.text = string.Format("Final Score: {0}\n High Score: {1}", score, highScore); // Display final score
    }

    // Method for play again button
    public void yesButton()
    {
        currentTime = 0;
        gameOverPanel.SetActive(false);
        score = 0;
    }

    // Method for not playing again :ISSUE, APPLICATION.QUIT NOT WORKING:
    public void noButton()
    {
        Application.Quit();
    }

    // Method for beginning the game
    public void startButton()
    {
		print ("Start");
        startGamePanel.SetActive(false);
        gameStart = true;
    }
}
