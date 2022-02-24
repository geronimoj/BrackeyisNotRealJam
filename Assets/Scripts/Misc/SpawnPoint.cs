using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Player PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        if(Player.Instance != null)
        {
            Player.Instance.transform.position = gameObject.transform.position;
        }
        else
        {
            Instantiate(PlayerObj, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
