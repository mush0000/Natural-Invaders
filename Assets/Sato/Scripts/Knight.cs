using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : CharacterScript
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        characterLife = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
