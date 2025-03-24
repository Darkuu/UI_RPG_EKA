using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHorde : Enemy
{
    [SerializeField] private int HordeAmount = 15;  
    [SerializeField] private int RegenRate = 1;  

    public override int Attack()
    {
        HordeAmount += RegenRate;
        int attackDamage = HordeAmount; 
        Debug.Log("Rat Horde attacks with " + attackDamage + " damage! Horde Size: " + HordeAmount);

        return attackDamage;
    }
}
