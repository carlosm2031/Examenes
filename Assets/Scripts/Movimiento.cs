using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;

    public float velocidad = 10;
    public float fuerzaSalto = 10;

    const int EstadoQuieto = 0;
    const int EstadoSaltar = 1;
    const int EstadoCorrer = 2;
    const int EstadoCaminar = 3;
    const int EstadoAtacar = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

   
    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.X))//caminar derecha
        {
            rb.velocity = new Vector2(velocidad *2, rb.velocity.y);
            sr.flipX = false;
            Debug.Log("Correr");
            animacion(EstadoCorrer);

        }else if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.X))//correr
        {
            rb.velocity = new Vector2(-velocidad * 2, rb.velocity.y);
            sr.flipX = true;
            Debug.Log("Correr");
            animacion(EstadoCorrer);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);//caminar Izquierda
            sr.flipX = true;
            animacion(EstadoCaminar);
        }else if(Input.GetKey(KeyCode.RightArrow)) //correr
        {
            rb.velocity = new Vector2(velocidad , rb.velocity.y);//caminar Izquierda
            sr.flipX = false;
            animacion(EstadoCaminar);
            
           
            
        }else if(Input.GetKey(KeyCode.Space))//Salto
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            animacion(EstadoSaltar);
        }else if (Input.GetKey(KeyCode.Z))//Ataque
        {
            animacion(EstadoAtacar);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animacion(EstadoQuieto);
        }
    }

    private void animacion(int esta)
    {
        ani.SetInteger("Estado", esta);
    }

}
