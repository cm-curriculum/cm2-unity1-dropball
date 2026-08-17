using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Input Checking for left
        if (Input.GetKey("a"))
        {
            ApplyForceToReachVelocity(this.GetComponent<Rigidbody>(), Vector3.right * 5, 5);
        }      
        else if (Input.GetKey("d"))//Input Checking for right
        {
            ApplyForceToReachVelocity(this.GetComponent<Rigidbody>(), Vector3.left * 5, 5);
        }      
        else if (Input.GetKey("r")) //Input Checking for reset
        {
            resetBall();
        }
    }

    /*
    ResetBall: Resets the Position removes all physics from the ball
    */
    public void resetBall() 
    {
        transform.position = new Vector3(-8.6f, 40f, -30.5f);
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

    //Apply force to the ball to a certain Velocity
    public static void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force)
    {
            if (force == 0 || velocity.magnitude == 0)
                return;

            velocity = velocity + velocity.normalized * 0.2f * rigidbody.drag;

            //force = 1 => need 1 s to reach velocity (if mass is 1) => force can be max 1 / Time.fixedDeltaTime
            force = Mathf.Clamp(force, -rigidbody.mass / Time.fixedDeltaTime, rigidbody.mass / Time.fixedDeltaTime);

            //dot product is a projection from rhs to lhs with a length of result / lhs.magnitude https://www.youtube.com/watch?v=h0NJK4mEIJU
            if (rigidbody.velocity.magnitude == 0)
            {
                rigidbody.AddForce(velocity * force, mode);
            }
            else
            {
                var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
                rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
            }
    }
}
