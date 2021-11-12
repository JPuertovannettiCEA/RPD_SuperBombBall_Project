using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{

    [SerializeField]
    private GameObject _credits;

    [SerializeField]
    private GameObject _mainMenu;

    private void Start()
    {
        PauseMenuUI._isPaused = false;
        Time.timeScale = 1f;
    }

    public void OnStart()
    {
        Invoke("PlayStart", 1f);
    }

    public void OnCredits()
    {
        _mainMenu.gameObject.SetActive(false);
        _credits.gameObject.SetActive(true);
    }
    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBack()
    {
        _mainMenu.gameObject.SetActive(true);
        _credits.gameObject.SetActive(false);
    }

    public void OnRestart()
    {
        Invoke("PlayStart", 1f);
    }

    private void PlayStart()
    {
        SceneManager.LoadScene(1);
    }
}
