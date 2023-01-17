using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaroqueController : MonoBehaviour
{
    Camera mainCamera;

    [SerializeField] LayerMask baroqueTargetMask;
    [SerializeField] GameObject baroquePiece;

    GameObject baroquePlaceHolder;

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
        baroquePlaceHolder = Instantiate(baroquePiece);
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
            

            baroquePlaceHolder.SetActive(true);
            Transform baroquePlaceHolderTransform = baroquePlaceHolder.transform;
            baroquePlaceHolderTransform.position = hitInfo.point;

            Vector3 upDir = Quaternion.Euler(rotation, 0, 0) * hitInfo.normal;

            baroquePlaceHolderTransform.rotation = Quaternion.LookRotation(hitInfo.normal);
            //baroquePlaceHolderTransform.Rotate(baroquePlaceHolderTransform.forward, rotation);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green, .5f);
                Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, .5f);
                Instantiate(baroquePiece, baroquePlaceHolder.transform.position, baroquePlaceHolder.transform.rotation).transform.parent = hitInfo.transform;
            }


        }
        else
        {
            baroquePlaceHolder.SetActive(false);
        }

    }
}
