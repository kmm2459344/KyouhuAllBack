using UnityEngine;

public class Player : MonoBehaviour
{
    //�}�X�^�[
    CharacterMaster es;
    private int DistanceX = 0; //���E�̈ړ�����
    private int DistanceY = 0; //�W�����v���鍂��
    private int JumpTime = 0; //�W�����v���Ē��n����܂ł̃t���[����

    private Animator anime = null;
    private Rigidbody2D myrigidbody;
    private bool isGrounded = true;

    public float playerSpeed = 15;
    public float jumpForce = 30f;

    void Start()
    {
        es = Resources.Load("CharacterMaster") as CharacterMaster;
        DistanceX = es.sheets[0].list[0].DistanceX; //�}�X�^�[���獶�E�̈ړ������ύX
        DistanceY = es.sheets[0].list[0].DistanceY; //�}�X�^�[����W�����v���鍂���ύX
        JumpTime = es.sheets[0].list[0].JumpTime; //�}�X�^�[����W�����v���Ē��n����܂ł̃t���[�����ύX

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
            Debug.Log("�W�����v");
            anime.SetBool("Jump", true);
            myrigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // �W�����v���isGrounded��false�ɐݒ�
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
            Debug.Log("�n�ʃC��");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("�n�ʃA�E�g");
        }
    }

    public void ButtonL()
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
