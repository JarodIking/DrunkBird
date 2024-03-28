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


    private LogicScript logic;

    public bool IsAlive { get; private set; }

    private const float UpperGameBoundry = 17f;
    private const float LowerGameBoundry = -17f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SetAlive();
    }

    void Update()
    {
        CheckOutOfBounds();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsAlive)
            RigidBody.velocity = Vector2.up * VelocityStrength;
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
