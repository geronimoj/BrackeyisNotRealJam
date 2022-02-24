using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTracker : MonoBehaviour
{
    public bool m_inWorldA = true;

    private void Awake()
    {   
        //Make sure on correct layer
        SetDimension(gameObject, true);

        ToggleChildren(true);
    }

    public void ToggleWorld()
    {
        m_inWorldA = !m_inWorldA;

        SetDimension(gameObject, m_inWorldA);
        ToggleChildren(m_inWorldA);
    }

    public void SetDimension(GameObject obj, bool worldA)
    {
        m_inWorldA = worldA;
        string world = m_inWorldA ? "WorldA" : "WorldB";
        obj.layer = LayerMask.NameToLayer(world);

        //Toggle the parent object to this world if it exists
        if(obj.transform.parent != null && obj.transform.parent.GetComponent<DimensionTracker>())
        {
            obj.transform.parent.gameObject.layer = obj.layer;
        }
    }

    /// <summary>
    /// Toggles all the child objects current dimension
    /// </summary>
    void ToggleChildren(bool worldA)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<DimensionTracker>())
            {
                SetDimension(child.gameObject, worldA);
            }
        }
    }
}
