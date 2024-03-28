using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdControls : MonoBehaviour
{
    BirdScript birdScript;
    public Rigidbody2D rigidbody;
    public float VelocityStrength;

    private void Awake()
    {
        birdScript = GetComponent<BirdScript>();
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if(birdScript.IsAlive)
            rigidbody.velocity = Vector2.up * VelocityStrength;
    }
}
