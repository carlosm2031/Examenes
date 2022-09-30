using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Movi : MonoBehaviour
{
    private Rigidbody2D rigibod;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRendererARMA;
    private Animator animator;
    public LayerMask capaSuelo;

    public TMP_Text armatxt;
    private bool arma;
    public float fuerzaSalto;
    public int saltosMaximos;
    public float velocidad = 7;
    public GameObject kunai;
    public GameObject zombie;

    // Start is called before the first frame update
    void Start()
    {
        rigibod = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRendererARMA = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void caminarIzquierda()
    {
        rigibod.velocity = new Vector2(-velocidad, rigibod.velocity.y);
        spriteRenderer.flipX = true;
        animator.SetInteger("Estado", 1);
        var zombiePostion = transform.position + new Vector3(15, 0, 0);
        Instantiate(zombie, zombiePostion, Quaternion.identity);
    }

    public void caminarDerecha()
    {
        rigibod.velocity = new Vector2(velocidad,rigibod.velocity.y);
        animator.SetInteger("Estado", 1);
        spriteRenderer.flipX = false;
        var zombiePostion = transform.position + new Vector3(15, 0, 0);
        Instantiate(zombie, zombiePostion, Quaternion.identity);

    }
    public void Disparar()
    {
        if (arma)
        {
            var bulletPostion = transform.position + new Vector3(2, 0, 0);
            Instantiate(kunai, bulletPostion, Quaternion.identity);
            armatxt.text = "kunai";
            
        }
        else
        {

            animator.SetInteger("Estado", 4);
            Debug.Log("katana");
            armatxt.text = "Katana";
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {

            Destroy(collision.gameObject);
           
            Debug.Log("zombie muerto");

            //Cambiar el texto del puntaje

        }
    }
    public void cambiarArma()
    {
        arma = !arma ;
        Debug.Log(arma);

    }


    public void Detener()
    {
        rigibod.velocity = new Vector2(0, rigibod.velocity.y);
        animator.SetInteger("Estado", 0);

    }
    public void Saltar()
    {
        rigibod.velocity = new Vector2(0, rigibod.velocity.y);
        animator.SetInteger("Estado", 0);

    }




    public void ProcesarSalto()
    {
        
            rigibod.velocity = new Vector2(rigibod.velocity.x, 0f);
            rigibod.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetInteger("Estado", 2);
            Debug.Log("sALTO");
        
    }



}
