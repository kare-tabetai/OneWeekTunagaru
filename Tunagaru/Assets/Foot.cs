using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    Rigidbody2D rb;
    public bool IsGounded {
        get
        {
            if (hitObjects.Count != 0) { return true; }
            else { return false; }
        }
    }
    List<GameObject> hitObjects=new List<GameObject>();//現在ヒット指定物のリスト

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitObjects.Contains(collision.gameObject))
        {
            return;
        }else
        {
            hitObjects.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (hitObjects.Contains(collision.gameObject))
        {
            hitObjects.Remove(collision.gameObject);
        }
    }
}
