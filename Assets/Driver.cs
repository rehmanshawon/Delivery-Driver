using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float boostSpeed = 15f;
   
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed *Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
