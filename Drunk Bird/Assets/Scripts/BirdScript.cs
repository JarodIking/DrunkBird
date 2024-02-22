using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    [SerializeField] InputActionReference jumpInput;
    
    public Rigidbody2D rigidBody;
    public float velocityStrength;

    private LogicScript Logic;
    
    public bool IsAlive { get; private set; }

    private const float UpperGameBoundry = 17f;
    private const float LowerGameBoundry = -17f;

    private void Awake()
    {
        jumpInput.action.performed += OnJump;
    }


    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SetAlive();
    }

    void Update()
    {
        CheckOutOfBounds();
    }

    private void OnDestroy()
    {
        jumpInput.action.performed -= OnJump;

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsAlive)
            rigidBody.velocity = Vector2.up * velocityStrength;
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
        Logic.GameOver();
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
