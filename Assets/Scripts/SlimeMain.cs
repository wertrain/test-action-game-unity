using UnityEngine;
using System.Collections;

public class SlimeMain : CharaBase
{
    // Use this for initialization
    void Start()
    {
        InitAnimController(GetComponent<Animation>());
        animControl.CrossFadeLoopAnim(CharaAnimController.AnimId.Wait);

        speed = 0.02f;
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckState(State.KnockBack))
        {
            if (knockBackStartTime + 0.3f > Time.time)
            {
                transform.position += (knockbackDir * 0.1f);
            }
            else
            {
                RemoveStateFlag(State.KnockBack);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Sword"))
        {
            Knockback(collider.gameObject.transform.position);
        }
    }
}
