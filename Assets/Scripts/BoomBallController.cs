using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BoomBallController : MonoBehaviour
{
    [SerializeField]
    private float _lifeSpan = 30f;

    [SerializeField]
    private TMP_Text _lifeSpanText;

    private bool _isDead = false;

    private void Awake()
    {
        //Destroy(gameObject, _lifeSpan);
    }

    private void Update()
    {
        _lifeSpan -= Time.deltaTime;

        if (_isDead == false)
        {
            DisplayTime(_lifeSpan);
        }
        else
        {
            _lifeSpanText.text = "DEAD";
        }

        if (_lifeSpan <= 0f)
        {
            //PlayerController._win = true;
            _isDead = true;
            Destroy(gameObject);
            ChangeScene();
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _lifeSpanText.text = string.Format("Lifespan: {0:00}:{1:00}", minutes, seconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            //Explosion particles
            Destroy(other.gameObject);
            _isDead = true;
            Invoke("ChangeScene", 1f);
            Destroy(gameObject, 1f);
        }

        if (other.CompareTag("Goal"))
        {
            //WIN CONDITION HERE
            ChangeScene();
        }
        if (other.CompareTag("Fuse"))
        {
            _lifeSpan += 5f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Dead"))
        {
            //LOSE CONDITION HERE
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
