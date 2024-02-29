using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_input.YInput * 8, _rigidbody.velocity.y, _input.XInput * 8);
    }
}
