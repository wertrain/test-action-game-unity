using UnityEngine;
using System.Collections;

public class SlimeMain : CharaBase
{
    // Use this for initialization
    void Start()
    {
        animControl = GetComponent<Animation>();
        animControl.Play("Wait");
        animControl.wrapMode = WrapMode.Loop;
        speed = 0.02f;
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((state & (int)State.KnockBack) > 0)
        {
            if (knockBackStartTime + 0.3f > Time.time)
            {
                transform.position += (knockbackDir * 0.1f);
            }
            else
            {
                state &= (int)~State.KnockBack;
            }
        }

        if ((animState & (int)AnimState.Damage) > 0)
        {
            if (!animControl.isPlaying)
            {
                animState &= (int)~AnimState.Damage;

                animControl.CrossFade("Wait");
                animControl.wrapMode = WrapMode.Loop;

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
