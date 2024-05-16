using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 800f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] ParticleSystem groundEffectSystem;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }


    void Update()
    {
        handleInput();
        respondToBoost();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            groundEffectSystem.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        groundEffectSystem.Stop();
    }

    private void respondToBoost()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {

            surfaceEffector2D.speed = boostSpeed;

        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    void handleInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb2d.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }
}
