using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaroqueController : MonoBehaviour
{
    Camera mainCamera;

    [SerializeField] LayerMask baroqueTargetMask;
    [SerializeField] BaroquePiece[] baroquePieces;

    BaroquePiece selectedBaroquePiece;
    int currentBaroqueIndex = 0;

    BaroquePiece baroquePlaceHolder;

    [Range(-180f, 180f)]
    public float rotation;

    public float rotationRate = 90f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectCurrentPiece();
        
    }

    // Update is called once per frame
    void Update()
    {
        //ToDO: Rotation Logic
        if (Input.GetKey(KeyCode.Q))
        {
            rotation -= rotationRate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation += rotationRate * Time.deltaTime;
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, baroqueTargetMask))
        {
            baroquePlaceHolder.gameObject.SetActive(true);
            Transform baroquePlaceHolderTransform = baroquePlaceHolder.transform;
            baroquePlaceHolderTransform.position = hitInfo.point;

            Vector3 upDir = Quaternion.Euler(rotation, 0, 0) * hitInfo.normal;

            baroquePlaceHolderTransform.rotation = Quaternion.LookRotation(hitInfo.normal);
            //baroquePlaceHolderTransform.Rotate(baroquePlaceHolderTransform.forward, rotation);

            if (Input.GetMouseButtonDown(0) && baroquePlaceHolder.CanBePlaced)
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green, .5f);
                Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, .5f);
                Instantiate(selectedBaroquePiece, baroquePlaceHolder.transform.position, baroquePlaceHolder.transform.rotation).transform.parent = hitInfo.transform;
            }


        }
        else
        {
            baroquePlaceHolder.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            currentBaroqueIndex -= 1;
            if (currentBaroqueIndex < 0) currentBaroqueIndex = baroquePieces.Length - 1;
            SelectCurrentPiece();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentBaroqueIndex += 1;
            if (currentBaroqueIndex >= baroquePieces.Length) currentBaroqueIndex = 0;
            SelectCurrentPiece();
        }

    }

    void SelectCurrentPiece()
    {
        selectedBaroquePiece = baroquePieces[currentBaroqueIndex];
        if(baroquePlaceHolder != null)
        {
            Destroy(baroquePlaceHolder.gameObject);
        }

        baroquePlaceHolder = Instantiate(selectedBaroquePiece);
        baroquePlaceHolder.SetAsPlaceholder();
    }
}
