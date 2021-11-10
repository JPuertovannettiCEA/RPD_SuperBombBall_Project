using UnityEngine.SceneManagement;
using UnityEngine;

public class BoomBallController : MonoBehaviour
{
    [SerializeField]
    private float _lifeSpan = 30f;
    
    private void Awake()
    {
        Destroy(gameObject, _lifeSpan);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Flame"))
        {
            //Explosion particles
            Destroy(gameObject, 1f);
        }
        if(other.CompareTag("Goal"))
        {
            SceneManager.LoadScene(1);
        }
        if(other.CompareTag("Fuse"))
        {
            _lifeSpan += 5f;
        }
    }
}
