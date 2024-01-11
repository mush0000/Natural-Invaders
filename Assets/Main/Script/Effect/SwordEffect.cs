using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    public GameObject effectPrefab; // エフェクトのPrefab
    public AudioSource soundPrefab; // サウンドのPrefab
    public GameObject targetObject; // 適用先のオブジェクト

    // アニメーションイベントから呼ばれる関数
    public void TriggerEffectAnimationEvent()
    {
        // エフェクトのPrefabが設定されているか確認
        if (effectPrefab != null)
        {
            // インスタンス生成
            GameObject effectInstance = Instantiate(effectPrefab);

            // サウンドのPrefabが設定されているか確認
            if (soundPrefab != null)
            {
                // サウンドのPrefabを元にサウンドのインスタンス生成
                AudioSource soundInstance = Instantiate(soundPrefab);

                // インスタンス生成したサウンドをエフェクトにアタッチ
                soundInstance.transform.SetParent(effectInstance.transform);
            }

            // 適用
            if (targetObject != null)
            {
                // インスタンスのTransformをオブジェクトにアタッチ
                effectInstance.transform.SetParent(targetObject.transform, false);

                // エフェクトの位置や大きさを設定
                effectInstance.transform.localPosition = new Vector3(0f, 0.5f, 0f); // 例: Y軸方向に2単位上に移動
                effectInstance.transform.localScale = new Vector3(7f, 7f, 7f); // 例: 全体のスケールを2倍に
            }
        }
        else
        {
            Debug.LogError("Effect Prefab not set.");
        }
    }
}
