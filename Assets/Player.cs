using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    private Rigidbody2D myrigidbody;

    public float playerSpeed = 15;


    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 force = Vector2.zero;
        Vector2 pos = transform.position;

        //�����L�[
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("��");
            force = new Vector2(playerSpeed * -1, 0);
        }
        //�E���L�[
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("�E");
            force = new Vector2(playerSpeed, 0);
        }

        myrigidbody.MovePosition(myrigidbody.position + force * Time.fixedDeltaTime);
    }
}
