using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer graphics;
    public bool isInvicible = false;
    public float invicibiltyFlashDelay = 0.15f;
    public float invincibilityTime = 1f;

    public static PlayerHealth instance;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Double instance singleton");
            return;
        }
        instance = this;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void Heal(int _heal)
    {
        if ((currentHealth + _heal) <= maxHealth)
            currentHealth += _heal;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int _damage)
    {
        if (!isInvicible)
        {
            currentHealth -= _damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvicible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibiltyDelay());
        }
    }

    public void Die()
    {
        MovePlayer.instance.DesactivatePlayer();
        MovePlayer.instance.animator.SetTrigger("Death");
        //lancer les trigger du fade pour un écran de gameOver
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibiltyFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibiltyFlashDelay);
        }
    }

    public IEnumerator HandleInvincibiltyDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvicible = false;
    }
}
