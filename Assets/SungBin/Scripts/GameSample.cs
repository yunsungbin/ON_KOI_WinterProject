using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSample : MonoBehaviour
{
    //YellowGround
    public static bool yellowCheek = false;
    //greenGround
    public GameObject targetPosition;

    public static bool isPurple = false;
    public static float greenJumpTime;

    //Red
    public static bool BreakRed = false;

    //player
    public static float movePower = 5.0f;
    public static float jumpPower = 10.0f;
    public static int jumper = 1;

    Rigidbody2D rigid;
    public Animator anim;
    Vector3 movement;
    bool isJumping = false;
    public enum PlayerState
    {
        None, Walk, Jump, Get, BreakRed
    }
    public PlayerState playerState = PlayerState.None;
    //에니메이션
    private bool Left, Right = false;

    public enum PlayerColor
    {
        None, Blue, Red
    }
    public static PlayerColor playerColor = PlayerColor.None;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 start = new Vector3(-4.6f, -2.53f, 0);
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    public void PlayerMove()
    {
        Vector3 moveVelocity = Vector3.zero;
        switch (playerState)
        {

            case PlayerState.None:
                {
                    //if (MemoryAT.iRedAT == true || MemoryAT.iBlueAT == true)
                    //{
                    //    playerState = PlayerState.Get;
                    //}
                    if (RedBreak.RedArea == true && Input.GetKey(KeyCode.E))
                    {
                        playerState = PlayerState.BreakRed;
                        playerColor = PlayerColor.Red;
                    }
                    if (Right == true)
                    {
                        Right = false;
                        anim.SetTrigger("Wait");
                    }
                    if (Left == true)
                    {
                        Left = false;
                        anim.SetTrigger("LWait");
                    }
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                    {
                        playerState = PlayerState.Walk;
                    }
                    
                    break;
                }
            //player 이동
            case PlayerState.Walk:
                {
                    //if (MemoryAT.iRedAT == true || MemoryAT.iBlueAT == true)
                    //{
                    //    playerState = PlayerState.Get;
                    //}
                    
                    float h = Input.GetAxis("Horizontal");
                    if (Input.GetKey(KeyCode.A))
                    {
                        anim.SetTrigger("LWalk");
                        moveVelocity = Vector3.left;
                        transform.position += moveVelocity * movePower * Time.deltaTime;
                        if (RedBreak.RedArea == true && Input.GetKey(KeyCode.E))
                        {
                            playerState = PlayerState.BreakRed;
                            StartCoroutine(LBreak());
                        }
                    }

                    else if (Input.GetKey(KeyCode.D))
                    {
                        anim.SetTrigger("Walk");
                        moveVelocity = Vector3.right;
                        transform.position += moveVelocity * movePower * Time.deltaTime;
                        if (RedBreak.RedArea == true && Input.GetKey(KeyCode.E))
                        {
                            playerState = PlayerState.BreakRed;
                            StartCoroutine(RBreak());
                        }
                    }

                    if(Input.GetKeyUp(KeyCode.D))
                    {
                        anim.SetTrigger("Wait");
                        Right = true;
                        playerState = PlayerState.None;
                    }
                    else if (Input.GetKeyUp(KeyCode.A))
                    {
                        anim.SetTrigger("LWait");
                        Left = true;
                        playerState = PlayerState.None;
                    }
                    
                    break;
                }
            case PlayerState.Get:
                {
                    if(MemoryAT.iRedAT == true)
                    {
                        anim.SetTrigger("RGet");
                        anim.SetTrigger("Wait");
                        Right = true;
                        playerState = PlayerState.None;
                    }
                    else if(MemoryAT.iBlueAT == true)
                    {

                    }
                    break;
                }
            case PlayerState.BreakRed:
                {
                    movePower = 0;
                    jumpPower = 0;
                    break;
                }
        }
        switch (playerColor)
        {
            case PlayerColor.None:
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        playerColor = PlayerColor.Blue;
                    }
                    if(RedBreak.RedArea == true)
                    {
                        playerColor = PlayerColor.Red;
                    }
                    break;
                }
            case PlayerColor.Blue:
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        playerColor = PlayerColor.None;
                    }
                    break;
                }
            case PlayerColor.Red:
                {
                    if(Right == true)
                    {
                        StartCoroutine(RBreak());
                    }
                    if(Left == true)
                    {
                        StartCoroutine(LBreak());
                    }
                    break;
                }
        }

    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GCheek.IsGround == true)
        {
            rigid.AddForce(Vector2.up * jumpPower * 1.8f, ForceMode2D.Impulse);
            jumper--;
            if (jumper == 0)
            {
                GCheek.IsGround = false;
                jumper = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            movePower = 5;
            jumpPower = 10.0f;
        }
        if (collision.collider.CompareTag("YellowGround"))
        {
            jumpPower = 20;
            movePower = 10;
        }
        if (collision.collider.CompareTag("GreenGround"))
        {
            StartCoroutine(GreenJump());
        }
        if (collision.collider.CompareTag("PurpleGround"))
        {
            if(ColorBlocks.PurpleSpawn == false)
            {
                isPurple = true;
            }
            
        }
        if (collision.collider.CompareTag("Out"))
        {
            transform.position = new Vector3(-4.6f, -2.53f, 0);
        }
    }

    IEnumerator GreenJump()
    {
        float timer = 0;
        while (timer < greenJumpTime)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
            transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.2f, 0);
        }
        timer = 0;
    }

    IEnumerator RBreak()
    {
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("Break");
            movePower = 0;
            jumpPower = 0;
            yield return new WaitForSeconds(1);
            movePower = 5;
            jumpPower = 10.0f;
            playerColor = PlayerColor.None;
            anim.SetTrigger("Wait");
            playerState = PlayerState.None;
            StopCoroutine(RBreak());
        }
        
    }

    IEnumerator LBreak()
    {
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("LBreak");
            movePower = 0;
            jumpPower = 0;
            yield return new WaitForSeconds(1);
            movePower = 5;
            jumpPower = 10.0f;
            playerColor = PlayerColor.None;
            playerState = PlayerState.None;
            anim.SetTrigger("LWait");
            StopCoroutine(LBreak());
        }
        
    }
}
