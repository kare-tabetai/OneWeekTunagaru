using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveHand : MonoBehaviour
{
    [SerializeField]
    Transform armRoot;
    [SerializeField, Tooltip("同時押しする入力名")]
    string controlInput;
    [SerializeField, Tooltip("手の動くスピード")]
    float speed=1;

    Rigidbody2D rb;
    Vector2 targetPos;
    bool moving;
    float armLength;//腕の付け根から手への長さ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        armLength = Vector2.Distance(armRoot.position,transform.position);
    }

    void Update()
    {
        if (Input.GetButton(controlInput) && Input.GetMouseButtonDown(0))
        {
            print("call");
            moving = true;
            Vector3 screenPos = Input.mousePosition;
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(screenPos);
        }
    }

    private void FixedUpdate()
    {
        //ターゲットとの距離がこれ以下なら止まる がくがくしないように
        const float targetThreshold = 0.2f;

        if (moving)
        {
            var dir = targetPos - (Vector2)transform.position;
            var toTargetDistance = dir.magnitude;
            if(toTargetDistance<= targetThreshold)
            {
                moving = false;
                return;
            }
            dir.Normalize();
            var currentHandPos = transform.position + (Vector3)dir * speed * Time.deltaTime;
            //手の長さより伸びそうになったら
            if(armLength < Vector2.Distance(currentHandPos, armRoot.position))
            {
                var armRootToHand = currentHandPos - armRoot.position;
                var diff = armRootToHand.magnitude - armLength;
                armRootToHand.Normalize();
                currentHandPos -= armRootToHand*diff;
            }
            rb.MovePosition(currentHandPos);
        }
    }
}
