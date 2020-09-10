using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementJoystick : MonoBehaviour
{
    [SerializeField]private float _speed = 5f;
    [SerializeField]private float _scaleSpeed = .1f;
    [SerializeField]private float _maxScale = .5f;
    [SerializeField]private float _minScale = .1f;

    [SerializeField] private Transform _startingPos;

    private Joystick _joystick;
    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, _speed * Time.fixedDeltaTime);
        ScaleIt(_joystick.Vertical);
    }

    private void ScaleIt(float v)
    {
        transform.localScale += new Vector3(v * _scaleSpeed, v * _scaleSpeed, v * _scaleSpeed);
        if (transform.localScale.x > _maxScale)
            transform.localScale = Vector3.one * _maxScale;
        if (transform.localScale.x < _minScale)
            transform.localScale = Vector3.one * _minScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("GameEnd"))
            transform.position = _startingPos.position;
    }

}
