using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private float Speed = 4.0f;
    [SerializeField] private float _steeringTorque = 5.0f;
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (_input.YInput > -0.01f)
        {
            _rigidbody.AddForce(transform.forward * Speed * _input.YInput, ForceMode.Acceleration);
        }
        if (_input.XInput != 0)
        {
            float _modifier = _input.XInput;
            _modifier = Mathf.Clamp(_modifier, -1f, 1f);
            _rigidbody.AddRelativeTorque(new Vector3(0f, _steeringTorque, -_steeringTorque * 0.5f) * _modifier, ForceMode.Acceleration);
        }

    }
}

