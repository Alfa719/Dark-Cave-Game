using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    // Buat variabel statik agar ketika pemanggilan tidak perlu membuat instasiansi objek
    // Buat public agar bisa diakses di class manapun
    public static GameplayController instance;
    private Text scoreText, nyawaText;
    private int score, nyawa;
    void Awake()
    {
        buatInstansi();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        nyawaText = GameObject.Find("LifeText").GetComponent<Text>();
    }
    private void buatInstansi()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void tambahScore()
    {
        score++;
        scoreText.text = "x" + score;
    }
    public void kurangNyawa()
    {
        nyawa--;
        if (nyawa >= 0)
        {
            nyawaText.text = "x" + nyawa;
        }
        
    }

}
