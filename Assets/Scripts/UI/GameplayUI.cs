using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private PauseMenuUI _pauseMenu;

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
