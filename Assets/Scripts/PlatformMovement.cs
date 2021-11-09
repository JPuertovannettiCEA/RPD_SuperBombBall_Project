using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private Vector3 _playerMoveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        _playerMoveInput = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.rotation = Quaternion.AngleAxis(45f,_playerMoveInput);
    }


}
