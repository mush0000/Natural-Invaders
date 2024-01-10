using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachAttackTrigger : MonoBehaviour
{
    public GameObject peachImpactPrefab; // PeachImpactプレファブ
    private Animator activeEffectAnimator;

    void Start()
    {
        // ActiveEffectのAnimatorを取得
        // activeEffectAnimator = peachImpactPrefab.GetComponent<Animator();

        // 初期では非アクティブにしておく
        peachImpactPrefab.SetActive(false);
    }

    // AnimationEventから呼ばれるメソッド
    public void OnAnimationEnd()
    {
        // アニメーションが終了したら非アクティブにする
        peachImpactPrefab.SetActive(false);
    }

    void PlayActiveEffectAnimation()
    {
        // ActiveEffectをアクティブにする
        peachImpactPrefab.SetActive(true);

        // ActiveEffectのAnimatorで定義されたアニメーションを再生
        activeEffectAnimator.SetTrigger("YourAnimationTriggerName");
    }
}
