using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Transform BulletSpawn = gameObject.transform;
            GameObject _bullet = Instantiate(Bullet, BulletSpawn.position + (BulletSpawn.localScale / 2), BulletSpawn.transform.rotation);
        }
    }
}
