using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollisionHandler : MonoBehaviour
{
    CircleSpawner _spawner;

    public float radius;
    private Vector3 targetScale;

    private bool canScale;
    public bool _canMove;

    public float destroyTimer;
    private void Awake()
    {
        _spawner = FindObjectOfType<CircleSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
    }
    void init()
    {
        targetScale = new Vector3(4, 4, 4);
        radius = transform.localScale.y / 2;
        canScale = true;
        _canMove = true;
    }
    void CheckCollision()
    {
        for (int i = 0; i < _spawner.BigCircleList.Count; i++)
        {
            //skip loop iteration for self
            if (_spawner.BigCircleList[i].transform == transform)
            {
                continue;
            }

            float distance = Vector2.Distance(transform.position, _spawner.BigCircleList[i].transform.position);

            if (distance < (radius + _spawner.BigCircleList[i].GetComponent<CollisionHandler>().radius))
            {
                if (canScale)
                {
                    if (!_spawner.BigCircleList.Contains(gameObject))
                    {
                        _spawner.BigCircleList.Add(gameObject);
                   
                    }
                    scaleUp();
                }

            }
        }
    }
    void scaleUp()
    {
        canScale = false;
        _canMove = false;
        transform.DOScale(targetScale, 1f).SetEase(Ease.OutElastic);
        radius = targetScale.y / 2;
        StartCoroutine("destroyDelay");
    }

    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(3);
        yield return new WaitForEndOfFrame();
        _spawner.BigCircleList.Remove(gameObject);
        Destroy(this.gameObject);
    }


}
