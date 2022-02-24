using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraWorldDisplayer : MonoBehaviour
{
    public LayerMask m_worldAMask;
    public LayerMask m_worldBMask;
    public LayerMask m_mirrorMask;

    private Camera _cam;
    private bool _inWorldA;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (_inWorldA != DimensionManager.s_inWorldA)
        {   
            //Only display current dimension
            if (DimensionManager.s_inWorldA)
                _cam.cullingMask = m_worldAMask;
            else
                _cam.cullingMask = m_worldBMask;

            _inWorldA = DimensionManager.s_inWorldA;
        }
    }
}
