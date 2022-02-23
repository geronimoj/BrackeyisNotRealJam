using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DimensionTracker))]
[RequireComponent(typeof(Collider2D))]
public class DimensionProjectile : MonoBehaviour
{
    public bool m_ignorePlayer = true;
    private DimensionTracker _dt = null;

    private void Awake()
    {
        _dt = GetComponent<DimensionTracker>();
    }

    public void SetDimension(bool worldA)
    {
        _dt.SetDimension(worldA);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //Check if we should ignore the player
        if (m_ignorePlayer && collision.transform.CompareTag("Player"))
            return;
        //Attempt to get dimension tracker
        var tracker = collision.transform.gameObject.GetComponent<DimensionTracker>();
        //Toggle the world of the object
        if (tracker)
            tracker.ToggleWorld();
        //Destroy the projectile
        Destroy(gameObject);
    }
}
