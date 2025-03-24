using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Header("Beserker Agression")]
    [SerializeField] public int agression;  

    [Header("Horde Enemy Agression")]
    [SerializeField] public int hordeAmount;  

}
