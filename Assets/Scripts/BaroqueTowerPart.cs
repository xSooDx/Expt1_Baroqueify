using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaroqueTowerPart : MonoBehaviour
{

    [SerializeField] MeshRenderer segmentMeshRenderer;
    public BaroquePiece.BType bType;//{ get; private set; }
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        if (segmentMeshRenderer == null) segmentMeshRenderer = GetComponent<MeshRenderer>();

        bType = (BaroquePiece.BType)Random.Range(0, BaroquePiece.BType.GetValues(typeof(BaroquePiece.BType)).Length - 1);

        switch (bType)
        {
            case BaroquePiece.BType.Red:
                segmentMeshRenderer.material.color = Color.red;
                break;
            case BaroquePiece.BType.Green:
                segmentMeshRenderer.material.color = Color.green;
                break;
            case BaroquePiece.BType.Blue:
                segmentMeshRenderer.material.color = Color.blue;
                break;
            case BaroquePiece.BType.White:
                segmentMeshRenderer.material.color = Color.white;
                break;
            case BaroquePiece.BType.Purple:
                segmentMeshRenderer.material.color = Color.magenta;
                break;
            case BaroquePiece.BType.Orange:
                Debug.Log("Orange");
                segmentMeshRenderer.material.color = new Color(255f / 255f, 140f / 255f, 0f / 255f);
                break;
            //case BaroquePiece.BType.Ornament:
            //    segmentMeshRenderer.material.color = new Color(255f / 255f, 223f / 255f, 50f / 255f);
            //    segmentMeshRenderer.material.SetFloat("_Metallic", 1f);
            //    segmentMeshRenderer.material.SetFloat("_Glossiness", 1f);
            //    break;
            default:
                Debug.Log(bType);
                break;
        }
    }
}
