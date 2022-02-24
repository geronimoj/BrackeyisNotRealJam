using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// The class that checks and controls the player's actions
/// </summary>
public class Player : MonoBehaviour
{
    public static Player Instance;
    Rigidbody2D _playerRB;

    public Transform FeetPos;
    GroundCheck _groundCheck;
    bool _isGrounded;
    public bool IsGrounded
    {
        set
        {
            _isGrounded = value;
        }
    }

    public float JumpForce = 10;
    public float MoveSpeed = 5;
    int _moveInput;

    #region Start/Updates
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = (int)Input.GetAxisRaw("Horizontal");
        
        if (_playerRB.velocity.y > 0)
        {
            _isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerRB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _playerRB.velocity = new Vector2(_moveInput * MoveSpeed, _playerRB.velocity.y);
    }
    #endregion
}
