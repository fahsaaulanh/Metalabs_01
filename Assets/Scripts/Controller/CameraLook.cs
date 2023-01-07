using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cinemachine;

    [Range(0, 10)]
    [SerializeField] private float lookSpeed;

    void Update()
    {
        Vector2 lookValue = InputManager.Instance.PlayerInput.PlayerMain.Look.ReadValue<Vector2>();
        _cinemachine.m_XAxis.Value = lookValue.x * 200 * lookSpeed * Time.deltaTime;
        _cinemachine.m_YAxis.Value = lookValue.y * lookSpeed * Time.deltaTime;
    }
}