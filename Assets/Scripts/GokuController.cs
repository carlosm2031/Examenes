using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GokuController : MonoBehaviour
{
    public float velocity = 10;
    Animator animator;
    Rigidbody2D RB;
    SpriteRenderer sr;
    private Vector2 direction;

    private float defaultGravity;

    private bool TieneNube = false ;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        defaultGravity = RB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        direction = new Vector2(x, y);
        Run();
        RB.velocity = new Vector2 (RB.velocity.x, 0);
        if (Input.GetKey(KeyCode.UpArrow) && TieneNube)
        {
            RB.velocity = new Vector2(RB.velocity.x, velocity);
        }
        if (Input.GetKey(KeyCode.DownArrow) && TieneNube)
        {
            RB.velocity = new Vector2(RB.velocity.x, -velocity);
        }
        if (Input.GetKey(KeyCode.C)){
            animator.SetInteger("State", 2);
            Debug.Log("carga");
        }
    }

    private void Run()
    {
     
        RB.velocity = new Vector2(direction.x * velocity, RB.velocity.y );
        sr.flipX = direction.x < 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "nube")
        {
            TieneNube = true;
            RB.gravityScale = 0;

            //SceneManager.LoadScene(GameManagerController.SCENE_1);
            animator.SetInteger("State", 1);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "suelo")
        {
            TieneNube = false;
            RB.gravityScale = defaultGravity;
            animator.SetInteger("State", 0);

        }
    }
}
