using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessTestScript : MonoBehaviour
{
    //This script is useless and for testing purposes only

    public float value;

    void Start()
    {
        Debug.Log("sin of " + value + " is " + Mathf.Sin(value));
        Debug.Log("tan of "+ value + " is " + Mathf.Tan(value));
        Debug.Log("cos of " + value + " is " + Mathf.Cos(value));

    }

    void Update()
    {
        
    }
}
