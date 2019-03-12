using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    [SerializeField, Tooltip("押す入力名")]
    string controlInput;
    [SerializeField, Tooltip("手の動くスピード")]
    float speed = 1;
    [SerializeField,Tooltip("回転を逆にするか")]
    bool inverse;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown(controlInput))
        {
            var dir = transform.parent.position - transform.position;
            Vector3 crossVector;
            
            if (inverse) { crossVector = Vector3.Cross(dir, -Vector3.forward); }
            else { crossVector = Vector3.Cross(dir, Vector3.forward); }

            var forceVec = crossVector.normalized * speed;
            rb.AddForce(forceVec, ForceMode2D.Impulse);
        }
    }
}
