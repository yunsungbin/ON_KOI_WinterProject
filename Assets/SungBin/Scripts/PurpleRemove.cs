using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleRemove : MonoBehaviour
{
    public GameObject purpleGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float timer = 0;
        Destroy(purpleGround, 1.0f);
        while (timer > 1)
        {
            timer += Time.deltaTime;

        }
        timer = 0;
        ColorBlocks.PurpleSpawn = false;
    }
}
