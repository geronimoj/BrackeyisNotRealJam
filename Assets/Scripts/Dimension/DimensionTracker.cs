using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTracker : MonoBehaviour
{
    public bool m_inWorldA = true;
    private bool _isPlayer = false;

    private void Awake()
    {
        _isPlayer = GetComponent<Player>() != null;
        //Make sure on correct layer
        SetDimension(gameObject, m_inWorldA);

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
        //If player, track player dimension
        if (_isPlayer)
            DimensionManager.s_inWorldA = worldA;
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
