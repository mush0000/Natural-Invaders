using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotEfct : MonoBehaviour
{
    public GameObject effect;

    public void ProduceEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
