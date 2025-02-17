using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public GameObject explosion;
    public GameObject gameOverMenu;
    public TextMeshProUGUI livesText;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            DecreaseLives();
        }
    }

    public void DecreaseLives(int amount = 1)
    {
        animator.SetTrigger("TakeDamage");
        currentLives -= amount;

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            livesText.text = "x " + currentLives;
        }
    }

    public void IncreaseLives(int amount = 1)
    {
        currentLives += amount;
        livesText.text = "x " + currentLives;
    }

    private void GameOver()
    {
        gameOverMenu.SetActive(true);
        livesText.text = "x " + currentLives;
        if (explosion != null)
        {
            GameObject effect = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            Destroy(effect, 5f);
        }
        Destroy(gameObject);
    }
}
