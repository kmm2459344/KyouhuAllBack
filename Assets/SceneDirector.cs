using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDirector : MonoBehaviour
{
    // �G
    public GameObject prefabPaper;
    public GameObject prefabDog;
    private GameObject currentDog;
    public float dogSpeed = 3.0f;
    // �R���[�`���̎��s�t���O
    private bool isSpawning = false;

    public GameObject prefabBall;
    private GameObject currentBall;
    private bool isBallSpawning = false;
    private int ballCount = 0;

    // BGM
    // public AudioSource BGM;

    // ����
    public Text txtTimer;
    public Text txtHp;
    float timer = 30;
    float span = 1.0f;
    float delta = 0;

    // �̗�
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
        // ���Ԃ����炷
        timer -= Time.deltaTime;

        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            // �{�[�������̃��W�b�N�������ɒǉ�
            if (!isBallSpawning && (ballCount < 1 || (timer <= 10 && ballCount < 2)))
            {
                StartCoroutine(SpawnBall());
            }
        }

        // ���̐���
        if (!isPaperSpawning && paperCount < 2)
        {
            StartCoroutine(SpawnPaper());
        }

        // prefabDog���ړ�������
        if (currentDog == null && !isSpawning)
        {
            StartCoroutine(SpawnDog());
        }
        else if (currentDog != null)
        {
            currentDog.transform.Translate(Vector3.right * dogSpeed * Time.deltaTime);

            // x���̈ʒu��15�𒴂�����I�u�W�F�N�g���폜
            if (currentDog.transform.position.x > 15)
            {
                Destroy(currentDog);
                currentDog = null; // ���̃C���X�^���X�𐶐��ł���悤�ɂ���
            }
        }

        txtTimer.text = "" + (int)timer;

        // HP�\��
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
        float delay = Random.Range(3.0f, 7.0f); // 3�b����7�b�̃����_���ȑҋ@����
        yield return new WaitForSeconds(delay);
        currentDog = Instantiate(prefabDog);
        currentDog.transform.position = new Vector2(-16, -6); // �����ʒu��ݒ�
        isSpawning = false;
    }

    IEnumerator SpawnPaper()
    {
        isPaperSpawning = true;

        // 1�ڂ̎��𐶐�
        paper1 = Instantiate(prefabPaper);
        float py1 = Random.Range(-2.0f, 4.0f);
        paper1.transform.position = new Vector2(-10, py1);
        paperCount++;

        // 2����5�b�̃����_���ȑҋ@����
        float delay = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(delay);

        // 2�ڂ̎��𐶐�
        paper2 = Instantiate(prefabPaper);
        float py2 = Random.Range(-2.0f, 4.0f);
        paper2.transform.position = new Vector2(-10, py2);
        paperCount++;

        // 2�̎���x��15�𒴂��邩�A�v���C���[�ɐG���܂őҋ@
        while ((paper1 != null && paper1.transform.position.x <= 15) ||
               (paper2 != null && paper2.transform.position.x <= 15))
        {
            yield return null;
        }

        // ���̃J�E���g�����Z�b�g
        paperCount = 0;
        isPaperSpawning = false;
    }

    IEnumerator SpawnBall()
    {
        isBallSpawning = true;

        // �{�[���𐶐�
        currentBall = Instantiate(prefabBall);
        float py = Random.Range(-2.0f, 4.0f);
        currentBall.transform.position = new Vector2(-10, py);
        ballCount++;

        // �{�[����x��15�𒴂��邩�A�v���C���[�ɐG���܂őҋ@
        while (currentBall != null && currentBall.transform.position.x <= 15)
        {
            yield return null;
        }

        // �{�[���̃J�E���g�����Z�b�g
        ballCount = 0;
        isBallSpawning = false;
    }
}
