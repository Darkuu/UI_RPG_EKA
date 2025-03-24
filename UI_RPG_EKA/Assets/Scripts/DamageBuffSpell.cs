using UnityEngine;

public class DamageBuffSpell : Spell
{
    [SerializeField] private float damageMultiplier;  

    public override void ApplyEffect(Character target)
    {
        if (target is Player)  
        {
            Player player = target as Player;
            int currentMinDamage = player.Weapon.GetMinDamage();
            int currentMaxDamage = player.Weapon.GetMaxDamage();

            int newMinDamage = Mathf.CeilToInt(currentMinDamage * damageMultiplier);
            int newMaxDamage = Mathf.CeilToInt(currentMaxDamage * damageMultiplier);

            player.Weapon.SetDamage(newMinDamage, newMaxDamage);  

            Debug.Log(player.CharName + "'s damage is now increased by a factor of " + damageMultiplier + "!");
        }
    }
}

