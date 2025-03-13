using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Character character;

    [SerializeField] TMP_Text playerName, playerHealth, enemyName, enemyHealth;

    void Start()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        UpdateHealth();

    }

    private void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy.health.ToString();
    }


    public void DoRound()
    {
        // int damage = player.Attack();
        enemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(enemy);
        int enemydamage = enemy.Attack();
        player.GetHit(enemydamage);
        enemy.Weapon.ApplyEffect(player);
        UpdateHealth();

    }
}
