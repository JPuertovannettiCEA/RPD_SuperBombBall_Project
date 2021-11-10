using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BoomBallController : MonoBehaviour
{
    [SerializeField]
    private float _lifeSpan = 30f;

    [SerializeField]
    private TMP_Text _lifeSpanText;

    private void Awake()
    {
        //Destroy(gameObject, _lifeSpan);
    }

    private void Update()
    {
        _lifeSpan -= Time.deltaTime;

        DisplayTime(_lifeSpan);

        if (_lifeSpan <= 0f)
        {
            //PlayerController._win = true;
            Destroy(gameObject);
            SceneManager.LoadScene(1);
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
            Destroy(gameObject, 1f);
        }
        if (other.CompareTag("Goal"))
        {
            SceneManager.LoadScene(1);
        }
        if (other.CompareTag("Fuse"))
        {
            _lifeSpan += 5f;
        }
    }
}
