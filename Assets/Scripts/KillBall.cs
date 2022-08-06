using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBall : MonoBehaviour
{
    public void OnCollisionEnter(Collision other) 
    {
        other.gameObject.GetComponent<BallControl>().resetBall();
    }
}
