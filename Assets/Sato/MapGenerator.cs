using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject waterTile;
    [SerializeField] GameObject grassTile;
    const int mapHeigt = 3;
    const int mapWidth = 3;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mapHeigt; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
