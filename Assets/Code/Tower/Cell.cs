using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BouncingBall
{
    /// <summary>
    /// Ячейка башни
    /// </summary>
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Transform topAttach;
        public Transform TopAttach => topAttach;


    }

}
