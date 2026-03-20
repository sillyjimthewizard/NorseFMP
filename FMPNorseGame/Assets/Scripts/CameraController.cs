using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public CinemachineOrbitalFollow CameraOrbit;
    public CinemachineInputAxisController Inputcontroller;
    public bool CanZoom;

    public int CameraOrbitMax;
    public int CameraOrbitMin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraOrbit = this.GetComponent<CinemachineOrbitalFollow>();
        Inputcontroller = this.GetComponent<CinemachineInputAxisController>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanZoom == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && CameraOrbit.Radius >= CameraOrbitMax && CameraOrbit.Radius <= CameraOrbitMin) // forward
            {
                CameraOrbit.Radius++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f && CameraOrbit.Radius <= CameraOrbitMin && CameraOrbit.Radius >= CameraOrbitMax) // Backward
            {
                CameraOrbit.Radius--;
            }
        }

        if (CameraOrbit.Radius < CameraOrbitMax)
        {
            CameraOrbit.Radius = CameraOrbitMax;
        }

        if (CameraOrbit.Radius > CameraOrbitMin)
        {
            CameraOrbit.Radius = CameraOrbitMin;
        }
    }
}
