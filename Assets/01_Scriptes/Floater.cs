using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float _depthBeforeSubmerged = 1.0f;
    [SerializeField] private float _displacementAmount = 3.0f;
    [SerializeField] private int _floaterCount = 1;
    [SerializeField] private float _waterDrag = 0.99f;
    [SerializeField] private float _waterAngularDrag = 0.5f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForceAtPosition(Physics.gravity / _floaterCount, transform.position, ForceMode.Acceleration);

        float waveHeight = WaveManager.Instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / _depthBeforeSubmerged) * _displacementAmount;
            _rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
            _rigidBody.AddForce(displacementMultiplier * -_rigidBody.velocity * _waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            _rigidBody.AddTorque(displacementMultiplier * -_rigidBody.angularVelocity * _waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
