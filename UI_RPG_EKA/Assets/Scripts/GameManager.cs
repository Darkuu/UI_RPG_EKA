using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Object References")]
    [Tooltip("Reference the player and enemy objects.")]
    public Player player;
    public Enemy enemy;

    public GameObject[] possibleEnemies;

    [Tooltip("Player & Enemy UI elements, that appear on the UI.")]
    [SerializeField] TMP_Text playerName, playerHealth, enemyName, enemyHealth;
    [SerializeField] private Image enemyImage, playerImage;

    [Header("UI buttons")]
    [Tooltip("UI buttons for doing actions.")]
    [SerializeField] private Button attackButton, defendButton, healButton, damageBuffButton;

    [Header("Shield UI")]
    [Tooltip("UI Text to show shield status.")]
    [SerializeField] TMP_Text shieldStatusText;

    [Header("Game Over UI")]
    [SerializeField] GameObject gameOverUI;  // The Game Over UI panel

    private int Defendvalue = 2;

    // Turn counter to track turns since last spell cast
    private int turnsSinceHealOrBuff = 0;
    private int turnsBeforeCanUseAgain = 2;  // Time before buttons can be used again after a spell is cast

    void Start()
    {
        // Spawn the first enemy randomly
        SpawnNewEnemy();

        playerName.text = player.CharName;
        enemyName.text = enemy.name;

        enemyImage.sprite = enemy.DisplayImage;
        playerImage.sprite = player.DisplayImage;

        attackButton.onClick.AddListener(OnAttackButtonClicked);
        defendButton.onClick.AddListener(OnDefendButtonClicked);
        healButton.onClick.AddListener(OnHealButtonClicked);
        damageBuffButton.onClick.AddListener(OnDamageBuffButtonClicked);

        UpdateHealth();
        UpdateShieldStatus();
        gameOverUI.SetActive(false);  // Hide Game Over UI at the start
    }

    private void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy.health.ToString();
    }

    private void OnAttackButtonClicked()
    {
        Debug.Log("Player is Attacking");
        DoAttack();
    }

    private void OnDefendButtonClicked()
    {
        Debug.Log("Player is Defending with a shield");
        DoDefend();
    }

    private void OnHealButtonClicked()
    {
        Debug.Log("Player is Healing");
        player.CastHealSpell();  
        DisableSpellButtons();
        UpdateHealth();
    }

    private void OnDamageBuffButtonClicked()
    {
        Debug.Log("Player is Buffing Damage");
        player.CastDamageBuffSpell();  
        DisableSpellButtons();
        UpdateHealth();
    }


    private void DisableSpellButtons()
    {
        healButton.interactable = false;
        damageBuffButton.interactable = false;
        healButton.GetComponent<Image>().color = Color.gray;  
        damageBuffButton.GetComponent<Image>().color = Color.gray;  
    }

    private void EnableButtons()
    {
        healButton.interactable = true;
        damageBuffButton.interactable = true;
        healButton.GetComponent<Image>().color = Color.white; 
        damageBuffButton.GetComponent<Image>().color = Color.white;  
    }

    private void DoAttack()
    {
        Debug.Log("Attacking");
        enemy.GetHit(player.Weapon.GetDamage());
        player.Weapon.ApplyEffect(enemy);

        int enemyDamage = enemy.Attack();
        player.GetHit(enemyDamage);
        enemy.Weapon.ApplyEffect(player);

        UpdateHealth();

        // Check if enemy is dead and spawn a new one & reset spells
        if (enemy.health <= 0)
        {
            EnableButtons();
            SpawnNewEnemy();
        }

        // Check if player is dead
        if (player.health <= 0)
        {
            GameOver();
        }
    }

    private void DoDefend()
    {
        Debug.Log("Player is defending");

        bool shieldIsStillActive = player.Defend();
        if (!shieldIsStillActive)
        {
            DisableDefendButton();
        }

        int enemyDamage = enemy.Attack() / Defendvalue;
        player.GetHit(enemyDamage);

        UpdateHealth();
        UpdateShieldStatus();

        // Check if enemy is dead and spawn a new one
        if (enemy.health <= 0)
        {
            SpawnNewEnemy();
        }

        // Check if player is dead
        if (player.health <= 0)
        {
            GameOver();
        }
    }

    private void DisableDefendButton()
    {
        Debug.Log("Shield is broken. Disabling Defend button.");
        defendButton.interactable = false;
    }

    private void UpdateShieldStatus()
    {
        if (player.IsShieldBroken())
        {
            shieldStatusText.text = "Shield Broken!";
            shieldStatusText.color = Color.red;
        }
        else
        {
            shieldStatusText.text = "Shield Active";
            shieldStatusText.color = Color.green;
        }
    }

    private void SpawnNewEnemy()
    {
        int randomIndex = Random.Range(0, possibleEnemies.Length);
        GameObject newEnemy = Instantiate(possibleEnemies[randomIndex]);

        enemy = newEnemy.GetComponent<Enemy>();
        enemyName.text = enemy.name;
        enemyImage.sprite = enemy.DisplayImage;
        Debug.Log("A new enemy has spawned!");
        UpdateHealth();
    }

    private void GameOver()
    {
        Debug.Log("Player has died!");
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
