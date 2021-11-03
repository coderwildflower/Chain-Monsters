using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject circle;

    [SerializeField]
    private int objectCount;

    private float xValue, yValue;

    public List<GameObject> BigCircleList;

    // Start is called before the first frame update
    void Start()
    {
        BigCircleList = new List<GameObject>();
        spawnCircles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnCircles()
    {
        for (int i = 0; i < objectCount; i++)
        {
            xValue = Random.Range(GameManager._gameManager.xValueMin, GameManager._gameManager.xValueMax);
            yValue = Random.Range(GameManager._gameManager.yValueMin, GameManager._gameManager.yValueMax);

            Instantiate(circle, new Vector2(xValue, yValue), Quaternion.Euler(0,0,Random.Range(360,-360)));
        }
    }

}
