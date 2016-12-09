using UnityEngine;
using System.Collections;

public class SlimeMain : MonoBehaviour {

    // 旧アニメーションコンポーネント
    private Animation animation;
    // 移動速度
    private float speed;
    // 攻撃中かどうか
    private bool isAttack;

    // Use this for initialization
    void Start ()
    {
        animation = GetComponent<Animation>();
        animation.Play("Wait");
        animation.wrapMode = WrapMode.Loop;
        speed = 0.02f;
        isAttack = false;
    }
	
    // Update is called once per frame
    void Update ()
    {
	
    }
}
