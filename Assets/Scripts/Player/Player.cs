using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// The class that checks and controls the player's actions
/// </summary>
public class Player : MonoBehaviour
{
    public static Player _instance;
    Rigidbody2D _playerRB;
    Camera _mCam;

    public LayerMask Ground;
    public Transform FeetPos;
    public float CheckRadius;
    bool _isGrounded;

    public float JumpForce = 10;
    public float MoveSpeed = 5;
    int _moveInput;

    #region Start/Updates
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //_mCam = Camera.main.GetComponent<MainCamera>();
        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = (int)Input.GetAxisRaw("Horizontal");

        _isGrounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, Ground);
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
