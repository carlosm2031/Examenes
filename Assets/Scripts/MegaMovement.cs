using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaMovement : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;
    public GameObject kunai;
    public Vector2 POINT;

    private Rigidbody2D rigibod;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private int saltosRestantes;
    private Animator animator;

    public AudioClip salto;
    public AudioClip upgrade;
    public AudioClip coin;

    private AudioSource audiosource;

    private GameManagerController gameManager;

    // Start is called before the first frame update
    void Start()
    {

        rigibod = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            float inputMovimiento = Input.GetAxis("Horizontal");
            var bulletPostion = transform.position + new Vector3(2, 0, 0);
            Instantiate(kunai, bulletPostion, Quaternion.identity);
            GestionarOrientacion(inputMovimiento);

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
            audiosource.PlayOneShot(salto);
            rigibod.velocity = new Vector2(rigibod.velocity.x, 0f);
            rigibod.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetInteger("Estado", 3);
        }
    }

    void ProcesarMovimiento()
    {
        
        //Logica de movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetInteger("Estado", 2);
        }
        else
        {
            animator.SetInteger("Estado", 0);
        }

        rigibod.velocity = new Vector2(inputMovimiento * velocidad, rigibod.velocity.y);
        GestionarOrientacion(inputMovimiento);
    }
    void GestionarOrientacion(float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);



        }
    }
}
