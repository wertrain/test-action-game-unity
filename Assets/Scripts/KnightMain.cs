using UnityEngine;
using System.Collections;

public class KnightMain : CharaBase {
    // 剣当たり判定領域
    private BoxCollider swordCollider;

    // Use this for initialization
    void Start ()
    {
        animControl = GetComponent<Animation>();
        swordCollider = GetComponentInChildren<BoxCollider>();
        animControl.Play("Wait");
        animControl.wrapMode = WrapMode.Loop;
        speed = 0.05f;
        isAttack = false;
        swordCollider.enabled = false;
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (isAttack)
        {
            if (animControl.isPlaying)
            {
                if (!swordCollider.enabled && attackStartTime + 0.35f < Time.time)
                {
                    swordCollider.enabled = true;
                }
            }
            else
            {
                isAttack = false;
                swordCollider.enabled = false;
            }
        }
        else
        {
            if (Input.GetKey("space"))
            {
                animControl.CrossFade("Attack");
                animControl.wrapMode = WrapMode.Once;

                isAttack = true;
                attackStartTime = Time.time;
            }
            else if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down"))
            {
                Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
                Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);
                Vector3 moveDirection = Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward;

                moveDirection.x = moveDirection.x * speed;
                moveDirection.y = 0;
                moveDirection.z = moveDirection.z * speed;

                // 移動方向への回転
                Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDirection, 5f * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                transform.position += moveDirection;

                animControl.CrossFade("Walk");
                animControl.wrapMode = WrapMode.Loop;
            }
            else
            {
                animControl.CrossFade("Wait");
                animControl.wrapMode = WrapMode.Loop;
            }
        }
    }
}
