using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : MonoBehaviour
{
    private float kecepatan = 3f;
    public bool arahKiri;
    void Start()
    {
        StartCoroutine(UbahArah());
    }

    void Update()
    {
        BolakBalik();
    }
    public void BolakBalik()
    {
        Vector3 temp = transform.position;
        Vector3 tempScale = transform.localScale;

        if (arahKiri)
        {
            temp.x -= kecepatan * Time.deltaTime;
            tempScale.x = -Math.Abs(tempScale.x);
        }else
        {
            temp.x += kecepatan * Time.deltaTime;
            tempScale.x = Math.Abs(tempScale.x);
        }
        transform.position = temp;
        transform.localScale = tempScale;
    }
    // Membuat Skeleton Bolak-Balik dengan Courotine 
    IEnumerator UbahArah()
    {   
        // Waktu Berjalan ke kiri 3 Detik 
        yield return new WaitForSeconds(3f);
        // Ubah Arah ke Kanan
        arahKiri = !arahKiri;
        // Panggil Fungsi Courotine nya
        StartCoroutine(UbahArah());
    }
}
