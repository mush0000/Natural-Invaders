using System.Security.Cryptography;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    protected string characterName;//キャラクター名
    protected int characterLife;//キャラクターのHP
    protected int characterAtk;//キャラクタの攻撃力
    protected int characterAtkm;//キャラクターの中列攻撃力
    protected int characterSpd;//キャラクターの素早さ
    protected int characterHeal;//キャラクターの回復力
    protected int characterAaux;//キャラクターの攻撃補助力
    protected int characterDaux;//キャラクターの防御補助力
    protected int MaxCharacterLife => characterLife;//回復時にキャラクターの最大HPを超えないように設定

    protected int enemyLife;  // enemyLifeをCharacterScriptのフィールドとして追加

    private ParticleSystem particleSystem;  // ParticleSystemコンポーネント
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
        int atkm = 0)
    {
        characterName = name;
        characterLife = life;
        characterAtk = atk;
        characterSpd = spd;
        characterHeal = heal;
        characterAaux = aaux;
        characterDaux = daux;
        characterAtkm = atkm;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }


    // キャラクターの共通の振る舞いやメソッドなどを追加することができます
    public void DisplayCharacterInfo()
    {
        Debug.Log($"Character Name: {characterName}, Life: {characterLife}");
    }

    public virtual void FrontAction()
    {
        int enemyLifeDecrease = characterAtk;
        enemyLife -= enemyLifeDecrease;  //enemyLifeを減少させる

        FrontActionSound(); // サウンド再生
        FrontActionEffect(); // エフェクト再生
    }

    private void FrontActionSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  //sampleSoundは事前にアタッチされたAudioClip
    }
    private void FrontActionEffect()
    {
        // エフェクトプレハブの生成と再生
        GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    }

    public virtual void MiddleAction()
    {
        int enemyLifeDecrease = characterAtkm;
        enemyLife -= enemyLifeDecrease;  // enemyLifeを減少させる
        Debug.Log("中列攻撃");

        MiddleActionSound(); // サウンド再生の呼び出し
        MiddleActionEffect(); // エフェクト再生
    }
    private void MiddleActionSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  // sampleSoundは事前にアタッチされたAudioClip
    }
    private void MiddleActionEffect()
    {
        // エフェクトプレハブの生成と再生
        GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
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

        BackActionSound(); // サウンド再生の呼び出し
        BackActionnEffect(); // エフェクト再生

    }
    private void BackActionSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  // sampleSoundは事前にアタッチされたAudioClip
    }
    private void BackActionnEffect()
    {
        // エフェクトプレハブの生成と再生
        GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    }

    public virtual void Death()
    {
        Debug.Log("死亡した");
        //Destroy(）
        DeathSound(); // サウンド再生の呼び出し
        DeathEffect(); // エフェクト再生
    }
    private void DeathSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  // sampleSoundは事前にアタッチされたAudioClip
    }
    private void DeathEffect()
    {
        // エフェクトプレハブの生成と再生
        GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    }


    public void SetEnemyLife(int life)
    {
        enemyLife = life;
    }
}
