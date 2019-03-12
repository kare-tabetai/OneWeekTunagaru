using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    Foot[] foots;
    bool isGrounded
    {
        get
        {
            foreach(var foot in foots)
            {
                if (foot.IsGounded) { return true; }
            }
            return false;
        }
    }

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)&&isGrounded)
        {
            print("jump");
            Vector3 screenPos = Input.mousePosition;
            var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(screenPos);
            var toMousePos = mousePosition - (Vector2)transform.position;
            //var jumpDir = toMousePos.normalized;
            var jumpDir = new Vector2(1,2).normalized;
            rb.AddForce(jumpDir * speed, ForceMode2D.Impulse);
        }
    }
}
