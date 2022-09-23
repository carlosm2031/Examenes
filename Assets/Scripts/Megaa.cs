using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Megaa : MonoBehaviour
{
    private RaycastHit2D hit;
    public float distance;
    public float speed;
    public LayerMask layer;
    public float Gravedad;
    public float Altura_Salto;
    private Rigidbody2D rigibod;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkcolision
    {
        get
        {
            hit = Physics2D.Raycast(transform.position, transform.up * -1, distance, layer);
            return hit.collider != null; ;
        }
        
    }

    public void Detector_Plataforma()
    {
        if (checkcolision)
        {
            Altura_Salto = 0;
            Gravedad = 0;
            animator.SetInteger("Estado", 0);
        }
        else
        {
            animator.SetInteger("Estado", 2);
            Gravedad = -5;
        }
    }

    public void Mover()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("Estado", 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetInteger("Estado", 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("Estado", 1);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        
    }
    


}
