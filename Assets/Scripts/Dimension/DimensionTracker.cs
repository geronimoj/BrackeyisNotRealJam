using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTracker : MonoBehaviour
{
    public bool inWorldA = true;

    private void Awake()
    {   //Make sure on correct layer
        SetDimension(true);
    }

    public void ToggleWorld()
    {
        inWorldA = !inWorldA;

        SetDimension(inWorldA);
    }

    public void SetDimension(bool worldA)
    {
        inWorldA = worldA;
        string world = inWorldA ? "WorldA" : "WorldB";
        gameObject.layer = LayerMask.NameToLayer(world);
    }
}
