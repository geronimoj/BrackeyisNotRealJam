using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTracker : MonoBehaviour
{
    public bool m_inWorldA = true;

    private void Awake()
    {   //Make sure on correct layer
        SetDimension(true);
    }

    public void ToggleWorld()
    {
        m_inWorldA = !m_inWorldA;

        SetDimension(m_inWorldA);
    }

    public void SetDimension(bool worldA)
    {
        m_inWorldA = worldA;
        string world = m_inWorldA ? "WorldA" : "WorldB";
        gameObject.layer = LayerMask.NameToLayer(world);
    }
}
