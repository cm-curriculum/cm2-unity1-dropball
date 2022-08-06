using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBall : MonoBehaviour
{
    public void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<BallControl>().resetBall();
        }
    }
}
