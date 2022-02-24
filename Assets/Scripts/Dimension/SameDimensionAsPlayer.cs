using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameDimensionAsPlayer : DimensionTracker
{
    private void Update()
    {
        if (m_inWorldA != DimensionManager.s_inWorldA)
            SetDimension(gameObject, DimensionManager.s_inWorldA);
    }
}
