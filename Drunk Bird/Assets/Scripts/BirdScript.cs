using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{    
    public Rigidbody2D RigidBody;
    public float VelocityStrength;
    public InputAction PlayerControls;


    private LogicScript logic;
    private Vector2 moveDirection;

    public bool IsAlive { get; private set; }

    private const float UpperGameBoundry = 17f;
    private const float LowerGameBoundry = -17f;

    private void OnEnable()
    {
        PlayerControls.Enable();    
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SetAlive();
    }

    void Update()
    {
        CheckOutOfBounds();

        moveDirection = PlayerControls.ReadValue<Vector2>();
        if (IsAlive)
            RigidBody.velocity = new Vector2(moveDirection.x * VelocityStrength, moveDirection.y * VelocityStrength);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void CheckOutOfBounds()
    {
        switch (transform.position.y)
        {
            case > UpperGameBoundry:
                GameOver();
                break;

            case < LowerGameBoundry:
                GameOver();
                break;
        }
    }

    private void GameOver()
    {
        SetDead();
        logic.GameOver();
    }

    private void SetAlive()
    {
        IsAlive = true;
    }

    private void SetDead()
    {
        IsAlive = false;
    }
}
