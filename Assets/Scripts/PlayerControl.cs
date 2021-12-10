using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Animator animator;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        animator = AnimatorControl.Instance.animator;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SwitchCollisionDetectionMode();
            GetComponent<PlayerCombat>().Attack();
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }
    void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        //Debug.Log(movement.sqrMagnitude);



        /* targetRotation = Quaternion.RotateTowards(
             transform.rotation,
             targetRotation,
             360*Time.deltaTime
             );*/
 
        if(movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(targetRotation);
            rb.MovePosition(transform.position + (movement * moveSpeed * Time.fixedDeltaTime));
        }
        
        
    }

   
   

   
}
