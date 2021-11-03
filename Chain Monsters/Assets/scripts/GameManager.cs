using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;

    public float xValueMin, xValueMax, yValueMin, yValueMax;
    // Start is called before the first frame update
    void Start()
    {
        if (_gameManager == null && _gameManager != this)
        {
            _gameManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
