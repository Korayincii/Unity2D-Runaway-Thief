using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public Color vulnerableColor = Color.white; // Color of character when vulnerable
    public Color invulnerableColor = Color.red; // Color of character when invulnerable
    public bool isInvulnerable = false; // Flag to track if character is currently invulnerable
    private SpriteRenderer spriteRenderer; // Reference to character's SpriteRenderer component
    public float currentHealth = 2;
    Animator animator;
    public Image healthImage;
    public Text moneyText;
    public Text knifeText;
    public float money;

    public GameObject knife;
    public Transform knifePosition;

    public float knifeCounter = 3;

    private CharacterController controller;

    private bool isPlayed = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
       
    }

    private void Update()
    {
        moneyText.text = money.ToString();
        knifeText.text = knifeCounter.ToString();

        if (currentHealth > 3)
        {
            currentHealth = 3;
        }
        
        healthImage.fillAmount = currentHealth / 10;

        if (currentHealth <= 0 && isPlayed == false)
        {
            animator.SetTrigger("die");
            PlayerPrefs.SetFloat("score",money);
            controller.speed = 0;
            isPlayed = true;
            StartCoroutine(LoadDeadScene());

        }



        if (Input.GetKeyDown(KeyCode.RightArrow) && knifeCounter > 0)
        {
            knifeCounter--;
            animator.SetTrigger("throw");
            throwKnife();
        }
    }

    // Function to handle character taking damage
    public void TakeDamage()
    {
        
            currentHealth -= 1;
            if(currentHealth != 0) animator.SetTrigger("hurt");
            // Apply damage to character
            // Code to apply damage to character goes here

            // Change character's color to indicate vulnerability
            spriteRenderer.color = vulnerableColor;

            // Start invulnerability coroutine
            StartCoroutine(InvulnerabilityCoroutine());

        
    }

    // Coroutine to handle invulnerability duration
    private IEnumerator InvulnerabilityCoroutine()
    {
        
        spriteRenderer.color = invulnerableColor;

        // Disable character's ability to take damage for invulnerability duration
        yield return new WaitForSeconds(1);

        // Reset character's color to indicate vulnerability
        spriteRenderer.color = vulnerableColor;

      
    }

    public void throwKnife()
    {
        Instantiate(knife, knifePosition.position, Quaternion.identity);
        
    }

    private IEnumerator LoadDeadScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }
}
