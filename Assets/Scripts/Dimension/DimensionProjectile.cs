using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DimensionTracker))]
[RequireComponent(typeof(Collider))]
public class DimensionProjectile : MonoBehaviour
{
    public bool ignorePlayer = true;
    private DimensionTracker dt = null;

    private void Awake()
    {
        dt = GetComponent<DimensionTracker>();
    }

    public void SetDimension(bool worldA)
    {
        dt.SetDimension(worldA);
    }

    private void OnCollisionEnter(Collision collision)
    {   //Check if we should ignore the player
        if (ignorePlayer && collision.transform.CompareTag("Player"))
            return;
        //Attempt to get dimension tracker
        var tracker = collision.transform.gameObject.GetComponent<DimensionTracker>();
        //Toggle the world of the object
        if (tracker)
            tracker.ToggleWorld();
    }
}
