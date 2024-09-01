using UnityEngine;

public class Dog : MonoBehaviour
{
    ObstacleMaster es;
    private int Dog_Damage;

    GameObject PaperObj;
    private bool isJump = false;
    private float jumpTime;
    private float jumpInterval;
    private bool hasJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        es = Resources.Load("ObstacleMaster") as ObstacleMaster;
        Dog_Damage = es.sheets[0].list[2].Damage;

        PaperObj = GameObject.Find("Dog");
        jumpInterval = Random.Range(1f, 5f); // ランダムなジャンプタイミングを設定
        jumpTime = Time.time + jumpInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasJumped && Time.time >= jumpTime)
        {
            Jump();
            hasJumped = true;
        }
    }

    void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            // ジャンプのロジック
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(0, 700)); // 上方向に力を加える
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneDirector.HP -= Dog_Damage;
            //Debug.Log(Dog_Damage);
        }
    }
}
