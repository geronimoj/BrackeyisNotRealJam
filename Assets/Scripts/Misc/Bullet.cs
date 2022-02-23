using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player player;
    public float BulletSpeed;
    
    float timer;
    public float BulletLifespan = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        timer = BulletLifespan;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //Delete the bullet if it's existed too long
        if(timer <= 0)
        {
            Destroy(gameObject);
        }

        transform.position += transform.right * BulletSpeed * Time.deltaTime;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player"))
    //    {
    //        return;
    //    }
    //
    //    Destroy(gameObject);
    //}
}
