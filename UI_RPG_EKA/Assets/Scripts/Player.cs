using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;
    private bool isShieldBroken = false;

    // Reference to the spell objects
    [SerializeField] private HealSpell healSpell;
    [SerializeField] private DamageBuffSpell damageBuffSpell;

    public string CharName
    {
        get { return charName; }
    }

    public bool Defend()
    {
        if (isShieldBroken)
        {
            Debug.Log("Shield is broken! Cannot defend.");
            return false;
        }

        Debug.Log("Player is defending...");
        if (Random.Range(1, 11) == 1)
        {
            isShieldBroken = true;
            Debug.Log("Shield is broken!");
        }

        return true;
    }

    public bool IsShieldBroken()
    {
        return isShieldBroken;
    }

    // Method to cast Heal Spell
    public void CastHealSpell()
    {
        if (healSpell != null)
        {
            healSpell.ApplyEffect(this);  
        }
        else
        {
            Debug.LogError("HealSpell is not assigned to the player.");
        }
    }

    // Method to cast Damage Buff Spell
    public void CastDamageBuffSpell()
    {
        if (damageBuffSpell != null)
        {
            damageBuffSpell.ApplyEffect(this); 
        }
        else
        {
            Debug.LogError("DamageBuffSpell is not assigned to the player.");
        }
    }
}
