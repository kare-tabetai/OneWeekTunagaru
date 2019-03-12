using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField]
    Transform head;
    [SerializeField, Tooltip("足を上げる位置")]
    Transform footBendPos;
    [SerializeField, Tooltip("押す入力名")]
    string controlInput;
    [SerializeField]
    float speed = 1;

    Vector2 footLocalPos;
    Rigidbody2D rb;
    bool isBending;
    bool isMoveing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footLocalPos = head.InverseTransformPoint(transform.position);
    }

    void Update()
    {
        if (Input.GetButtonDown(controlInput))
        {
            isMoveing = true;
            isBending = !isBending;
        }
    }

    void FixedUpdate()
    {
        //ターゲットとの距離がこれ以下なら止まる がくがくしないように
        const float targetThreshold = 0.2f;

        if (!isMoveing) { return; }

        Vector2 dir;
        if (isBending)
        {
            dir = footBendPos.position - transform.position;
            var currentFootPos = (Vector2)transform.position + dir.normalized * speed;
            rb.MovePosition(currentFootPos);
            if(Vector2.Distance(footBendPos.position, currentFootPos)<= targetThreshold)
            {
                isMoveing = false;
            }
        }
        else
        {
            dir = head.TransformPoint(footLocalPos) - transform.position;
            var currentFootPos = (Vector2)transform.position + dir.normalized * speed;
            rb.MovePosition(currentFootPos);
            if (Vector2.Distance(head.TransformPoint(footLocalPos), currentFootPos) <= targetThreshold)
            {
                isMoveing = false;
            }
        }
        
    }
}
