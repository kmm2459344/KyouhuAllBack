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
        //�A�j���[�V�������擾
        anime = GetComponent<Animator>();
        myrigidbody = this.GetComponent<Rigidbody2D>();
        //�����ʒu
        transform.position = new Vector2(9.04f, -3.44f);
        //Debug.Log("Start: Rigidbody2D initialized");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = Vector2.zero;
        Vector2 pos = transform.position;

        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("�W�����v");
            anime.SetBool("Jump", true);
            myrigidbody.AddForce(transform.up * jumpForce);
            isGrounded = true;
        }
        else
        {
            anime.SetBool("Jump", false);

        }

        //�����L�[
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("��");
            force = new Vector2(playerSpeed * -1, 0);
        }
        //�E���L�[
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("�E");
            force = new Vector2(playerSpeed, 0);
        }

        myrigidbody.MovePosition(myrigidbody.position + force * Time.fixedDeltaTime);

    }

    // �n�ʂɐڐG�����Ƃ��̏���
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("�n�ʃC��");
        }
    }

    // �n�ʂ��痣�ꂽ�Ƃ��̏���
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("�n�ʃA�E�g");
        }
    }

    public void ButtonL ()
    {
        //Debug.Log("�{�^����");
        transform.Translate(-1.5f, 0, 0);
    }

    public void ButtonR()
    {
        //Debug.Log("�{�^���E");
        transform.Translate(1.5f, 0, 0);
    }
}
