using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Character character;

    void Start()
    {
        
        enemy.Shout();
        player.Shout();
        character.Shout();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player name " + player.CharName);
    }
}
