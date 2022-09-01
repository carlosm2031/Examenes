using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 10;
    public bool puedeSaltar = false;
    public float fuerzaSalto = 10;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;


    public Vector3 checkpoint;
    void Start()
    {
        Debug.Log("Este es un nuevo mensaje");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", 0);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Estado", 4);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            sr.flipX = true;
            if (puedeSaltar != false)
            {
                animator.SetInteger("Estado", 1);
            }
        }

        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad * 2, rb.velocity.y);
            sr.flipX = false;
            animator.SetInteger("Estado", 2);
        }

        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad * 2, rb.velocity.y);
            sr.flipX = true;
            animator.SetInteger("Estado", 2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {

            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            puedeSaltar = false;
            animator.SetInteger("Estado", 3);

        }

 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        puedeSaltar = true;
      

        if (collision.gameObject.tag == "vacio")

        {
            transform.position = checkpoint;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkpoint = collision.gameObject.transform.position;
        if (collision.gameObject.tag == "checkpoint")
        {
            Debug.Log("bandera");

        }
    }
}
