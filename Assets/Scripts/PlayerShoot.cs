using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    private PlayerControls input = null;
    private PlayerMovement playerMovement;
    public float laserSpeed = 10f;
    public float laserLifetime = 5f;
    public Transform[] firePoints;
    [HideInInspector]
    public int amountOfFirePoints = 1;

    private float lastFireTime;

    void Start()
    {
        input = new PlayerControls();
        input.Enable();

        input.Player.Shoot.performed += ctx => Fire();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Fire()
    {
        AudioManager.PlaySound("Player");
        Vector2 shootDirection = playerMovement.GetShootDirection();

        int firePointsUsed = 0;
        foreach (Transform firePoint in firePoints)
        {
            if (firePointsUsed >= amountOfFirePoints)
            {
                break;
            }
            Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
            GameObject laser = Instantiate(laserPrefab, firePoint.position, spawnRotation);
            laser.GetComponent<Laser>().shootDirection = shootDirection;
            firePointsUsed++;
        }
    }
}
