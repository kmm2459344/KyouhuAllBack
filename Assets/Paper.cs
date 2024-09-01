using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paper : MonoBehaviour
{
    ObstacleMaster es;
    private int Paper_Damage;

    GameObject PaperObj;

    // Start is called before the first frame update
    void Start()
    {
        PaperObj = GameObject.Find("Paper");
        es = Resources.Load("ObstacleMaster") as ObstacleMaster;
        Paper_Damage = es.sheets[0].list[0].Damage;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0.008f, 0, 0);

        //x軸が15以上になると消える
        if(transform.position.x > 15.0f)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneDirector.HP -= Paper_Damage;
            //Debug.Log(Paper_Damage);
        }

    }


}
