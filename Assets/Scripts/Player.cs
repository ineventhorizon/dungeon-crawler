using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    public Animator animator;
    Vector3 movement;
    float smooth = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
     
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SwitchCollisionDetectionMode();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }
    void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        Debug.Log(movement.sqrMagnitude);
        Quaternion targetRotation = Quaternion.LookRotation(movement);
       /* targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360*Time.deltaTime
            );*/
        if(movement.sqrMagnitude == 1)
        {
            rb.MoveRotation(targetRotation);
            rb.MovePosition(transform.position + (movement * moveSpeed * Time.fixedDeltaTime));
        }
        
        
    }

    //Detect when there is a collision starting
   /* void OnCollisionEnter(Collision collision)
    {
        //Ouput the Collision to the console
        Debug.Log("Collision : " + collision.gameObject.name);
    }

    //Detect when there is are ongoing Collisions
    void OnCollisionStay(Collision collision)
    {
        //Output the Collision to the console
        Debug.Log("Stay : " + collision.gameObject.name);
    }*/

    //Switch between the different Collision Detection Modes
    void SwitchCollisionDetectionMode()
    {
        switch (rb.collisionDetectionMode)
        {
            //If the current mode is continuous, switch it to continuous dynamic mode
            case CollisionDetectionMode.Continuous:
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                break;
            //If the current mode is continuous dynamic, switch it to continuous speculative
            case CollisionDetectionMode.ContinuousDynamic:
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
                break;

            // If the curren mode is continuous speculative, switch it to discrete mode
            case CollisionDetectionMode.ContinuousSpeculative:
                rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
                break;

            //If the current mode is discrete, switch it to continuous mode
            case CollisionDetectionMode.Discrete:
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                break;
        }
    }
}
