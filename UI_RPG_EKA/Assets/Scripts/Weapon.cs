using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;

    // Getter methods
    public int GetMinDamage() => minDamage;
    public int GetMaxDamage() => maxDamage;

    public int GetDamage()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }

    public void SetDamage(int newMinDamage, int newMaxDamage)
    {
        minDamage = newMinDamage;
        maxDamage = newMaxDamage;
    }

    public abstract void ApplyEffect(Character target);
}
