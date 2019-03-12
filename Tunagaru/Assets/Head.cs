using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField,Tooltip("ついてきてほしいものでMovePositionで動かしたいもの")]
    Rigidbody2D[] rbChildren;
    [SerializeField, Tooltip("ついてきてほしいものでTranslateで動かしたいもの")]
    Transform[] transformChildren;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var moveVec = Vector2.right * speed * Time.deltaTime;
        rb.MovePosition((Vector2)transform.position + moveVec);

        //手など主導でコントロールしているものが置いてかれないように
        foreach(var childRb in rbChildren)
        {
            Debug.Assert(childRb.isKinematic == true);
            var childPos = childRb.transform.position;
            childRb.MovePosition((Vector2)childPos + moveVec);
        }
        //手の付け根などMovePositionで動かさないもの
        foreach (var childTransform in transformChildren)
        {
            childTransform.position += (Vector3)moveVec;
        }
    }
}
