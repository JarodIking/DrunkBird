using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float velocityStrength;

    private LogicScript Logic;
    
    public bool IsAlive { get; private set; }

    private const float UpperGameBoundry = 17f;
    private const float LowerGameBoundry = -17f;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SetAlive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBounds();
        PlayerMovement();
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
    
    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsAlive)
            rigidBody.velocity = Vector2.up * velocityStrength;
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
