using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildTest : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int daux;
    [SerializeField] private int position;

    public int PlayerLife { get => life; set => life = value; }
    public int PlayerDaux { get => daux; set => daux = value; }
    public int PlayerPosition { get => position; set => position = value; }

    // 初期化メソッド
    public void Initialize(int life, int daux, int position)
    {
        PlayerLife = life;
        PlayerDaux = daux;
        PlayerPosition = position;
    }

    public override string ToString()
    {
        return $"Life: {PlayerLife}, Daux: {PlayerDaux}, Position: {PlayerPosition}";
    }
}
