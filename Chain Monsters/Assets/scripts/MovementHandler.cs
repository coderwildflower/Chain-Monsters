using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private Vector3 dir;
    public bool canMove;

  
    // Start is called before the first frame update
    void Start()
    {
    
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (transform.position.y > GameManager._gameManager.yValueMax)
            {
                dir.y = -dir.y;

            }
            if (transform.position.y < GameManager._gameManager.yValueMin)
            {
                dir.y = -dir.y;

            }
            if (transform.position.x > GameManager._gameManager.xValueMax)
            {
                dir.x = -dir.x;
            }
            if (transform.position.x < GameManager._gameManager.xValueMin)
            {
                dir.x = -dir.x;
            }

            transform.position += dir * 8 * Time.deltaTime;
            stopMovement();
        }
    }

    void Init()
    {
        dir = transform.up.normalized;
        canMove = true;

    }

    void stopMovement()
    {
        if (GetComponent<CollisionHandler>()._canMove == false)
        {
            canMove = false;
        }
    }
}
