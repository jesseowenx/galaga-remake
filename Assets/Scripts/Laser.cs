using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public int damage = 1;
    public GameObject asteroidExplosion;
    public GameObject bulletExplosion;

    [HideInInspector]
    public Vector2 shootDirection;
    private Rigidbody2D rb;
    private Score score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        rb.velocity = shootDirection.normalized * speed;
        Destroy(gameObject, lifeTime);

        score = FindAnyObjectByType<Score>();
        if (score == null)
        {
            Debug.LogWarning("Score script not found in the scene.");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            if (score != null)
            {
                score.AddEnemyScore();
                other.gameObject.GetComponent<Enemy>().TakeDamage();
            }

            if (bulletExplosion != null)
            {
                GameObject effect = Instantiate(bulletExplosion, transform.position, transform.rotation) as GameObject;
                Destroy(effect, 5f);
            }
        }
        else if (other.collider.CompareTag("Asteroid"))
        {
            if (score != null)
            {
                score.AddAsteroidScore();
            }

            if (asteroidExplosion != null)
            {
                GameObject effect = Instantiate(asteroidExplosion, transform.position, transform.rotation) as GameObject;
                Destroy(effect, 2f);
            }
        }
        else if (other.collider.CompareTag("Bullet"))
        {
            if (score != null)
            {
                score.AddBulletScore();
            }

            if (bulletExplosion != null)
            {
                GameObject effect = Instantiate(bulletExplosion, transform.position, transform.rotation) as GameObject;
                Destroy(effect, 2f);
            }
        }

        AudioManager.PlaySound("Explosion");
        Destroy(gameObject);
    }
}
