using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon weapon;

    [SerializeField] private Sprite displayImage;  

    public Sprite DisplayImage
    {
        get { return displayImage; } 
    }

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
        health -= damage;
    }

    public void GetHit(Weapon weapon)
    {
        health -= weapon.GetDamage();
    }
}
