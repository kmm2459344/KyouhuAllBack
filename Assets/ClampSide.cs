using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampSide : MonoBehaviour
{
    // x²•ûŒü‚ÌˆÚ“®”ÍˆÍ‚ÌÅ¬’l
    [SerializeField] private float _minX = -11.65f;

    // x²•ûŒü‚ÌˆÚ“®”ÍˆÍ‚ÌÅ‘å’l
    [SerializeField] private float _maxX = 10.80f;

    private void Update()
    {
        var pos = transform.position;

        // x²•ûŒü‚ÌˆÚ“®”ÍˆÍ§ŒÀ
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;
    }
}
