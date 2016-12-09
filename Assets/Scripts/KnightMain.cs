using UnityEngine;
using System.Collections;

public class KnightMain : MonoBehaviour {

    // 旧アニメーションコンポーネント
    private Animation animation;
    // 移動速度
    private float speed;
    // 攻撃中かどうか
    private bool isAttack;

    // Use this for initialization
    void Start () {
        animation = GetComponent<Animation>();
        animation.Play("Wait");
        animation.wrapMode = WrapMode.Loop;
        speed = 0.05f;
        isAttack = false;
    }
	
    // Update is called once per frame
    void Update () {

        if (isAttack)
        {
            if (!animation.isPlaying)
            {
                isAttack = false;
            }
        }
        else
        {
            if (Input.GetKey("space"))
            {
                animation.CrossFade("Attack");
                animation.wrapMode = WrapMode.Once;
                isAttack = true;
                return;
            }

            if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down"))
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

                animation.CrossFade("Walk");
            }
            else
            {
                animation.CrossFade("Wait");
            }
        }
    }
}
