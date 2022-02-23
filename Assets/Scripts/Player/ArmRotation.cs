using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    Vector3 _mousePos;
    Player _player;
    Vector3 _rotVector;

    // Start is called before the first frame update
    void Start()
    {
        _player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _mousePos.z = 0;
        _rotVector = _mousePos - _player.transform.position;

        transform.right = _rotVector.normalized;
        //transform.eulerAngles = new Vector3(0, 0, )
    }
}
