using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleRemove : MonoBehaviour
{
    public List<GameObject> purpleGround = new List<GameObject>();
    public int i;
    private float DTime = 0;
    public float WTime;

    private void Start()
    {
        DestroyBlocks();
    }
    private void Update()
    {
        if (ColorBlocks.pSpawn == true)
        {
            for(i = 0; i < int.MaxValue; i++)
            {
                purpleGround[i].SetActive(true);
            }
            i = 0;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float timer = 0;
        StartCoroutine(EnterPurpleBlocks());
        //Destroy(purpleGround, 0.5f);
        while (timer > 1)
        {
            timer += Time.deltaTime;

        }
        timer = 0;
        ColorBlocks.pSpawn = false;

    }

    public void DestroyBlocks()
    {
        while (DTime > WTime)
        {
            DTime += Time.deltaTime;

            if (DTime == WTime)
            {
                for (i = 0; i < 14; i++)
                {
                    purpleGround[i].gameObject.SetActive(false);
                }
                //Destroy(purpleGround, WTime);
                ColorBlocks.PurpleSpawn = false;
                DTime = 0;
            }
        }

    }

    IEnumerator EnterPurpleBlocks()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        i = 0;

        ColorBlocks.PurpleSpawn = false;
    }
}
