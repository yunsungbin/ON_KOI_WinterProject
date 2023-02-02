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
        None, Walk, Jump
    }
    public PlayerState playerState = PlayerState.None;
    //에니메이션
    private bool Left, Right = false;
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
        YellowCheek();
    }

    public void PlayerMove()
    {
        Vector3 moveVelocity = Vector3.zero;
        switch (playerState)
        {

            case PlayerState.None:
                {
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
                    float h = Input.GetAxis("Horizontal");
                    if (Input.GetKey(KeyCode.A))
                    {
                        anim.SetTrigger("LWalk");
                        moveVelocity = Vector3.left;
                        transform.position += moveVelocity * movePower * Time.deltaTime;
                    }

                    else if (Input.GetKey(KeyCode.D))
                    {
                        anim.SetTrigger("Walk");
                        moveVelocity = Vector3.right;
                        transform.position += moveVelocity * movePower * Time.deltaTime;
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
        }

    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GCheek.IsGround == true)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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
        if (collision.collider.CompareTag("YellowGround"))
        {
            yellowCheek = true;
            
            jumper = 1;
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

    void YellowCheek()
    {
        if(yellowCheek == false)
        {
            movePower = 5.0f;
            jumpPower = 10.0f;
        }
    }
}
