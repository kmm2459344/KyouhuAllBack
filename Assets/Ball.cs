using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject PaperObj;
    // Start is called before the first frame update
    void Start()
    {
        PaperObj = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.008f, 0, 0);

        //x����15�ȏ�ɂȂ�Ə�����
        if (transform.position.x > 15.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneDirector.HP -= 10;
            //Debug.Log(SceneDirector.HP);
        }

    }


}
