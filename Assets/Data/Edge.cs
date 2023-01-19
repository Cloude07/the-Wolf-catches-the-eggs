using System;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public float speedDownEdge;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private new AudioSource audio;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        rigidbody2D.gravityScale = speedDownEdge;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Graunded"))
        {
            animator.Play("Crash");
            audio.Play();
            transform.rotation=Quaternion.Euler(0f, 0f, 0f);
            rigidbody2D.bodyType = RigidbodyType2D.Static;

            Lives.lives--;
            Lives.Damage();
            Invoke("DestroyEdge", 0.5f);

        }

    }

    private void DestroyEdge()
    {
        Destroy(gameObject);
        
    }
}
