using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Rigidbody2D rigibod;
    private int velo = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigibod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigibod.velocity = new Vector2(velo, rigibod.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zombie")
        {
            velo = 0;
            Debug.Log(",AS");
        }
    }

}
