using UnityEngine;

public class HealSpell : Spell
{
    [SerializeField] private int healAmount;  

    public override void ApplyEffect(Character target)
    {
        Debug.Log(target.name + " is healed by " + healAmount + " HP.");
        target.health += healAmount;
    }
}
