using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float velocity = 20;
    Rigidbody2D rigibod;
    void Start()
    {
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
            Destroy(this.gameObject);
            Debug.Log("zombie");
        }
    }
}
