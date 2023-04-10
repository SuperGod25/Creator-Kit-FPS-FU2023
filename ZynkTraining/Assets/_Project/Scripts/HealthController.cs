using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthController : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float currentHealth;
    int healthValue;
    public InputField inputField;
    public InputField inputIncDec;
    public Button buttonPlus;
    public Button buttonMinus;

    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(2);
            UpdateHealthUI();
        }

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SetHealth()
    {
        healthValue = int.Parse(inputField.text);
        currentHealth = healthValue;
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthUI();
    }

    public void IncreaseHealth()
    {
        healthValue = int.Parse(inputIncDec.text);
        currentHealth += healthValue;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();
    }

    public void DecreaseHealth()
    {
        healthValue = int.Parse(inputIncDec.text);
        currentHealth -= healthValue;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;

    }
}
