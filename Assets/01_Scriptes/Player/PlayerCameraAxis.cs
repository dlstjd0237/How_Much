using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraAxis : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private Transform _camAxis;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _camRotMin = -30.0f;
    [SerializeField] private float _camRotMax = 80.0f;
    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        _mouseX = _camAxis.rotation.eulerAngles.y;
        _mouseY = _camAxis.rotation.eulerAngles.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotate();
    }

    private void CameraRotate()
    {
        float x = Input.GetAxis("Mouse X"); /*_input.XMouseInput*/; //���콺 �������� X ���� ������
        float y = Input.GetAxis("Mouse Y"); /*_input.YMouseInput*/; //���콺 �������� Y ���� ������

        _mouseX += x * _rotSpeed * Time.deltaTime; //���콺 x������ �����ؼ� ���.
        _mouseY += y * _rotSpeed * Time.deltaTime; //���콺 Y������ �����ؼ� ���.

        _mouseY = Mathf.Clamp(_mouseY, _camRotMin, _camRotMax); //�ִ� �ּ� ī�޶� Y ���� ����

        _camAxis.eulerAngles = new Vector3(-_mouseY, _mouseX, 0); //ī�޶� ȸ��

    }
}
