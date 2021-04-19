using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public PlayerScore kondisiPlayer;
    private float minX = 0f, maxX = 95f;
    void Awake()
    {
        player = GameObject.Find("Player");
        kondisiPlayer = player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        PosisiKamera();
    }

    public void PosisiKamera()
    {
        if (kondisiPlayer.masihHidup)
        {
            // Inisialisasi posisi kamera
            Vector3 temp = transform.position;
            // Set nilai X dan Y agar sama dengan posisi player
            temp.x = player.transform.position.x + 8f;
            // Cek agar kamera tidak keluar background
            if (temp.x < minX)
            {
                temp.x = minX;
            }
            if (temp.x > maxX)
            {
                temp.x = maxX;
            }
            // Turunkan Sedikit posisi Y agar kamera pas
            temp.y = player.transform.position.y + 1f;
            // Masukan Nilai X dan Y yang telah diubah
            transform.position = temp;
        }
    }
}
