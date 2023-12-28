using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class CharacterScript : MonoBehaviour
{
    public Enemy2 enemy;
    protected string characterName; // キャラクター名
    protected int characterLife; // キャラクターのHP
    protected int characterAtk; // キャラクタの攻撃力
    protected int characterMatk; // キャラクターの中列攻撃力
    protected int characterSpd; // キャラクターの素早さ
    protected int characterHeal; // キャラクターの回復力
    protected int characterAaux; // キャラクターの攻撃補助力
    protected int characterDaux; // キャラクターの防御補助力
    protected int characterPosition; // キャラクターの場所指定
    public int position = 0; // キャラクターの現在位置
    public bool isDead = false; // キャラクターの死亡判定
<<<<<<< HEAD
    protected int maxCharacterLife => characterLife; //回復時にキャラクターの最大HPを超えないように設定
=======
    protected int enemyLife;  // enemyLifeをCharacterScriptのフィールドとして追加
    protected int maxCharacterLife;
>>>>>>> SatoWork
    public Image image;

    private AudioSource audioSource;  // AudioSourceコンポーネント
    public GameObject attackEffectPrefab;  // 前列攻撃のエフェクトプレハブ
    public AudioClip attackSound;

    public int CharacterLife
    {
        get { return characterLife; }
        set
        {
            // 任意の制御や処理を追加できます
            characterLife = value;
            if (OnLifeChanged != null)
            {
                OnLifeChanged.Invoke(); //着火しまーす！
            }
<<<<<<< HEAD
        }
    }
    public int MaxCharacterLife
    {
        get { return characterLife; }
        // set { characterLife = value; } // これは不要なのでコメントアウトしました
    }
    public int CharacterAtk
    {
        get { return characterAtk; }
        set
        {
            // 任意の制御や処理を追加できます
            characterAtk = value;
        }
    }
    public int CharacterMatk
    {
        get { return characterMatk; }
        set
        {
            // 任意の制御や処理を追加できます
            characterMatk = value;
        }
    }
    public int CharacterSpd
    {
        get { return characterSpd; }
        set
        {
            // 任意の制御や処理を追加できます
            characterSpd = value;
        }
    }
    public int CharacterHeal
    {
        get { return characterHeal; }
        set
        {
            // 任意の制御や処理を追加できます
            characterHeal = value;
        }
    }
    public int CharacterAaux
    {
        get { return characterAaux; }
        set
        {
            // 任意の制御や処理を追加できます
            characterAaux = value;
        }
    }
    public int CharacterDaux
    {
        get { return characterDaux; }
        set
        {
            // 任意の制御や処理を追加できます
            characterDaux = value;
=======
>>>>>>> SatoWork
        }
    }
    public int MaxCharacterLife
    {
        get { return maxCharacterLife; }
        set { maxCharacterLife = value; }
    }
    public delegate void OnLifeChangedDelegate();
    public event OnLifeChangedDelegate OnLifeChanged;

    public CharacterScript(
        string name = "DefaultName",
        int life = 50,
        int atk = 5,
        int spd = 5,
        int heal = 5,
        int aaux = 5,
        int daux = 5,
        int matk = 5)
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
    public delegate void OnLifeChangedDelegate();
    public event OnLifeChangedDelegate OnLifeChanged;



    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        // audioSource = GetComponent<AudioSource>();
        // particleSystem = GetComponent<ParticleSystem>();
    }


    public void DisplayCharacterInfo() // キャラクターの共通の何かを追加することがあれば。
    {
        Debug.Log($"Character Name: {characterName}, Life: {characterLife}");
    }

    // public virtual IEnumerator FrontAction() 要修正
    public virtual void FrontAction()
    {
        int enemyLife = enemy.enemyLife;
        int enemyLifeDecrease = characterAtk;
<<<<<<< HEAD
        enemy.enemyLife -= enemyLifeDecrease;
=======
        enemyLife -= enemyLifeDecrease;  //enemyLifeを減少させる
        Debug.Log("前列攻撃");
>>>>>>> SatoWork

        // FrontActionSound(); // サウンド再生
        // FrontActionEffect(); // エフェクト再生
        // yield return new WaitForSeconds(0.5f);要修正
        //dmg 計算
    }

    public virtual void MiddleAction()
    {
        int enemyLife = enemy.enemyLife;
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
        characterLife = Mathf.Clamp(addedLife, 0, maxCharacterLife);

        // ここでcharacterLifeの値が更新された状態
        Debug.Log("後列行動");
        Debug.Log($"Character Life after BackAction: {characterLife}");

        // BackActionSound(); // サウンド再生の呼び出し
        // BackActionnEffect(); // エフェクト再生

    }

    public virtual void ResurrectionHP1()
    {
        isDead = false;
        characterLife = 1;
        Debug.Log("蘇生した");
        gameObject.SetActive(true);
    }

    public virtual void AutoHeal()
    {
        int gainLife = (int)(characterLife * 0.2);
        characterLife += gainLife;
        Debug.Log($"{gainLife}回復した");
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

    public void SelectButton()
    {
        Debug.Log("selectbutton");
        // ClickManager.SetSelectChar(this);//ClickManagerクラスのSetSelectChar()へインスタンスを渡す
    }

    private void DeathSound()
    {
        // サウンド再生のロジック
        // audioSource.PlayOneShot(sampleSound);  // 固有キャラのAudioClip
    }
    // private void DeathEffect()
    // {
    //     // エフェクトプレハブの生成と再生
    //     GameObject effectInstance = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
    //     Destroy(effectInstance, particleSystem.main.duration);  // エフェクトが終了したら削除
    // }


    // public void SetEnemyLife(int life)
    // {
    //     enemyLife = life;
    // }
}
