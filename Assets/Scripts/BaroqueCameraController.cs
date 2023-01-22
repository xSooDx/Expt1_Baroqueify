using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaroqueCameraController : MonoBehaviour
{
    public float moveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        }


        if (Input.GetKey(KeyCode.E))
        {
            float delta = moveSpeed * Time.deltaTime;
            transform.position += transform.forward * delta;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            float delta = moveSpeed * Time.deltaTime;
            transform.position += transform.forward * -delta;
        }
    }
}
