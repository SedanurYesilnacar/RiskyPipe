using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementTapAndHold : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float scaleSpeed = .1f;
    [SerializeField] private float maxScale = .5f;
    [SerializeField] private float minScale = .1f;
    float v = 0;
    bool control = false;
    private void FixedUpdate()
    {
        transform.Translate(0, 0, _speed * Time.fixedDeltaTime);
        if (Input.GetMouseButton(0))
        {
            if (!control)
                v = 0;
            v += Time.fixedDeltaTime;
            if (v > 1)
                v = 1;
            ScaleIt(v);
            control = true;
        }
        else
        {
            if (control)
                v = 0;
            control = false;
            v -= Time.fixedDeltaTime;
            if (v < -1)
                v = -1;
            ScaleIt(v);
        }
    }

    private void ScaleIt(float v)
    {
        transform.localScale += new Vector3(v * scaleSpeed, v * scaleSpeed, v * scaleSpeed);
        if (transform.localScale.x > maxScale)
            transform.localScale = Vector3.one * maxScale;
        if (transform.localScale.x < minScale)
            transform.localScale = Vector3.one * minScale;
    }
}
