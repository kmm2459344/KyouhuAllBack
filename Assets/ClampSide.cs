using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampSide : MonoBehaviour
{
    // x軸方向の移動範囲の最小値
    [SerializeField] private float _minX = -11.65f;

    // x軸方向の移動範囲の最大値
    [SerializeField] private float _maxX = 10.80f;

    // y軸方向の移動範囲の最小値
    [SerializeField] private float _minY = -6.9f;

    // y軸方向の移動範囲の最大値
    [SerializeField] private float _maxY = 3.97f;

    private void Update()
    {
        var pos = transform.position;

        // x軸方向の移動範囲制限
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        // y軸方向の移動範囲制限
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;
    }
}
