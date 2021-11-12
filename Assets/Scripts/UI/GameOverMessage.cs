using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _message;

    [SerializeField]
    private GameObject _win;

    [SerializeField]
    private GameObject _lose;

    // Start is called before the first frame update
    void Start()
    {
        if(BoomBallController._win)
        {
            _win.gameObject.SetActive(true);
            _lose.gameObject.SetActive(false);
        }
        else
        {
            _win.gameObject.SetActive(false);
            _lose.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
