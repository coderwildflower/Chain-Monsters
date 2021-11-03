using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerUpState { 

    blackhole,
    timerIncrease

};
public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager PowerUpInstance;

    private void Awake()
    {
        if (PowerUpInstance == null && PowerUpInstance != this)
        {
            PowerUpInstance = this;
        }
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
