using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraWorldDisplayer : MonoBehaviour
{
    public LayerMask worldAMask;
    public LayerMask worldBMask;

    private Camera cam;
    private bool inWorldA;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (inWorldA != DimensionManager.inWorldA)
        {   //Only display current dimension
            if (DimensionManager.inWorldA)
                cam.cullingMask = worldAMask;
            else
                cam.cullingMask = worldBMask;

            inWorldA = DimensionManager.inWorldA;
        }
    }
}
