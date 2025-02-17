using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public GameObject bulletExplosion;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        transform.eulerAngles = transform.eulerAngles - (Vector3.forward * 90f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerLives playerLives = other.gameObject.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                playerLives.DecreaseLives(damage);
            }

        }
        else if (other.collider.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage();
        }

        if (bulletExplosion != null)
        {
            GameObject effect = Instantiate(bulletExplosion, transform.position, transform.rotation) as GameObject;
            Destroy(effect, 2f);
        }
        AudioManager.PlaySound("Explosion");
        Destroy(gameObject);
    }
}
