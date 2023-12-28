using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Human : MonoBehaviour
{
    [SerializeField] private string humanName;
    [SerializeField] private int age;

    public string NameH { get => humanName; set => humanName = value; }
    public int Age { get => age; set => age = value; }

    public void Initialize(string humanName, int age)
    {
        NameH = humanName;
        Age = age;
    }

    public void AisatsugaySamurai()
    {
        Debug.Log($"{humanName}({age})サン、どうもこんにちは。");
    }
}
