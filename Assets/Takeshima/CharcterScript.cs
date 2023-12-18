using System.Security.Cryptography;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    protected string characterName; //キャラクター名
    public int characterLife; //キャラクターのHP
    protected int characterAtk; //キャラクタの攻撃力
    protected int characterMatk; //キャラクターの中列攻撃力
    protected int characterSpd; //キャラクターの素早さ
    protected int characterHeal; //キャラクターの回復力
    protected int characterAaux; //キャラクターの攻撃補助力
    protected int characterDaux; //キャラクターの防御補助力
    protected int CharacterPosition; //キャラクターの場所指定
    public int position = 0; //キャラクターの現在位置
    public bool isDead = false; //キャラクターの死亡判定
    protected int MaxCharacterLife => characterLife; //回復時にキャラクターの最大HPを超えないように設定

    protected int enemyLife;  // enemyLifeをCharacterScriptのフィールドとして追加

    // private ParticleSystem particleSystem;  // ParticleSystemコンポーネント
    private AudioSource audioSource;  // AudioSourceコンポーネント
    public GameObject attackEffectPrefab;  // 前列攻撃のエフェクトプレハブ
    public AudioClip attackSound;

    //  public GameObject frontActionEffectPrefab;  // 前列攻撃のエフェクトプレハブ
    // public AudioClip frontActioSound;          // 前列攻撃のサウンド



    // コンストラクタ
    public CharacterScript(
        string name = "DefaultName",
        int life = 0,
        int atk = 0,
        int spd = 0,
        int heal = 0,
        int aaux = 0,
        int daux = 0,
        int matk = 0)
    {
        characterName = name;
        characterLife = life;
        characterAtk = atk;
        characterSpd = spd;
        characterHeal = heal;
        characterAaux = aaux;
        characterDaux = daux;
        characterMatk = matk;
    }
    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        // particleSystem = GetComponent<ParticleSystem>();
    }


    // キャラクターの共通の何かを追加することがあれば。
    public void DisplayCharacterInfo()
    {
        Debug.Log($"Character Name: {characterName}, Life: {characterLife}");
    }

    public virtual void FrontAction()
    {
        int enemyLifeDecrease = characterAtk;
        enemyLife -= enemyLifeDecrease;  //enemyLifeを減少させる

        // FrontActionSound(); // サウンド再生
        // FrontActionEffect(); // エフェクト再生
    }

    public virtual void MiddleAction()
    {
        int enemyLifeDecrease = characterMatk;
        enemyLife -= enemyLifeDecrease;  // enemyLifeを減少させる
        Debug.Log("中列攻撃");

        // MiddleActionSound(); // サウンド再生の呼び出し
        // MiddleActionEffect(); // エフェクト再生
    }


    public virtual void BackAction()
    {

        // characterHealの値をcharacterLifeに追加する
        int addedLife = characterLife + characterHeal;

        // 最大値を超えないように調整
        characterLife = Mathf.Clamp(addedLife, 0, MaxCharacterLife);

        // ここでcharacterLifeの値が更新された状態
        Debug.Log("後列行動");
        Debug.Log($"Character Life after BackAction: {characterLife}");

        // BackActionSound(); // サウンド再生の呼び出し
        // BackActionnEffect(); // エフェクト再生

    }

    public virtual void autoHeal()
    {
        int healAmount = Mathf.CeilToInt(MaxCharacterLife * 0.1f);  // MaxCharacterLife の 10% を計算
        characterLife = Mathf.Clamp(characterLife + healAmount, 0, MaxCharacterLife);
        Debug.Log("自動回復");
        // autoHealSound(); // サウンド再生の呼び出し
        // autoHealEffect(); // エフェクト再生
    }

    public void ModifyCharacterLife(int amount)
    {
        characterLife -= amount;

        // characterLife が 0 以下になった場合、isDead を false に設定
        if (characterLife <= 0)
        {
            characterLife = 0;
            isDead = false;
        }
    }

    public virtual void Death()
    {
        if (!isDead)
        {
            isDead = true;
            Debug.Log("死亡した");

            // キャラクターが死亡した際の処理
            // DeathSound();
            // DeathEffect();

        }
    }

    // private void DeathSound()
    // {
    //     // サウンド再生のロジック
    //     // audioSource.PlayOneShot(sampleSound);  // 固有キャラのAudioClip
    // }
    // private void DeathEffect()
    // {
    //     // エフェクトプレハブの生成と再生
    //     GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
    //     Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    // }

    // public void ResurrectionHP1()
    // {
    //     isDead = false;
    //     characterLife = 1;
    //     Debug.Log("蘇生した");
    //     gameObject.SetActive(true);
    // }


    // public void SetEnemyLife(int life)
    // {
    //     enemyLife = life;
    // }
}
