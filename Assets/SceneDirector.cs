using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDirector : MonoBehaviour
{
    // 敵
    public GameObject prefabPaper;
    public GameObject prefabDog;
    private GameObject currentDog;
    public float dogSpeed = 3.0f;
    // コルーチンの実行フラグ
    private bool isSpawning = false;

    public GameObject prefabBall;
    private GameObject currentBall;
    private bool isBallSpawning = false;
    private int ballCount = 0;

    // BGM
    // public AudioSource BGM;

    // 時間
    public Text txtTimer;
    public Text txtHp;
    float timer = 30;
    float span = 1.0f;
    float delta = 0;

    // 体力
    public static int HP = 100;

    private bool isPaperSpawning = false;
    private int paperCount = 0;
    private GameObject paper1;
    private GameObject paper2;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        // BGM = GetComponent<AudioSource>();
        // BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間を減らす
        timer -= Time.deltaTime;

        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            // ボール生成のロジックをここに追加
            if (!isBallSpawning && (ballCount < 1 || (timer <= 10 && ballCount < 2)))
            {
                StartCoroutine(SpawnBall());
            }
        }

        // 紙の生成
        if (!isPaperSpawning && paperCount < 2)
        {
            StartCoroutine(SpawnPaper());
        }

        // prefabDogを移動させる
        if (currentDog == null && !isSpawning)
        {
            StartCoroutine(SpawnDog());
        }
        else if (currentDog != null)
        {
            currentDog.transform.Translate(Vector3.right * dogSpeed * Time.deltaTime);

            // x軸の位置が15を超えたらオブジェクトを削除
            if (currentDog.transform.position.x > 15)
            {
                Destroy(currentDog);
                currentDog = null; // 次のインスタンスを生成できるようにする
            }
        }

        txtTimer.text = "" + (int)timer;

        // HP表示
        txtHp.text = "" + (int)HP;

        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (timer < 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }

    IEnumerator SpawnDog()
    {
        isSpawning = true;
        float delay = Random.Range(3.0f, 7.0f); // 3秒から7秒のランダムな待機時間
        yield return new WaitForSeconds(delay);
        currentDog = Instantiate(prefabDog);
        currentDog.transform.position = new Vector2(-16, -6); // 初期位置を設定
        isSpawning = false;
    }

    IEnumerator SpawnPaper()
    {
        isPaperSpawning = true;

        // 1つ目の紙を生成
        paper1 = Instantiate(prefabPaper);
        float py1 = Random.Range(-2.0f, 4.0f);
        paper1.transform.position = new Vector2(-10, py1);
        paperCount++;

        // 2から5秒のランダムな待機時間
        float delay = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(delay);

        // 2つ目の紙を生成
        paper2 = Instantiate(prefabPaper);
        float py2 = Random.Range(-2.0f, 4.0f);
        paper2.transform.position = new Vector2(-10, py2);
        paperCount++;

        // 2つの紙がx軸15を超えるか、プレイヤーに触れるまで待機
        while ((paper1 != null && paper1.transform.position.x <= 15) ||
               (paper2 != null && paper2.transform.position.x <= 15))
        {
            yield return null;
        }

        // 紙のカウントをリセット
        paperCount = 0;
        isPaperSpawning = false;
    }

    IEnumerator SpawnBall()
    {
        isBallSpawning = true;

        // ボールを生成
        currentBall = Instantiate(prefabBall);
        float py = Random.Range(-2.0f, 4.0f);
        currentBall.transform.position = new Vector2(-10, py);
        ballCount++;

        // ボールがx軸15を超えるか、プレイヤーに触れるまで待機
        while (currentBall != null && currentBall.transform.position.x <= 15)
        {
            yield return null;
        }

        // ボールのカウントをリセット
        ballCount = 0;
        isBallSpawning = false;
    }
}
