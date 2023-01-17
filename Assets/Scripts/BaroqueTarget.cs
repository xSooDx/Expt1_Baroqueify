using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class BaroqueTarget : MonoBehaviour
{
    MeshFilter m_meshFilter;
    MeshCollider m_meshCollider;
    MeshRenderer m_meshRenderer;

    private void Awake()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_meshCollider = gameObject.AddComponent<MeshCollider>();
        m_meshCollider.sharedMesh = m_meshFilter.mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

