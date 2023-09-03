using BouncingBall;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<PlayerController>())
        {
            col.GetComponent<PlayerController>().GameOver();
        }
    }
}
