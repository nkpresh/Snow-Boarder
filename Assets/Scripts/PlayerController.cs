using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float torqueAmount = 1;
    [SerializeField]
    float boostSpeed = 70;
    [SerializeField]
    float baseSpeed = 50;
    Rigidbody2D rgdBody;
    SurfaceEffector2D surfaceEffector;

    bool canMove = false;
    void Start()
    {
        rgdBody = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgdBody.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rgdBody.AddTorque(-torqueAmount);
        }
    }
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector.speed = baseSpeed;
        }
    }
}
