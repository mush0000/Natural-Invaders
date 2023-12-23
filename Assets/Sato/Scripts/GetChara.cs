using System.Collections.Generic;
using UnityEngine;

public class GetChara : MonoBehaviour
{
    public List<GameObject> Get()
    {
        CharacterScript[] array = GetComponentsInChildren<CharacterScript>();
        List<GameObject> list = new List<GameObject>();
        foreach (CharacterScript c in array)
        {
            list.Add(c.gameObject);
        }
        return list;
    }
}