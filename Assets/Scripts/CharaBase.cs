using UnityEngine;
using System.Collections;

public class CharaBase : MonoBehaviour
{
    // 旧アニメーションコンポーネント
    protected Animation animControl;
    // 移動速度
    protected float speed;
    // 攻撃中かどうか
    protected bool isAttack;
    // 攻撃開始時間   
    protected float attackStartTime;
    // 状態
    protected int state;
    // アニメ状態
    protected int animState;
    // ノックバック方向
    protected Vector3 knockbackDir;
    // ノックバック時間
    protected float knockBackStartTime;

    // キャラクター状態定数
    protected enum State
    {
        Wait = 1 << 0,
        KnockBack = 1 << 1
    };
    // アニメ定数
    protected enum AnimState
    {
        Wait = 1 << 0,
        Walk = 1 << 1,
        Damage = 1 << 2,
        Dead = 1 << 3
    };
    // ノックバックさせる
    protected void Knockback(Vector3 dir)
    {
        knockbackDir = transform.position - dir;
        knockbackDir.y = 0;

        state |= (int)State.KnockBack;
        knockBackStartTime = Time.time;

        animState |= (int)AnimState.Damage;
        animControl.CrossFade("Damage");
        animControl.wrapMode = WrapMode.Once;
    }
}
