using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _message;

    // Start is called before the first frame update
    void Start()
    {
        if(BoomBallController._win)
        {
            _message.text = "You win!";
        }
        else
        {
            _message.text = "You lost!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
