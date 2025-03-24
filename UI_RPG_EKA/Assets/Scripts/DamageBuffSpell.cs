using UnityEngine;

public class DamageBuffSpell : Spell
{
    [SerializeField] private float damageMultiplier;  // Multiplier to increase damage

    public override void ApplyEffect(Character target)
    {
        if (target is Player)  // Ensure it's applied to the player
        {
            Player player = target as Player;
            int currentMinDamage = player.Weapon.GetMinDamage();
            int currentMaxDamage = player.Weapon.GetMaxDamage();

            // Calculate the new damage after applying the multiplier
            int newMinDamage = Mathf.CeilToInt(currentMinDamage * damageMultiplier);
            int newMaxDamage = Mathf.CeilToInt(currentMaxDamage * damageMultiplier);

            // Apply the new damage values to the weapon
            player.Weapon.SetDamage(newMinDamage, newMaxDamage);  // Corrected: Now both parameters are passed

            Debug.Log(player.CharName + "'s damage is now increased by a factor of " + damageMultiplier + "!");
        }
    }
}

