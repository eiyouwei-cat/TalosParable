using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    CinemachineVirtualCamera camera;
    private float fov = 0.0f;
    public int fovMinLimit = 25;
    public int fovMaxLimit = 75;
    public float fovSpeed = 50.0f;
    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        CameraFOV();
    }

    public void CameraFOV()
    {
        fov += -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100 * fovSpeed;
        fov = ClampValue(fov, fovMinLimit, fovMaxLimit);
        camera.m_Lens.FieldOfView = fov;
    }

    #region ClampValue
    float ClampValue(float value, float min, float max)
    {
        if (value < -360)
            value += 360;
        if (value > 360)
            value -= 360;
        return Mathf.Clamp(value, min, max);
    }
    #endregion
}
