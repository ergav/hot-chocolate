using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public bool player2Selected;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void SetPlayer1()
    {
        player2Selected = false;
    }

    public void SetPlayer2()
    {
        player2Selected = true;
    }

}
