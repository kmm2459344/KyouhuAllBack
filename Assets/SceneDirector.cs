using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    //BGM
    //public AudioSource BGM;

    public Text txtTimer;

    float timer = 29;


    // Start is called before the first frame update
    void Start()
    {
        //BGM = GetComponent<AudioSource>();
        //BGM.Play();



    }

    // Update is called once per frame
    void Update()
    {


        //ŽžŒv
        timer -= Time.deltaTime;
        txtTimer.text = "" + (int)timer;
        if(timer < 0)
        {
            Debug.Log("I‚í‚è");
        }
    }




}
