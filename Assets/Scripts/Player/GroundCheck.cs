using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Player _player;

    void Start()
    {
        _player = Player.Instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && collision.gameObject.layer == _player.gameObject.layer)
        {
            _player.IsGrounded = true;
        }
    }
}
