using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyChild : CharacterScript
{
    new int enemyLife;
    protected int enemyAttack = 30;
    public int enemyMaxLife = 20;
    public bool enemyChargeFlag = false;
    // Start is called before the first frame update

    public void EnemyCharge()
    {
        enemyAttack *= 1 + (50 / 100); //!1.5倍 Float型ではなかったため整数で百分率で1.5倍
        enemyChargeFlag = true;
    }

    public void EnemyChargeInvalid()
    {
        enemyAttack /= 1 + (50 / 100); //!1.5倍の攻撃力を1.5で割っているためAtkを1倍に戻す
        enemyChargeFlag = false;
    }

    public void EnemySingleAttack(List<CharacterScript> characters)
    {
        List<CharacterScript> targetGroup = SelectTargetGroups(characters);
        CharacterScript targetCharacter = SelectCharacterFromRow(targetGroup);
        // targetCharacter.CharacterLife - (enemyAttack - targetCharacter.CharacterDaux);
    }

    public void EnemyGroupAttack(List<CharacterScript> characters)
    {
        List<CharacterScript> targetGroup = SelectTargetGroups(characters);
        foreach (CharacterScript Group in targetGroup)
        {
            Group.CharacterLife -= enemyAttack;
        }
    }

    // //! キャラクターのリストからターゲットを選択する関数
    // public CharacterScript SelectTarget(List<CharacterScript> characters)
    // {
    //     //? 前列にいるキャラクターだけを含む新しいリストを作成
    //     List<CharacterScript> frontRowCharacters = characters.Where(c => c.position <= 3).ToList();
    //     if (frontRowCharacters.Count > 0)
    //     {
    //         //? 前列にキャラクターがいる場合、その中から一つを選択
    //         return SelectCharacterFromRow(frontRowCharacters);
    //     }

    //     //? 中列にいるキャラクターだけを含む新しいリストを作成
    //     List<CharacterScript> middleRowCharacters = characters.Where(c => c.position >= 4 && c.position <= 6).ToList();
    //     if (middleRowCharacters.Count > 0)
    //     {
    //         //? 中列にキャラクターがいる場合、その中から一つを選択
    //         return SelectCharacterFromRow(middleRowCharacters);
    //     }

    //     //? 後列にいるキャラクターだけを含む新しいリストを作成
    //     List<CharacterScript> backRowCharacters = characters.Where(c => c.position >= 7 && c.position <= 9).ToList();
    //     if (backRowCharacters.Count > 0)
    //     {
    //         //? 後列にキャラクターがいる場合、その中から一つを選択
    //         return SelectCharacterFromRow(backRowCharacters);
    //     }
    //     return null; //* どの列にもキャラクターがいない場合、nullを返す
    // }
    // //! SelectTarget関数で生成された新リストの中身を元に乱数を確定し、ランダムなキャラクタークラスを返す関数。
    // //! posi[4,6]の場合で乱数が5を生成した場合は、合致しないが、無限ループで乱数を再生成させるため、いつか必ず合致する。
    // private CharacterScript SelectCharacterFromRow(List<CharacterScript> rowCharacters)
    // {
    //     int minPosition = rowCharacters.Min(c => c.position); //* 最小位置を取得
    //     int maxPosition = rowCharacters.Max(c => c.position); //* 最大位置を取得
    //     while (true)
    //     {
    //         int randPosition = UnityEngine.Random.Range(minPosition, maxPosition + 1); //* 最小位置と最大位置の間で乱数を生成
    //         foreach (CharacterScript character in rowCharacters)
    //         {
    //             if (character.position == randPosition) //* 生成した乱数がキャラクターの位置と一致する場合
    //             {
    //                 return character; //* そのキャラクターを返す
    //             }
    //         }
    //     }
    // }


    //! キャラクターのリストからターゲットを選択する関数
    public List<CharacterScript> SelectTargetGroups(List<CharacterScript> characters)
    {
        //? 前列にいるキャラクターだけを含む新しいリストを作成
        List<CharacterScript> Groups = characters.Where(c => c.position <= 3).ToList();
        if (Groups.Count == 0)
        {
            //? 中列にいるキャラクターだけを含む新しいリストを作成
            Groups = characters.Where(c => c.position >= 4 && c.position <= 6).ToList();
        }
        if (Groups.Count == 0)
        {
            //? 後列にいるキャラクターだけを含む新しいリストを作成
            Groups = characters.Where(c => c.position >= 7 && c.position <= 9).ToList();
        }
        return Groups;
    }
    //! SelectTargetGroups関数で生成された新リストの中身を元に乱数を確定し、ランダムなキャラクタークラスを返す関数。
    //! posi[4,6]の場合で乱数が5を生成した場合は、合致しないが、無限ループで乱数を再生成させるため、いつか必ず合致する。
    private CharacterScript SelectCharacterFromRow(List<CharacterScript> Groups)
    {
        int minPosition = Groups.Min(c => c.position); //* 最小位置を取得
        int maxPosition = Groups.Max(c => c.position); //* 最大位置を取得
        while (true)
        {
            int randPosition = UnityEngine.Random.Range(minPosition, maxPosition + 1); //* 最小位置と最大位置の間で乱数を生成
            foreach (CharacterScript character in Groups)
            {
                if (character.position == randPosition) //* 生成した乱数がキャラクターの位置と一致する場合
                {
                    return character; //* そのキャラクターを返す
                }
            }
        }
    }


}