using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlocks : MonoBehaviour
{
    public enum ColorState
    {
        None, Purple, Green, Red
    }
    public ColorState colorState = ColorState.None;
    public GameObject purpleGround;
    private int spawm = 8;
    public int pGSpawn;
    public static bool PurpleSpawn = false;
    public static bool pSpawn = false;
    Collision2D col;

    public float windPower;

    private bool BreakRed = false;


    public List<GameObject> RedCheek = new List<GameObject>();
    private int redSum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (colorState)
        {
            case ColorState.Purple:
                {
                    
                    //gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0);
                    //if (GameSample.isPurple == true)
                    //{
                    //    int i = 0;
                    //    while (spawm > i)
                    //    {
                    //        GameObject newBackGround = Instantiate(purpleGround);
                    //        newBackGround.transform.position = new Vector3(gameObject.transform.localPosition.x + pGSpawn * i, gameObject.transform.localPosition.y, 0);
                    //        i++;
                    //    }
                    //    i = 0;
                    //    GameSample.isPurple = false;
                    //    PurpleSpawn = true;
                    //}
                    if (GameSample.isPurple == true)
                    {
                        GameSample.isPurple = false;
                        PurpleSpawn = true;
                        pSpawn = true;
                        
                    }
                    break;
                }
            case ColorState.Green:
                {
                    GameSample.greenJumpTime = windPower;
                    break;
                }
            case ColorState.Red:
                {
                    if(RedBreak.RedArea == true && Input.GetKey(KeyCode.E))
                    {
                        RedCheek[redSum].gameObject.SetActive(false);
                        redSum++;
                        RedBreak.RedArea = false;
                    }
                    break;
                }
        }
        
    }
}
