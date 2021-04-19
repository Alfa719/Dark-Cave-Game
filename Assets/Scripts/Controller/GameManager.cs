using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Buat variabel statik agar ketika pemanggilan tidak perlu membuat instasiansi objek
    public static GameManager instance;
    public int score, nyawa;
    public bool playerMatiRestartGame;

    void Awake()
    {
        buatSatuCopyGameManager();
    }
    public void buatSatuCopyGameManager()
    {
        // Kalau Ada Game Manager
        if (instance != null)
        {
            // Hapus Game Manager
            Destroy(gameObject);
        }
        // Kalau Game Manager Belum Ada di Scene
        else
        {
            // Instansi Game Manager
            instance = this;
            // Agar Tetap ada di Scene
            DontDestroyOnLoad(gameObject);
        }
    }
}
