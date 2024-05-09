using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    new CinemachineVirtualCamera camera;
    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        CameraFOV();
    }

    #region FOV
    float fov = 0.0f;
    [Header("FOV")]
    [SerializeField]
    int fovMinLimit = 25;
    [SerializeField]
    int fovMaxLimit = 75;
    [SerializeField]
    float fovSpeed = 50.0f;
    public void CameraFOV()
    {
        fov += -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100 * fovSpeed;
        fov = ClampValue(fov, fovMinLimit, fovMaxLimit);
        camera.m_Lens.FieldOfView = fov;
    }
    #endregion

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
