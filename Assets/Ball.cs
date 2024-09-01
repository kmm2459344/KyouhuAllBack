using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    ObstacleMaster es;
    private int Ball_Damage;

    GameObject PaperObj;
    // Start is called before the first frame update
    void Start()
    {
        es = Resources.Load("ObstacleMaster") as ObstacleMaster;
        Ball_Damage = es.sheets[0].list[1].Damage;

        PaperObj = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.008f, 0, 0);

        //xŽ²‚ª15ˆÈã‚É‚È‚é‚ÆÁ‚¦‚é
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
            SceneDirector.HP -= Ball_Damage;
            //Debug.Log(Ball_Damage);
        }

    }


}
