using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class BaroqueTowerSegment : MonoBehaviour
{
    public float rotationSpeed;
    [SerializeField] Transform towerSlot;

    public Vector3 Slot { get { return towerSlot.position; } }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }
}