using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Human : MonoBehaviour
{
    [SerializeField] private string nameH;
    [SerializeField] private int age;

    public string NameH { get => nameH; set => nameH = value; }
    public int Age { get => age; set => age = value; }

    public void Initialize(string nameH, int age)
    {
        NameH = nameH;
        Age = age;
    }

    public void AisatsugaySamurai()
    {
        Debug.Log($"{nameH}({age})サン、どうもこんにちは。");
    }
}
