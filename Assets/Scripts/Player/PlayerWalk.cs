using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float speed = 30f, maxVelocity = 4f, lompat = 500f;
    private Rigidbody2D Rb;
    private Animator animator;
    public bool diTanah = false;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        Berjalan();
        Melompat();
    }
    private void Berjalan()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs (Rb.velocity.x);
        // Inisialisasi Keyboard A(-1), D(1), Arah Kanan(1), Arah Kiri(-1) (Dengan Nilai Default Horizontal = 0)
        float horizontal = Input.GetAxisRaw ("Horizontal");

        // Jika D/Kanan Di tekan (Horizontal + 1)
        if (horizontal > 0)
        {

            if (velocity < maxVelocity)
            {
                forceX = speed;
            }
            // Membuat Player Menghadap sesuai jalan
            // Ambil data dari komponen transform bagian scale 
            Vector3 temp = transform.localScale;
            // Ganti nilai X dari Scale
            temp.x = 1f;
            // Set Scale dengan Nilai X yang baru
            transform.localScale = temp;

            // Set animator boolean dari parameter jalan untuk menjalankan animasi
            animator.SetBool("Jalan", true);
        }else if (horizontal < 0)
        {
            if (velocity < maxVelocity)
            {
                forceX = -speed;
            }
            // Membuat Player Menghadap sesuai jalan
            // Ambil data dari komponen transform bagian scale 
            Vector3 temp = transform.localScale;
            // Ganti nilai X dari Scale menggunakan nilai (-) agar berbalik hadapannya
            temp.x = -1f;
            // Set Scale dengan Nilai X yang baru
            transform.localScale = temp;
            animator.SetBool("Jalan", true);
        }else
        {
            animator.SetBool("Jalan", false);
        }
        //Nilai X diatur dari Percabangan
        Rb.AddForce (new Vector2 (forceX, 0));
    }


    public void Melompat()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) )
        {
            if (diTanah)
            {
                diTanah = false;
                Rb.AddForce (new Vector2 (0, lompat));    
                    
            }
        }
    }
    // Set Nilai "BENAR" di Tanah untuk kondisi melompat
    private void OnTriggerEnter2D(Collider2D tanah)
    {
        if (tanah.gameObject.tag == "Tanah")
        {
            diTanah = true;
        }
    }
}
