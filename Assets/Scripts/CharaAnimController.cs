using UnityEngine;
using System.Collections;

public class CharaAnimController
{
    // 旧アニメーションコンポーネント
    protected Animation animControl;
    // アニメID
    public enum AnimId
    {
        Wait,
        Walk,
        Attack,
        Damage,
        Dead
    }
    protected AnimId animId;

    public CharaAnimController(Animation anim)
    {
        animControl = anim;
    }

    private void CrossFadeAnim(AnimId id)
    {
        animId = id;
        animControl.CrossFade(GetAnimNameFromId(id));
    }

    public void CrossFadeOnceAnim(AnimId id)
    {
        CrossFadeAnim(id);
        animControl.wrapMode = WrapMode.Once;
    }

    public void CrossFadeLoopAnim(AnimId id)
    {
        CrossFadeAnim(id);
        animControl.wrapMode = WrapMode.Loop;
    }

    public bool IsPlaying(AnimId id)
    {
        return animId == id && animControl.IsPlaying(GetAnimNameFromId(id));
    }

    protected string GetAnimNameFromId(AnimId id)
    {
        switch(id)
        {
            case AnimId.Wait: return "Wait";
            case AnimId.Walk: return "Walk";
            case AnimId.Damage: return "Damage";
            case AnimId.Dead: return "Dead";
            case AnimId.Attack: return "Attack";
        }
        return string.Empty;
    }
}
