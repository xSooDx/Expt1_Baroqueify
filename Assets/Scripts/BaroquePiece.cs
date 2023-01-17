using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class BaroquePiece : MonoBehaviour
{
    public MeshRenderer meshRenderer { get; private set; }
    public Collider collider { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }
}
