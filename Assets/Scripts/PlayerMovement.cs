using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    public float moveSpeed = 10f;
    public GameObject trail;
    public Transform smokePoint;
    private float nextSmokeTime;

    private void Awake()
    {
        input = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveSpeed * moveVector;
        if (nextSmokeTime <= Time.time)
        {
            nextSmokeTime = Time.time + 1f;
            if (trail != null)
            {
                GameObject effect = Instantiate(trail, smokePoint.position, transform.rotation) as GameObject;
                Destroy(effect, 2f);
            }
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction) + 270f;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public Vector2 GetShootDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction) + 0f;
        Vector2 shootDirection = Quaternion.Euler(0, 0, angle) * Vector2.right;
        return shootDirection;
    }

}