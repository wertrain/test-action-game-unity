using UnityEngine;
using System.Collections;

public class CharaBase : MonoBehaviour
{
    // アニメ管理
    protected CharaAnimController animControl;
    // 移動速度
    protected float speed;
    // 攻撃中かどうか
    protected bool isAttack;
    // 攻撃開始時間   
    protected float attackStartTime;
    // 状態
    protected int state;
    // ノックバック方向
    protected Vector3 knockbackDir;
    // ノックバック時間
    protected float knockBackStartTime;

    // キャラクター状態定数
    protected enum State
    {
        Wait = 1 << 0,
        KnockBack = 1 << 1,
        Following = 1 << 2
    };
    // 追跡する位置
    protected Vector3 followPos;
    // 追跡する対象に対するオフセット位置
    protected Vector3 followOffset;

    // アニメーションコントローラーの初期化
    public void InitAnimController(Animation anim)
    {
        animControl = new CharaAnimController(anim);
    }

    // ノックバックさせる
    protected void Knockback(Vector3 dir)
    {
        knockbackDir = transform.position - dir;
        knockbackDir.y = 0;

        AddStateFlag(State.KnockBack);
        knockBackStartTime = Time.time;

        animControl.CrossFadeOnceAnim(CharaAnimController.AnimId.Damage);
    }

    protected bool CheckState(State stateId)
    {
        return ((state & (int)stateId) > 0);
    }

    protected void AddStateFlag(State stateId)
    {
        state |= (int)stateId;
    }

    protected void RemoveStateFlag(State stateId)
    {
        state &= (int)~stateId;
    }

    protected void Following(Vector3 pos)
    {
        AddStateFlag(State.Following);
        followPos = pos;
        followOffset = new Vector3(0,0,0);
    }
}
