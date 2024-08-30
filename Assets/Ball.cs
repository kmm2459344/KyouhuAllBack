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
        //int xPos = -10;
        //float yPos = Random.Range(-2.0f, 4.0f);

        //Vector2 position = new Vector2(xPos, yPos);
        //Instantiate(PaperObj, position, Quaternion.identity);

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
            SceneDirector.HP -= 10;
            //Debug.Log(SceneDirector.HP);
        }

    }


}
