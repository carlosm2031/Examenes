using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update

    public float smootherFactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var targetPosition = target.position;
        //var smootherPosition = Vector3.Lerp(transform.position, targetPosition, smootherFactor * Time.fixedDeltaTime);
        
        //transform.position = smootherPosition;
        transform.position = target.position;
    }
}
