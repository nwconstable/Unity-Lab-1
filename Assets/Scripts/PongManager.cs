using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PongManager : MonoBehaviour
{
    [SerializeField] private PongRock ball;
    [SerializeField] private PongGoal player1Goal;
    [SerializeField] private PongGoal player2Goal;
    [SerializeField] private TMP_Text player1Score;
    [SerializeField] private TMP_Text player2Score;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private int maxScore = 3;
    [SerializeField] private PongPaddle player1;
    [SerializeField] private PongPaddle player2;

    private int player1ScoreValue = 0;
    private int player2ScoreValue = 0;

    private void Awake() {
        player1Goal.onScore += Player1Scored;
        player2Goal.onScore += Player2Scored;
        ball.Restart();
    }

    private void Player1Scored() {
        player1ScoreValue++;
        player1Score.text = player1ScoreValue.ToString();
        if (CheckForWinner()) {
            StartCoroutine(Win());
        } else {
            ball.Restart();
        }
    }

    private void Player2Scored() {
        player2ScoreValue++;
        player2Score.text = player2ScoreValue.ToString();
        if (CheckForWinner()) {
            StartCoroutine(Win());
        } else {
            ball.Restart();
        }
    }

    private void Update() {
        player1Score.text = player1ScoreValue.ToString();
        player2Score.text = player2ScoreValue.ToString();
        if (ball.ballTransform.position.y > 7.39f || ball.ballTransform.position.y < -5.35) {
            ball.Restart();
        }
    }

    private bool CheckForWinner() {
        if (player1ScoreValue >= maxScore || player2ScoreValue >= maxScore){
            return true;
        } else {
            return false;
        }
    }

    IEnumerator Win() {
        if (player1ScoreValue >= maxScore) {
                winnerText.text = "Player 1 Wins!";
            } else if (player2ScoreValue >= maxScore) {
                winnerText.text = "Player 2 Wins!";
            }
            ball.rb.velocity = Vector2.zero;
            player1.speed = 0;
            player2.speed = 0;
            winnerText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
