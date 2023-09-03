using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BouncingBallBase: MonoBehaviour
{
    public virtual float ForceFactor { get; protected set; }
    public virtual int AttemptsNumber { get; protected set; }
}
