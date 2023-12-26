using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peach : CharacterScript
{
    private GameObject PeachAttack; // Peachのエフェクト
    private bool isPeachAttackOn = false; // Peachのエフェクトのオン/オフの状態を管理
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
    void TogglePeachAttack()
    {
        // オンの場合はオフに、オフの場合はオンにする
        PeachAttack.SetActive(!isPeachAttackOn);
        // 状態を反転
        isPeachAttackOn = !isPeachAttackOn;
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
        // 初期状態ではエフェクトを非アクティブにする
        if (PeachAttack != null)
        {
            PeachAttack = Instantiate(PeachAttack, transform.position, Quaternion.identity);
            PeachAttack.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // クリック時にPeachAttackをリセット
            TogglePeachAttack();

        }
    }
    private void SpawnPeachAttackPrefab()
    {
        if (PeachAttack != null)
        {
            // PeachAttackを生成して、位置と回転を設定
            PeachAttack = Instantiate(PeachAttack, transform.position, Quaternion.identity);
        }
    }
}