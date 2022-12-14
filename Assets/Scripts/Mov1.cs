using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov1 : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;

    [SerializeField]private float velocidadDeMovimiento;
    [Range(0, 0.3F)][SerializeField] private float suavizadoDeMovimiento;


    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
    }

    private void FixedUpdate()
    {
        //Mover
        Mover(movimientoHorizontal * Time.deltaTime);
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if(mover>0 && !mirandoDerecha)
        {
            //Girar
            Girar();

        }else if (mover<0 && mirandoDerecha)
        {
            //Girar
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
