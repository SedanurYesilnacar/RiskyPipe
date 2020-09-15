using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementJoystick : MonoBehaviour
{
    [SerializeField]private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField]private float _scaleSpeed = .1f;
    [SerializeField]private float _maxScale = .5f;
    [SerializeField]private float _minScale = .1f;

    [SerializeField] private Transform _startingPos;

    private Joystick _joystick;
    private float rotationY = 0;
    
    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, _speed * Time.fixedDeltaTime);
        ScaleIt(_joystick.Vertical);
        SetRotation();
    }
    private void SetRotation()
    {
        transform.localEulerAngles = Vector3.up * Mathf.LerpAngle(transform.localEulerAngles.y, rotationY, _rotationSpeed * Time.fixedDeltaTime * _speed);

    }

    private void ScaleIt(float v)
    {
        transform.localScale += new Vector3(v * _scaleSpeed, v * _scaleSpeed, v * _scaleSpeed);
        if (transform.localScale.x > _maxScale)
            transform.localScale = Vector3.one * _maxScale;
        if (transform.localScale.x < _minScale)
            transform.localScale = Vector3.one * _minScale;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("GameEnd"))
            transform.position = _startingPos.position;
        else if (collider.CompareTag("ReturnPipe"))
        {
            
            collider.enabled = false;
            rotationY = collider.transform.localScale.x * 90 + collider.transform.localEulerAngles.y;
            var endPoint = collider.gameObject.transform.Find("endPoint");
            Debug.Log(endPoint.transform.position);
            Debug.Log("Changing Rotation");
            Debug.Log(rotationY);
        }

    }
    


}
