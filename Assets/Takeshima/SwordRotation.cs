using UnityEngine;

public class SwordEffects : MonoBehaviour
{
    public ParticleSystem rotationEffect; // パーティクルシステム
    public AudioSource rotationSound; // オーディオソース

    void Start()
    {
        if (rotationEffect == null)
            rotationEffect = GetComponentInChildren<ParticleSystem>(); // オブジェクトの子供からパーティクルシステムを取得

        if (rotationSound == null)
            rotationSound = GetComponent<AudioSource>(); // オブジェクトにアタッチされたオーディオソースを取得
    }

    // アニメーションイベントから呼ばれる関数
    public void TriggerEffects()
    {
        PlayEffectAndSound();
    }

    // エフェクトとサウンドを再生する関数
    private void PlayEffectAndSound()
    {
        // エフェクト再生
        if (rotationEffect != null && !rotationEffect.isPlaying)
            rotationEffect.Play();

        // サウンド再生
        if (rotationSound != null && !rotationSound.isPlaying)
            rotationSound.Play();
    }
}
