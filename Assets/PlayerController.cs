using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode upButton = KeyCode.W; // Tombol untuk menggerakan ke atas
    public KeyCode downButton = KeyCode.S; // Tombol untuk menggerakan ke bawah
    public float speed = 10.0f; // kecepatan gerak
    public float yBoundary = 9.0f; //Batas atas dan batas bawah game scene
    private Rigidbody2D rigidBody2D; //Rigidbody2d raket
    private int score; // Skor pemain
    private ContactPoint2D lastContactPoint;
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("bola"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;// Dapatkan kecepatan raket sekarang
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;//jika menekan tombol w
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0.00f;
        }
        rigidBody2D.velocity = velocity;// Masukkan kembali kecepatannya ke rigidBody2D.

        Vector3 position = transform.position;//Mendapatkan posisi Raket
        if (position.y > yBoundary)
        {
            position.y = yBoundary;// Jika posisi raket melewati batas atas kemuddian kembalikan ke batas atas
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;// Jika posisi raket melewati batas bawah kemuddian kembalikan ke batas bawah
        }
        transform.position = position;// Masukkan kembali posisi ke transform awal
    }
    public void IncrementScore()
    {
        score++; // Menaikkan skor sebanyak 1 poin
    }

    public void ResetScore()
    {
        score = 0;// mengembalikan skor menjadi 0
    }

    public int Score
    {
        get { return score; } // Mendapatkan nilai skor
    }
}
