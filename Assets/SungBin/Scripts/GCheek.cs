using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCheek : MonoBehaviour
{
    public static bool IsGround = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameSample.jumper = 1;
            IsGround = true;
        }
    }
    
}
