using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class test_Master : MonoBehaviour
{

    CharacterMaster es;
    ObstacleMaster es2;
    // Start is called before the first frame update
    void Start()
    {
        es = Resources.Load("CharacterMaster") as CharacterMaster;
        es2 = Resources.Load("ObstacleMaster") as ObstacleMaster;

        Debug.Log("ID�́F" + es.sheets[0].list[0].ID);
        Debug.Log("HpMax�́F" + es.sheets[0].list[0].HpMax);
        Debug.Log("HpMin�́F" + es.sheets[0].list[0].HpMin);
        Debug.Log("DistanceX�́F" + es.sheets[0].list[0].DistanceX);
        Debug.Log("DistanceY�́F" + es.sheets[0].list[0].DistanceY);
        Debug.Log("JumpTime�́F" + es.sheets[0].list[0].JumpTime);


        Debug.Log("ID1�̃_���[�W�́F" + es2.sheets[0].list[0].Damage);
        Debug.Log("ID2�̃_���[�W�́F" + es2.sheets[0].list[1].Damage);
        Debug.Log("ID3�̃_���[�W�́F" + es2.sheets[0].list[2].Damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
