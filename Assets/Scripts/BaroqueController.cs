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
        Transform baroquePlaceHolderTransform = baroquePlaceHolder.transform;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, baroqueTargetMask))
        {
            baroquePlaceHolder.gameObject.SetActive(true);

            baroquePlaceHolderTransform.position = hitInfo.point;

            Vector3 upDir = Quaternion.Euler(rotation, 0, 0) * hitInfo.normal;

            baroquePlaceHolderTransform.rotation = Quaternion.LookRotation(hitInfo.normal);

            BaroqueTowerPart hitPart = hitInfo.transform.GetComponent<BaroqueTowerPart>();

            if (Input.GetMouseButtonDown(0) && baroquePlaceHolder.CanBePlaced && hitPart)
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green, .5f);
                Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, .5f);
                BaroquePiece newPiece = Instantiate(selectedBaroquePiece, baroquePlaceHolder.transform.position, baroquePlaceHolder.transform.rotation);
                newPiece.transform.parent = hitInfo.transform;

                if(newPiece.Type == hitPart.bType && hitPart.bType != BaroquePiece.BType.Ornament)
                {
                    GameManager.instance.AddPoints(-25);
                }
                else
                {
                    GameManager.instance.AddPoints(+10);
                }
                currentBaroqueIndex = Random.Range(0, baroquePieces.Length);
                SelectCurrentPiece();
            }
            if (Input.GetMouseButtonDown(1))
            {
                currentBaroqueIndex = Random.Range(0, baroquePieces.Length);
                SelectCurrentPiece();
                GameManager.instance.AddPoints(-5);
            }
        }
        else
        {
            baroquePlaceHolderTransform.position = new Vector3(-100, -100, -100);
        }

        if (Input.GetKeyDown(KeyCode.Z))
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
        if (baroquePlaceHolder != null)
        {
            Destroy(baroquePlaceHolder.gameObject);
        }

        baroquePlaceHolder = Instantiate(selectedBaroquePiece);
        baroquePlaceHolder.SetAsPlaceholder();
    }
}
