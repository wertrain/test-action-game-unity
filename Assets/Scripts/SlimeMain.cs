using UnityEngine;
using System.Collections;

public class SlimeMain : MonoBehaviour
{
    // 旧アニメーションコンポーネント
    private Animation animControl;
    // 移動速度
    private float speed;
    // 攻撃中かどうか
    private bool isAttack;
    // 状態
    private int state;
    // アニメ状態
    private int animState;
    // ノックバック方向
    private Vector3 knockbackDir;
    // ノックバック時間
    private float knockBackStartTime;

    enum State
    {
        Wait = 1 << 0,
        KnockBack = 1 << 1
    };

    enum AnimState
    {
        Wait   = 1 << 0,
        Walk   = 1 << 1,
        Damage = 1 << 2,
        Dead   = 1 << 3
    };

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
            if (knockBackStartTime + 0.05f > Time.time)
            {
                transform.position += (knockbackDir * 0.3f);
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
                Debug.Log("Damage");
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
            knockbackDir = transform.position - collider.gameObject.transform.position;
            knockbackDir.y = 0;

            animState |= (int)AnimState.Damage;

            state |= (int)State.KnockBack;
            knockBackStartTime = Time.time;

            animControl.CrossFade("Damage");
            animControl.wrapMode = WrapMode.Once;
        }
    }

    void Knockback(Vector3 dir)
    {

    }
}
