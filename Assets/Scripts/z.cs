using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : MonoBehaviour
{
    private Rigidbody2D rigibod;
    // Start is called before the first frame update
    void Start()
    {
        rigibod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigibod.velocity = new Vector2(-5, rigibod.velocity.y);
    }
}
