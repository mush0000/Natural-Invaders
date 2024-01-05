using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum EnemyKind_1
{
    //! 職業Enum
    ant,        //! アリ
    mantis,     //! カマキリ
    bee,        //! ハチ
    beetle,     //! カブトムシ
}

public abstract class EnemyParent_1 : MonoBehaviour
{
    //! Enemyステータス群
    private string enemyName;   //! 名前
    private int enemyAttack;    //! 攻撃力
    private int enemyLife;      //! 現在HP
    private int enemyMaxLife;   //! 最大HP(超過回復防止用)
    public ParticleSystem particleObject;

    //! Enemy詳細ステータス群
    private bool enemyChargeFlag = false;       //!「溜める」管理フラグ
    [SerializeField] private int enemyHealValue;                 //! 回復値
    private int enemyChargeMagnification = 2;   //!「溜める」倍率

    //! 各getter,setter
    public string EnemyName { get => enemyName; set => enemyName = value; }
    public int EnemyAttack { get => enemyAttack; set => enemyAttack = value; }
    public int EnemyMaxLife { get => enemyMaxLife; set => enemyMaxLife = value; }
    public int EnemyChargeMagnification { get => enemyChargeMagnification; set => enemyChargeMagnification = value; }
    public int EnemyHealValue { get => enemyHealValue; set => enemyHealValue = value; }
    public int EnemyLife
    {
        get => enemyLife;
        set
        {
            enemyLife = value;
            if (OnLifeChanged != null)
            {
                OnLifeChanged.Invoke(); //着火しまーす！
            }
        }
    }

    //! HPバーアニメーション同期
    public delegate void OnLifeChangedDelegate();
    public event OnLifeChangedDelegate OnLifeChanged;

    //! Enemy初期化時のステータス管理
    public void Initialize(EnemyKind_1 enemyKind, int enemyHealValue)
    {
        switch (enemyKind)
        {
            case EnemyKind_1.ant:
                EnemyName = "ant";
                EnemyLife = 500;
                EnemyMaxLife = EnemyLife;
                EnemyAttack = 100;
                EnemyHealValue = enemyHealValue;
                break;

            case EnemyKind_1.mantis:
                EnemyName = "mantis";
                EnemyLife = 1000;
                EnemyMaxLife = EnemyLife;
                EnemyAttack = 200;
                EnemyHealValue = enemyHealValue;
                break;

            case EnemyKind_1.bee:
                EnemyName = "bee";
                EnemyLife = 1500;
                EnemyMaxLife = EnemyLife;
                EnemyAttack = 300;
                EnemyHealValue = enemyHealValue;
                break;

            case EnemyKind_1.beetle:
                EnemyName = "beetle";
                EnemyLife = 2000;
                EnemyMaxLife = EnemyLife;
                EnemyAttack = 400;
                EnemyHealValue = enemyHealValue;
                break;

            default:
                Debug.Log("その敵は存在しない");
                break;
        }
    }

    //! 「行動パターン」分岐 -> 各クラスに記述を投げる
    public abstract void EnemyAction_1(int turnCount);

    //! 「溜める」行動
    public void EnemyCharge_1()
    {
        EnemyAttack *= EnemyChargeMagnification; //* 2倍Atk
        enemyChargeFlag = true;
    }

    //! 「溜める」解除_ヘルパー関数
    private void EnemyChargeInvalid_1()
    {
        EnemyAttack /= EnemyChargeMagnification; //* 2倍Atkを1倍に戻す
        enemyChargeFlag = false;
    }

    //! 「回復」行動
    public void EnemyHeal_1()
    {
        int tempHpHeal = EnemyLife + EnemyHealValue;
        if (tempHpHeal > EnemyMaxLife)
        {   //! 回復超過。HPMAXLifeを代入
            EnemyLife = EnemyMaxLife;
        }
        else
        {   //! 回復未超過。HPに回復量を加算
            EnemyLife += EnemyHealValue;
        }
    }

    //!「最前列ランダム単体攻撃」行動
    public void EnemySingleAttack_1(List<PlayerChildTest> characters)
    {
        List<PlayerChildTest> targetGroup = SelectTargetGroups_1(characters);
        PlayerChildTest targetCharacter = SelectCharacterFromRow_1(targetGroup);

        enemyAttack -= targetCharacter.PlayerDaux;  //!
        targetCharacter.PlayerLife -= enemyAttack;

        //? 攻撃行動後にEnemyが「溜める」状態だった場合、「溜める」解除。
        if (enemyChargeFlag == true)
        {
            EnemyChargeInvalid_1();
        }
    }

    public void EnemyGroupAttack_1(List<PlayerChildTest> characters)
    {
        List<PlayerChildTest> targetGroup = SelectTargetGroups_1(characters);

        foreach (PlayerChildTest Group in targetGroup)
        {
            Group.PlayerLife -= enemyAttack;
        }

        //? 攻撃行動後にEnemyが「溜める」状態だった場合、「溜める」解除。
        if (enemyChargeFlag == true)
        {
            EnemyChargeInvalid_1();
        }
    }

    //! 全キャラクターのリストから最前列のみのリストを新規作成する関数
    public List<PlayerChildTest> SelectTargetGroups_1(List<PlayerChildTest> characters)
    {
        //? 前列にいるキャラクターだけを含む新しいリストを作成
        List<PlayerChildTest> Groups = characters.Where(c => c.PlayerPosition <= 3).ToList();
        if (Groups.Count == 0)
        {
            //? 中列にいるキャラクターだけを含む新しいリストを作成
            Groups = characters.Where(c => c.PlayerPosition >= 4 && c.PlayerPosition <= 6).ToList();
        }
        if (Groups.Count == 0)
        {
            //? 後列にいるキャラクターだけを含む新しいリストを作成
            Groups = characters.Where(c => c.PlayerPosition >= 7 && c.PlayerPosition <= 9).ToList();
        }
        return Groups; //* toListで生成したいずれかのListを返す
    }

    //! 最前列内のランダムなキャラクタークラスを返す関数_ヘルパー関数
    private PlayerChildTest SelectCharacterFromRow_1(List<PlayerChildTest> Groups)
    {
        int minPlayerPosition = Groups.Min(c => c.PlayerPosition); //* 最前列リスト内の最小値を取得
        int maxPlayerPosition = Groups.Max(c => c.PlayerPosition); //* 最前列リスト内の最大値を取得
        while (true)
        {
            int randPlayerPosition = UnityEngine.Random.Range(minPlayerPosition, maxPlayerPosition + 1); //* 最小値と最大値の間で乱数を生成
            foreach (PlayerChildTest character in Groups)
            {
                if (character.PlayerPosition == randPlayerPosition) //* 生成した乱数がキャラクターの位置と一致する場合
                {
                    return character; //* 合致したキャラクタークラスを返す
                }
            }
        }
    }

    //! ParticleSystemの再生
    public void AttackParticleSystem()
    {
        particleObject = GetComponentInChildren<ParticleSystem>();
        particleObject.Play();
    }

    public void GetPos()
    {
        PlayerChildTest playerChildTest = GameObject.Find("Cube").GetComponent<PlayerChildTest>();
        Debug.Log(playerChildTest.transform.position);
    }

}