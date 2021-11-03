using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    Camera cam;
    CircleSpawner _circleSpawner;

    private bool canSpawn;
    public GameObject firstCircle;
    public LineRenderer _lineRenderer;

    public Vector3 targetLocation;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        canSpawn = true;
        _circleSpawner = FindObjectOfType<CircleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        getTarget();

        if (Input.GetMouseButton(0))
        {

            if (canSpawn)
            {
                canSpawn = false;
                spawnFirstCircle();
            }
        }

    }
    void getTarget()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = cam.transform.position.z;

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, mousePos);
       
    }

    void spawnFirstCircle()
    {
        targetLocation = (mousePos - transform.position).normalized;
        GameObject go = Instantiate(firstCircle,transform.position, Quaternion.identity);

        _circleSpawner.BigCircleList.Add(go);
    }
}
