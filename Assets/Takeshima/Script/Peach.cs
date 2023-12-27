using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peach : CharacterScript
{
    public GameObject effectPrefab; // エフェクトのPrefab
    private GameObject effectInstance; // 生成されたエフェクトのインスタンス
    public Peach() : base("Peach", 15, 5, 15, 20, 20, 20, 0)
    {
        // 親クラス(CharacterScript)のコンストラクタを呼び出す
        // ここで追加の初期化などを行うこともできます
    }

    public override void FrontAction()
    {
        base.FrontAction();
        // 固有キャラの前列行動の処理を追加

    }
    private void FrontActionSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  //固有キャラのAudioClip
    }
    private void FrontActionEffect()
    {
        // エフェクトプレハブの生成と再生
        // GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        // Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    }

    public override void MiddleAction()
    {
        base.MiddleAction();
        // Potato独自の中列行動の処理を追加
    }
    public override void BackAction()
    {
        base.BackAction();
        // Potato独自の後列行動の処理を追加
    }

    public override void AutoHeal()
    {
        base.AutoHeal();
    }

    private void MiddleActionSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  // 固有キャラのAudioClip
    }
    private void MiddleActionEffect()
    {
        // エフェクトプレハブの生成と再生
        // GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        // Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    }

    private void BackActionSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  // 固有キャラのAudioClip
    }
    private void BackActionnEffect()
    {
        // エフェクトプレハブの生成と再生
        // GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        // Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    }

    public override void Death()
    {
        base.Death();
        // キャラの生死判定
    }




    // Start is called before the first frame update
    void Start()
    {
        // Peachの子要素にあるエフェクトプレハブを取得
        effectPrefab = transform.Find("PeachEffectPrefab").gameObject;

        // 初期状態ではエフェクトを非アクティブにする
        if (effectPrefab != null)
        {
            effectPrefab.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // マウス左ボタンがクリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            ToggleEffect();
        }
    }
    // エフェクトのオン/オフを切り替えるメソッド
    void ToggleEffect()
    {
        if (effectInstance == null)
        {
            // エフェクトが生成されていない場合、生成する
            effectInstance = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            // エフェクトが既に生成されている場合、削除する
            Destroy(effectInstance);
        }
    }
}