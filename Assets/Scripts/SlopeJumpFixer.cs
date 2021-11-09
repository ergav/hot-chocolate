using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeJumpFixer : MonoBehaviour
{
    public Player player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.canJumpNoMatterWhat = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.canJumpNoMatterWhat = false;
    }
}
