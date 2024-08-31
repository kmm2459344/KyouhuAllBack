using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampSide : MonoBehaviour
{
    // x�������̈ړ��͈͂̍ŏ��l
    [SerializeField] private float _minX = -11.65f;

    // x�������̈ړ��͈͂̍ő�l
    [SerializeField] private float _maxX = 10.80f;

    private void Update()
    {
        var pos = transform.position;

        // x�������̈ړ��͈͐���
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;
    }
}
