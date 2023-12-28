using UnityEngine;

public class PeachImpact : MonoBehaviour
{
    public GameObject effectPrefab; // インスペクターでエフェクトのPrefabを設定
    public float effectDuration = 3.0f; // エフェクトをアクティブにする時間

    private void Start()
    {
        // 初期状態ではエフェクトを非アクティブにする
        if (effectPrefab != null)
        {
            effectPrefab.SetActive(false);
        }
    }

    // AnimationEventから呼び出すメソッド
    public void ActivateEffect()
    {
        if (effectPrefab != null)
        {
            // エフェクトをアクティブにする
            effectPrefab.SetActive(true);

            // 一定時間後に非アクティブにする
            Invoke("DeactivateEffect", effectDuration);
        }
    }

    // エフェクトを非アクティブにするメソッド
    private void DeactivateEffect()
    {
        if (effectPrefab != null)
        {
            effectPrefab.SetActive(false);
        }
    }
}
