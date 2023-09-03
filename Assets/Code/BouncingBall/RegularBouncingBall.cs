using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBouncingBall : BouncingBallBase
{
    private float forceFactor = 5f;
    public override float ForceFactor { get => forceFactor; protected set => forceFactor = value; }

    private int attemptsNumber = 5;
    public override int AttemptsNumber { get => attemptsNumber; protected set => attemptsNumber = value; }
}
