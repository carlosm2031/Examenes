using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;
    public GameObject kunai;
    public Vector2 POINT;
    private Rigidbody2D rigibod;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha =true;
    private int saltosRestantes;
    private Animator animator;

    public AudioClip salto;
    public AudioClip upgrade;
    public AudioClip coin;

    private AudioSource audiosource;

    private GameManagerController gameManager;


    ///////
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRendererARMA;

    public TMP_Text armatxt;
    private bool arma = true;
    public GameObject zombie;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigibod = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManagerController>();
    }

    void Update()
    {
        if(gameManager.lives == 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    /* void ProcesarSalto()
     {
         if (EstaEnSuelo())
         {
             saltosRestantes = saltosMaximos;
         }

         if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
         {
             saltosRestantes--;
             audiosource.PlayOneShot(salto);     
             rigibod.velocity = new Vector2(rigibod.velocity.x, 0f);
             rigibod.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
             animator.SetInteger("Estado", 2);
         }
     }*/

    /*void ProcesarMovimiento()
    {
        //Logica de movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetInteger("Estado", 1);
        }
        else
        {
            animator.SetInteger("Estado", 0);
        }

        rigibod.velocity = new Vector2(inputMovimiento * velocidad, rigibod.velocity.y);
        GestionarOrientacion(inputMovimiento);
    }*/

    /*void GestionarOrientacion (float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;
            
            transform.localScale = new Vector2 (- transform.localScale.x, transform.localScale.y);

    

        }
    }*/
    /*void GestionarOrientacionK(float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;

            kunai.transform.localScale = new Vector2(-kunai.transform.localScale.x, kunai.transform.localScale.y);


        }
    }*/


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("bronze"))
        {
            audiosource.PlayOneShot(coin);
            gameManager.GanarBronze(1);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("silver"))
        {

            audiosource.PlayOneShot(coin);
            gameManager.GanarBronze(1);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("gold"))
        {
            audiosource.PlayOneShot(coin);
            gameManager.GanarBronze(1);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("point"))
        {
            POINT = collision.transform.position;
            Debug.Log("juego guardado");
            gameManager.SaveGame();
            gameManager.guardarPosi(POINT.x, POINT.y);
        }
        if (collision.gameObject.CompareTag("vacio"))
        {
            transform.position = POINT;
        }
        if (collision.gameObject.CompareTag("portal"))
        {
            if(gameManager.score == 10 && gameManager.bronzeCoin == 10)
            {
                Debug.Log("Portal");
                SceneManager.LoadScene(3);
            }
            
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {

            Destroy(collision.gameObject);
            gameManager.PerderVidas();
            gameManager.SaveGame();

            Debug.Log("zombie");

            //Cambiar el texto del puntaje

        }
    }



    /////////////////////////////////

    public void caminarIzquierda()
    {
        rigibod.velocity = new Vector2(-velocidad, rigibod.velocity.y);
        animator.SetInteger("Estado", 1);
        spriteRenderer.flipX = true;
        var zombiePostion = transform.position + new Vector3(15, 0, 0);
        Instantiate(zombie, zombiePostion, Quaternion.identity);
    }

    public void caminarDerecha()
    {
        rigibod.velocity = new Vector2(velocidad, rigibod.velocity.y);
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
   
    /*public void cambiarArma()
    {
        arma = !arma;
        Debug.Log(arma);

    }*/


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




    public void ProcesarSaltos()
    {

        rigibod.velocity = new Vector2(rigibod.velocity.x, 0f);
        rigibod.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        animator.SetInteger("Estado", 2);
        Debug.Log("sALTO");

    }

}


