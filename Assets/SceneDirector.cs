using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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

    //BGM
    //public AudioSource BGM;

    //����
    public Text txtTimer;
    float timer = 29;

    //�̗�
    public int HP = 100;


    // Start is called before the first frame update
    void Start()
    {
        //BGM = GetComponent<AudioSource>();
        //BGM.Play();



    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ����炷
        timer -= Time.deltaTime;
        txtTimer.text = "" + (int)timer;

        
        if(HP < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(timer < 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }




}
