using UnityEngine;
using System.Collections;

public class UnityChanMain : MonoBehaviour
{
    private Animator animator;
    private float speed;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
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

            animator.SetBool("is_running", true);
        }
        else
        {
            animator.SetBool("is_running", false);
        }


        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKey("space"))
        {
            animator.SetBool("is_jumping", true);
        }
    }
}
