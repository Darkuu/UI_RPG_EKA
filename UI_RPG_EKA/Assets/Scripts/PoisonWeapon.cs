using System.Collections;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int duration;

    public override void ApplyEffect(Character target)
    {
        target.StartCoroutine(ApplyPoisonOverTime(target));
    }

    private IEnumerator ApplyPoisonOverTime(Character target)
    {
        int turnsLeft = duration;
        while (turnsLeft > 0)
        {
            int damage = Random.Range(GetMinDamage(), GetMaxDamage() + 1);
            Debug.Log(target.name + " got poisoned for " + damage + " damage.");
            target.GetHit(damage);
            yield return new WaitForSeconds(10f);
            turnsLeft--;
        }

        Debug.Log(target.name + "'s poison has worn off.");
    }
}
