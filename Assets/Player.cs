using UnityEngine;

public class Player : MonoBehaviour
{
    //マスター
    CharacterMaster es;
    private int DistanceX = 0; //左右の移動距離
    private int DistanceY = 0; //ジャンプする高さ
    private int JumpTime = 0; //ジャンプして着地するまでのフレーム数

    private Animator anime = null;
    private Rigidbody2D myrigidbody;
    private bool isGrounded = true;

    public float playerSpeed = 15;
    public float jumpForce = 30f;

    void Start()
    {
        es = Resources.Load("CharacterMaster") as CharacterMaster;
        DistanceX = es.sheets[0].list[0].DistanceX; //マスターから左右の移動距離変更
        DistanceY = es.sheets[0].list[0].DistanceY; //マスターからジャンプする高さ変更
        JumpTime = es.sheets[0].list[0].JumpTime; //マスターからジャンプして着地するまでのフレーム数変更

        gameObject.tag = "Player";
        anime = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(9.04f, -3.44f);
    }

    void Update()
    {
        Vector2 force = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force = new Vector2(playerSpeed * -1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force = new Vector2(playerSpeed, 0);
        }

        myrigidbody.MovePosition(myrigidbody.position + force * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("ジャンプ");
            anime.SetBool("Jump", true);
            myrigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // ジャンプ後にisGroundedをfalseに設定
        }
        else
        {
            anime.SetBool("Jump", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("地面イン");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("地面アウト");
        }
    }

    public void ButtonL()
    {
        //Debug.Log("ボタン左");
        transform.Translate(-1.5f, 0, 0);
    }

    public void ButtonR()
    {
        //Debug.Log("ボタン右");
        transform.Translate(1.5f, 0, 0);
    }
}
