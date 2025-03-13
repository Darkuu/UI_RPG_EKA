using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beserker : Enemy
{
    [SerializeField] private int agressionGain = 10; 
    public override int Attack()
    {
        agression += agressionGain;
        return agression / 10;
    }
}
