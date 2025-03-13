using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int duration;
    //This is not good, replace it with min and max damage
    [SerializeField] private int damage;
    public override void ApplyEffect(Character target)
    {
        for (int i = 0; i < duration; i++)
        {
            Debug.Log(target.name + " got hit by posion for " + damage );
            target.GetHit(damage);
        }
    }
}
