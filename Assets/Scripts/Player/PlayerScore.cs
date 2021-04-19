using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public bool masihHidup, playerMatiRestartGame; 
    private Text scoreText, nyawaText, gameOverText;
    public GameObject player, gameOver;
    private int score, nyawa;

    // Mengirim data untuk memberitahu player masih hidup
    void Awake()
    {
        masihHidup = true;     
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        nyawaText = GameObject.Find("LifeText").GetComponent<Text>();
        gameOverText = GameObject.Find("GameOverTitle").GetComponent<Text>();
        gameOver.SetActive(false);
        nyawa = 6;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Diamond Biru" || other.tag == "Diamond Ungu")
        {
            if (other.tag == "Diamond Biru")
            {
                tambahScore();
                scoreText.text = "x" + score;
            }else if (other.tag == "Diamond Ungu")
            {
                score += 5;
                scoreText.text = "x" + score;
            }
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Skeleton")
        {
            if (masihHidup)
            {
                // Matikan Posisi Kamera
                // masihHidup = false;
                kurangNyawa();
                // transform.position = new Vector3(0, 1000, 0);
            }else
            {
                gameOver.SetActive(true);
                gameOverText.text = "Game Over, You Lose!";
            }    
        }
        if (other.tag == "Pintu")
        {
            masihHidup = false;
            transform.position = new Vector3(0, 1000, 0);
            Time.timeScale = 0;
            gameOver.SetActive(true);
            gameOverText.color = Color.green;
            gameOverText.text = "Game Finished, You Win!";
        }
    }
    public void tambahScore()
    {
        score++;
        scoreText.text = "x" + score;
    }
    public void kurangNyawa()
    {
        if (nyawa >= 0)
        {
            // Vector3 tempX = player.transform.position.x;
            // Vector3 tempY = player.transform.position.y;
            transform.position = new Vector3(-4.08f, -2f ,0);
            nyawa--;
            nyawaText.text = "x" + nyawa/2;
        }else
        {
            masihHidup = false;
            Time.timeScale = 0;
            // transform.position = new Vector3(0, 1000, 0);
            Destroy(gameObject, 5);
        }
    }
    public void MainMenuBtn()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
