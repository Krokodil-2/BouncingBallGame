using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BouncingBall
{
    public class Base : MonoBehaviour
    {
        [SerializeField] private Transform attach;
        public Transform Attach =>  attach;

    }
}