using UnityEngine;
using System.Collections;

public class SlimeMain : CharaBase
{
    private Vector3 followPos;

    // Use this for initialization
    void Start()
    {
        InitAnimController(GetComponent<Animation>());
        animControl.CrossFadeLoopAnim(CharaAnimController.AnimId.Wait);

        speed = 0.04f;
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckState(State.KnockBack))
        {
            if (knockBackStartTime + 0.1f > Time.time)
            {
                transform.position += (knockbackDir * 0.2f);
            }
            else
            {
                RemoveStateFlag(State.KnockBack);
                Destroy(gameObject);
            }
        }

        if (CheckState(State.Following))
        {
            Vector3 moveDirection = followPos - gameObject.transform.position;

            moveDirection.x = moveDirection.x * speed;
            moveDirection.y = 0;
            moveDirection.z = moveDirection.z * speed;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDirection, 5f * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position += moveDirection;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("SlimeMain::OnCollisionEnter -> " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("SlimeMain::OnTriggerEnter -> " + collider.name);

        if (collider.gameObject.CompareTag("Sword"))
        {
            Knockback(collider.gameObject.transform.position);
            return;
        }

        if (collider.gameObject.CompareTag("Player"))
        {
            AddStateFlag(State.Following);
            followPos = collider.gameObject.transform.position;
        }
    }
}
