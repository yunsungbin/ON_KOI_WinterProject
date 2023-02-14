using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlocks : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public enum ColorState
    {
        None, Purple, Green, Red, Yellow, Blue
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

    Vector3 bluePos;
    // Start is called before the first frame update
    void Start()
    {
        bluePos = this.transform.position;
        redSum = 0;
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
                        ParticleSystem pc = Instantiate(particle);
                        pc.transform.position = RedCheek[redSum].gameObject.transform.position;
                        pc.Play();
                        RedBreak.RedArea = false;
                    }
                    break;
                }
            case ColorState.Yellow:
                {
                    if(GameSample.yellowCheek == true)
                    {
                        GameSample.jumpPower = 20;
                        GameSample.movePower = 10;
                        
                    }
                    if (GCheek.groundCH == true)
                    {
                        GameSample.jumpPower = 10;
                        GameSample.movePower = 5;
                    }

                    break;
                }
            case ColorState.Blue:
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    break;
                }
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player") && colorState == ColorState.Yellow)
        {
            GameSample.jumper = 1;
            GCheek.IsGround = true;
            GCheek.groundCH = false;
            GameSample.yellowCheek = true;
        }
        if(collision.collider.CompareTag("Player") && colorState == ColorState.Blue && GameSample.CHblue == false)
        {
            StartCoroutine(TimeBlue());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && colorState == ColorState.Yellow)
        {
            GCheek.groundCH = true;
        }
        if (collision.collider.CompareTag("Player") && colorState == ColorState.Blue)
        {
            StopCoroutine(TimeBlue());
        }
    }

    IEnumerator TimeBlue()
    {
        transform.position = new Vector3(bluePos.x, bluePos.y, 0);
        yield return null;
        if(GameSample.CHblue == true)
        {
            StopCoroutine(TimeBlue());
        }
        else if(GameSample.CHblue == false)
        {
            StartCoroutine(TimeBlue());
        }
        
    }
}
