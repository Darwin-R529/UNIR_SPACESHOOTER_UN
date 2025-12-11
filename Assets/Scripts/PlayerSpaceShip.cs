using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceShip : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 300f;

    [Header("Shooting")]
    [SerializeField] GameObject proyectilePrefab;
    [SerializeField] GameObject SpawnShootPosition;

    [Header("Controls")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += onMove;
        move.action.performed += onMove;
        move.action.canceled += onMove;

        shoot.action.started += onShoot;
        // shoot.action.performed += onShoot;
        // shoot.action.canceled += onShoot;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveThresholdForBrake = 0.1f;
    void Update()
    {

        if (rawMove.magnitude < rawMoveThresholdForBrake)
        {
            currentVelocity *= 1f * Time.deltaTime;
        }

        currentVelocity += rawMove * acceleration * Time.deltaTime; // m/s^2 * s = m/s

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;

        transform.Translate(currentVelocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();

        move.action.started -= onMove;
        move.action.performed -= onMove;
        move.action.canceled -= onMove;

        shoot.action.started -= onShoot;
    }


    Vector2 rawMove;
    private void onMove(InputAction.CallbackContext obj)
    {
        rawMove = obj.ReadValue<Vector2>();
    }

    private void onShoot(InputAction.CallbackContext obj)
    {
        Instantiate(proyectilePrefab, SpawnShootPosition.transform.position, Quaternion.identity);
    }
}
