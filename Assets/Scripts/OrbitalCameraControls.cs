using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCameraControls : MonoBehaviour
{
    public Transform cameraPos;
    public float minDistance= 10f;
    public float maxDistance = 50f;
    public float rotationSpeed;
    public float zoomSpeed;
    public float verticalAngelLimit = 80f;
    float vertAngle;

    float distance;

    void Start()
    {
        distance = (maxDistance + minDistance) * 0.4f;
        cameraPos.transform.localPosition = transform.forward * -distance;
        vertAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            if(vertAngle < verticalAngelLimit)
            {
                float d = rotationSpeed*Time.deltaTime;
                vertAngle += d;
                transform.Rotate(transform.right, d, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(vertAngle > -verticalAngelLimit)
            {
                float d = rotationSpeed* -Time.deltaTime;
                vertAngle += d;
                transform.Rotate(transform.right, d, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, rotationSpeed*Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -rotationSpeed*Time.deltaTime, Space.World);
        }

        float scroll = Input.mouseScrollDelta.y;

        if(Mathf.Abs(scroll) > 0.01f)
        {
            float delta = scroll * zoomSpeed * Time.deltaTime;
            distance = Mathf.Clamp(distance -delta, minDistance, maxDistance);
            cameraPos.transform.position = transform.forward * -distance;
        }

        

    }
}
