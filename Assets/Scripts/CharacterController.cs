using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;
    public GameObject kunai;

    private Rigidbody2D rigibod;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha =true;
    private int saltosRestantes;
    private Animator animator;
    private int estado = 1;

    private void Start()
    {
        rigibod = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            var bulletPostion = transform.position + new Vector3(3, 0, 0);
            Instantiate(kunai, bulletPostion, Quaternion.identity);
        }
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if (EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigibod.velocity = new Vector2(rigibod.velocity.x, 0f);
            rigibod.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetInteger("isRunning", 2);
        }
    }

    void ProcesarMovimiento()
    {
        //Logica de movimiento

        rigibod.velocity = new Vector2(velocidad, rigibod.velocity.y);

        animator.SetInteger("isRunning", estado);
        
     
        

       
        
    }

    void GestionarOrientacion (float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2 (- transform.localScale.x, transform.localScale.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {

            
            Debug.Log("MUERTO");
            estado = 3;
            velocidad = 0;

        }
    }
}
