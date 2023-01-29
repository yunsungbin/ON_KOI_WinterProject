using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSample : MonoBehaviour
{
    //greenGround
    public GameObject targetPosition;

    public static bool isPurple = false;
    public static float greenJumpTime;

    //Red
    public static bool BreakRed = false;

    //player
    public float movePower = 5.0f;
    public float jumpPower = 10.0f;
    public static int jumper = 1;

    Rigidbody2D rigid;
    Vector3 movement;
    bool isJumping = false;
    public enum PlayerState
    {
        None, Walk, Run
    }
    public PlayerState playerState = PlayerState.None;
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
        //player ¿Ãµø
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

        
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
}
