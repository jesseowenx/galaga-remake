using UnityEngine;

public enum PowerupType
{
    ExtraLife,
    IncreasedSpeed,
    FasterShooting
}

public class Powerup : MonoBehaviour
{
    public PowerupType powerupType;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.PlaySound("Powerup");
            ApplyPowerup(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPowerup(GameObject player)
    {
        switch (powerupType)
        {
            case PowerupType.ExtraLife:
                player.GetComponent<PlayerLives>().IncreaseLives();
                break;

            case PowerupType.IncreasedSpeed:
                player.GetComponent<PlayerMovement>().moveSpeed += 1f;
                break;

            case PowerupType.FasterShooting:
                player.GetComponent<PlayerShoot>().amountOfFirePoints += 1;
                break;
        }
    }
}
