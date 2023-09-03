using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BouncingBall
{
    /// <summary>
    /// Зона, за которую нельзя ухватиться
    /// </summary>
    public class DangerArea : MonoBehaviour
    {
        [SerializeField] private float damage = 0f;
    }
}