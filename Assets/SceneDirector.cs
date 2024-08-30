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
    //ìG
    public GameObject prefabPaper;
    public GameObject prefabDog;
    public GameObject prefabBall;
    //public GameObject prefabDog;
    //public GameObject prefabBall;

    //BGM
    //public AudioSource BGM;

    //éûä‘
    public Text txtTimer;
    public Text txtHp;
    float timer = 30;
    float span = 1.0f;
    float delta = 0;

    //ëÃóÕ
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
            //éÜ
            GameObject Paper_go = Instantiate(prefabPaper);
            float py = Random.Range(-2.0f, 4.0f);
            Paper_go.transform.position = new Vector2(-10, py);

            //å¢
            //GameObject Dog_go = Instantiate(prefabDog);
            //Dog_go.transform.position = new Vector2(-15, -5);

            ////É{Å[Éã
            //GameObject Ball_go = Instantiate(prefabBall);
            //float py2 = Random.Range(5, 0);
            //Ball_go.transform .position = new Vector2(-10, py2);



        }

        //å¢
        GameObject Dog_go = Instantiate(prefabDog);

        //éûä‘Çå∏ÇÁÇ∑
        timer -= Time.deltaTime;
        txtTimer.text = "" + (int)timer;

        //HPï\é¶
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
