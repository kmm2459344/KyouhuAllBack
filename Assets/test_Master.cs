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

        Debug.Log("IDは：" + es.sheets[0].list[0].ID);
        Debug.Log("HpMaxは：" + es.sheets[0].list[0].HpMax);
        Debug.Log("HpMinは：" + es.sheets[0].list[0].HpMin);
        Debug.Log("DistanceXは：" + es.sheets[0].list[0].DistanceX);
        Debug.Log("DistanceYは：" + es.sheets[0].list[0].DistanceY);
        Debug.Log("JumpTimeは：" + es.sheets[0].list[0].JumpTime);


        Debug.Log("ID1のダメージは：" + es2.sheets[0].list[0].Damage);
        Debug.Log("ID2のダメージは：" + es2.sheets[0].list[1].Damage);
        Debug.Log("ID3のダメージは：" + es2.sheets[0].list[2].Damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
