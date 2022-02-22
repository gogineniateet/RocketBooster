using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    float rocketRotationSpeed;
    [SerializeField]
    float rocketThrustSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveRocketUp();
    }
    // method to move the rocket up
    private void MoveRocketUp()
    {
        RocketThrust();
        RocketRotate();
    }



    private void RocketRotate()
    {
        //  rb.freezeRotation = false;
        float speed = 100.00f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rocketRotationSpeed = speed * Time.deltaTime;
            transform.Rotate(Vector3.forward*rocketRotationSpeed);
            Debug.Log("Forward rotation");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rocketRotationSpeed = speed * Time.deltaTime;
            transform.Rotate(-Vector3.forward*rocketRotationSpeed);
            Debug.Log("Backward rotation");
        }
    }


    private void RocketThrust()
    {
        float speed = 100f;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rocketThrustSpeed = speed * Time.deltaTime;
            rb.AddRelativeForce(Vector3.up);
            Debug.Log("Going up");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }



}

