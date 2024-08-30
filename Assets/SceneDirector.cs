using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    //�G
    public GameObject prefabPaper;
    public GameObject prefabDog;
    public GameObject prefabBall;
    //public GameObject prefabDog;
    //public GameObject prefabBall;

    //BGM
    //public AudioSource BGM;

    //����
    public Text txtTimer;
    public Text txtHp;
    float timer = 30;
    float span = 1.0f;
    float delta = 0;

    //�̗�
    public static int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        //BGM = GetComponent<AudioSource>();
        //BGM.Play();



    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            //��
            GameObject Paper_go = Instantiate(prefabPaper);
            float py = Random.Range(-2.0f, 4.0f);
            Paper_go.transform.position = new Vector2(-10, py);

            //��
            //GameObject Dog_go = Instantiate(prefabDog);
            //Dog_go.transform.position = new Vector2(-15, -5);

            ////�{�[��
            //GameObject Ball_go = Instantiate(prefabBall);
            //float py2 = Random.Range(5, 0);
            //Ball_go.transform .position = new Vector2(-10, py2);



        }

        //��
        GameObject Dog_go = Instantiate(prefabDog);

        //���Ԃ����炷
        timer -= Time.deltaTime;
        txtTimer.text = "" + (int)timer;

        //HP�\��
        txtHp.text = "" + (int)HP;
        
        if(HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(timer < 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }

}
