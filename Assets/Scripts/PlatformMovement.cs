using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private Vector3 _playerMoveInput;

    //[SerializeField]
    public static float _angleaxis;


    [SerializeField]
    private GameObject _offset;

    [SerializeField]
    private GameObject _platform;

    private float h;
    private float v;

    // Start is called before the first frame update
    void Start()
    {
        _angleaxis = 45f;
        //_offset.transform.position = _offset.transform.position - _platform.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(_offset.transform.position.x, 0.38f, _offset.transform.position.z);
        /**if(transform.position.z >= 0 && _hasDecreased == false)
        {
            _angleaxis -= 10f;
            _hasDecreased = true;
        }
        if(transform.position.z >= 2 && _hasDecreased2 == false)
        {
            _angleaxis -= 10f;
            _hasDecreased2 = true;
        }**/
        //_platform.transform.position = transform.position;
        _playerMoveInput = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
        
        /**h = Input.GetAxis("Horizontal") * 50f;
        v = Input.GetAxis("Vertical") * 50f;

        _platform.GetComponent<Rigidbody>().AddTorque(transform.forward * h);
        _platform.GetComponent<Rigidbody>().AddTorque(transform.right * v);**/

        MovePlayer();
    }

    private void MovePlayer()
    {
        _platform.transform.rotation = Quaternion.Slerp(_platform.transform.rotation,Quaternion.AngleAxis(_angleaxis,_playerMoveInput), 1f * Time.deltaTime);
    }


}
