using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMP_Text player1ScoreText; // Text field to display Player 1's score
    public TMP_Text player2ScoreText; // Text field to display Player 2's score

    void Start()
    {
        // Fetch the scores from PlayerPrefs
        int player1Score = PlayerPrefs.GetInt("Player1Score", 0);
        int player2Score = PlayerPrefs.GetInt("Player2Score", 0);

        // Update the UI text to display the scores
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();

        PlayerPrefs.DeleteKey("Player1Score");
        PlayerPrefs.DeleteKey("Player2Score");
    }
}
