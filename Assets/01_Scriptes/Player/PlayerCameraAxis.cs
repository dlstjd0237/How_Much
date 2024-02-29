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
        float x = Input.GetAxis("Mouse X"); /*_input.XMouseInput*/; //마우스 포지션의 X 값을 가져옴
        float y = Input.GetAxis("Mouse Y"); /*_input.YMouseInput*/; //마우스 포지션의 Y 값을 가져옴

        _mouseX += x * _rotSpeed * Time.deltaTime; //마우스 x각도를 누적해서 계산.
        _mouseY += y * _rotSpeed * Time.deltaTime; //마우스 Y각도를 누적해서 계산.

        _mouseY = Mathf.Clamp(_mouseY, _camRotMin, _camRotMax); //최대 최소 카메라 Y 각도 제한

        _camAxis.eulerAngles = new Vector3(-_mouseY, _mouseX, 0); //카메라 회전

    }
}
