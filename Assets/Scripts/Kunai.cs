using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float velocity = 20;
    private TextMesh scoreText;
    Rigidbody2D rigibod;

    private GameManagerController gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        rigibod = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {



        rigibod.velocity = new Vector2(velocity, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zombie")
        {

            Destroy(collision.gameObject);
            gameManager.GanarPuntos(10);
            gameManager.SaveGame();
          
             Destroy(this.gameObject);
             Debug.Log("zombie");

            //Cambiar el texto del puntaje

        }
    }
}
