using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //var moveVec = Vector2.right * speed * Time.deltaTime;
        //GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + moveVec);
    }
}
