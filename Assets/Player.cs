using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    private Animator anime = null;

    private Rigidbody2D myrigidbody;
    private bool isGrounded = true;

    public float playerSpeed = 15;
    public float jumpForce = 30f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        //アニメーションを取得
        anime = GetComponent<Animator>();
        myrigidbody = this.GetComponent<Rigidbody2D>();
        //初期位置
        transform.position = new Vector2(9.04f, -3.44f);
        //Debug.Log("Start: Rigidbody2D initialized");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = Vector2.zero;
        Vector2 pos = transform.position;

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("ジャンプ");
            anime.SetBool("Jump", true);
            myrigidbody.AddForce(transform.up * jumpForce);
            isGrounded = true;
        }
        else
        {
            anime.SetBool("Jump", false);

        }

        //左矢印キー
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("左");
            force = new Vector2(playerSpeed * -1, 0);
        }
        //右矢印キー
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("右");
            force = new Vector2(playerSpeed, 0);
        }

        myrigidbody.MovePosition(myrigidbody.position + force * Time.fixedDeltaTime);

    }

    // 地面に接触したときの処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("地面イン");
        }
    }

    // 地面から離れたときの処理
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("地面アウト");
        }
    }

    public void ButtonL ()
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
