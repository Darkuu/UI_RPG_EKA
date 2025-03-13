using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon weapon;
    public Weapon Weapon
    {
        get { return weapon; }
    }

    public virtual int Attack()
    {
        return weapon.GetDamage();
    }

    public void GetHit(int damage)
    {
        Debug.Log("HEALTH: " + name + " Before :" + health);
        health -= damage;
        Debug.Log("HEALTH: " + name + " After :" + health);
    }

    public void GetHit(Weapon weapon)
    {
        Debug.Log("HEALTH: " + name + " Before :" + health);
        health -= weapon.GetDamage();
        Debug.Log("After getting hit by : " + weapon.name + " has health left: " + health);
    }
}
