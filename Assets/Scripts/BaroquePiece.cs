using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(Collider))]
public class BaroquePiece : MonoBehaviour
{
    public enum BType
    {
        Red, Green, Blue, Purple, White, Orange, Ornament
    }
    public MeshFilter BaroqueMeshFilter { get; private set; }
    public MeshRenderer BaroqueMeshRenderer { get; private set; }
    public Collider BaroqueCollider { get; private set; }

    Rigidbody m_rigidbody;

    [SerializeField] Color disabledColor = Color.black;
    public bool IsPlaceHolder { get; private set; }
    bool isPlacementBlocked = false;

    public bool CanBePlaced => IsPlaceHolder && !isPlacementBlocked;
    [SerializeField] BType type;

    public BType Type { get { return type; } }

    Color meshColor;

    // Start is called before the first frame update
    void Awake()
    {
        BaroqueMeshFilter = GetComponent<MeshFilter>();
        BaroqueMeshRenderer = GetComponent<MeshRenderer>();
        BaroqueCollider = GetComponent<Collider>();

        meshColor = BaroqueMeshRenderer.material.color;
    }

    public void SetAsPlaceholder(bool isPlaceHolder = true)
    {
        BaroqueCollider.isTrigger = true;
        this.IsPlaceHolder = isPlaceHolder;
        m_rigidbody = gameObject.AddComponent<Rigidbody>();
        m_rigidbody.isKinematic = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsPlaceHolder) return;

        isPlacementBlocked = true;
        BaroqueMeshRenderer.material.color = disabledColor;
        //Color tempColor = new Color(meshColor.r, meshColor.g, meshColor.b, 0.4f);
        //BaroqueMeshRenderer.material.color = tempColor;

        // compare other tag / layer
        // show red
    }

    private void OnTriggerExit(Collider other)
    {
        if (!IsPlaceHolder) return;
        isPlacementBlocked = false;
        BaroqueMeshRenderer.material.color = meshColor;
        // return to original color
    }
}
