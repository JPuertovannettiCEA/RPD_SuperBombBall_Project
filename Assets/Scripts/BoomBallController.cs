using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BoomBallController : MonoBehaviour
{
    public static bool _win;

    [SerializeField]
    private float _lifeSpan = 30f;

    [SerializeField]
    private TMP_Text _lifeSpanText;

    [SerializeField]
    private ParticleSystem _boomEffect;


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
            _win = false;
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
            _win = true;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            GetComponent<Collider>().material.bounciness = 1;
            GetComponent<Collider>().material.dynamicFriction = 0;
            GetComponent<Collider>().material.staticFriction = 0;
            //Debug.Log(GetComponent<Collider>().material.bounciness.ToString());
            //Debug.Log("COLLIDING");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            GetComponent<Collider>().material.bounciness = 0;
            GetComponent<Collider>().material.dynamicFriction = 0.6f;
            GetComponent<Collider>().material.staticFriction = 0.6f;
            //Debug.Log(GetComponent<Collider>().material.bounciness.ToString());
        }
    }


    private void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
}
