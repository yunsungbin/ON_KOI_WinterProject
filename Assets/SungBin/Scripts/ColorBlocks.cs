using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlocks : MonoBehaviour
{
    public GameObject purpleGround;
    private int spawm = 8;
    public int pGSpawn;
    public static bool PurpleSpawn = false;
    Collision2D col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSample.isPurple == true)
        {
            int i = 0;
            while(spawm > i)
            {
                GameObject newBackGround = Instantiate(purpleGround);
                newBackGround.transform.position = new Vector3(gameObject.transform.localPosition.x + pGSpawn * i, gameObject.transform.localPosition.y, 0);
                i++;
            }
            GameSample.isPurple = false;
            PurpleSpawn = true;
        }
    }
}
