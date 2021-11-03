using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FirstCircle : MonoBehaviour
{
    public bool canMove;
  
    CircleSpawner _spawner;
    ObjectPlacement _objectPlacer;

    private void Awake()
    {
        _spawner = FindObjectOfType<CircleSpawner>();
        _objectPlacer = FindObjectOfType<ObjectPlacement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            if (transform.position.y > GameManager._gameManager.yValueMax)
            {
                _objectPlacer.targetLocation.y = -_objectPlacer.targetLocation.y;

            }
            if (transform.position.y < GameManager._gameManager.yValueMin)
            {
             
                _objectPlacer.targetLocation.y = -_objectPlacer.targetLocation.y;
            }
            if (transform.position.x > GameManager._gameManager.xValueMax)
            {
              
                _objectPlacer.targetLocation.x = -_objectPlacer.targetLocation.x;
            }
            if (transform.position.x < GameManager._gameManager.xValueMin)
            {
                _objectPlacer.targetLocation.x = -_objectPlacer.targetLocation.x;
            }

            transform.position += new Vector3(_objectPlacer.targetLocation.x, _objectPlacer.targetLocation.y, 0).normalized * 15 * Time.deltaTime;
            stopMovement();
        }

    }

    
    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(3);
        yield return new WaitForEndOfFrame();
        _spawner.BigCircleList.Remove(gameObject);
        Destroy(this.gameObject);
    }

    void stopMovement()
    {
        if (GetComponent<CollisionHandler>()._canMove == false)
        {
            canMove = false;
        }
    }
}
