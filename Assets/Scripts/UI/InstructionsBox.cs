using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsBox : MonoBehaviour
{
    [SerializeField]
    private GameObject _instructions;
    
    // Start is called before the first frame update
    void Start()
    {
        _instructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _instructions.SetActive(false);
        }
    }
}
