using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class HealthController : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 20f;
    private float currentHealth;
    int healthValue;


    public InputField inputField;
    public InputField inputIncDec;
    public Button buttonPlus;
    public Button buttonMinus;


    public PostProcessVolume postProcessVolume;
    private Vignette vignette;

    void Start()
    {
        

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
        UpdateHealthUI();
        postProcessVolume.profile.TryGetSettings(out vignette);//getting the vignette effect from post-processing volume
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
            SceneManager.LoadScene(1);//loading the Game Over Scene
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
        StartCoroutine(DamageVignetteEffect());//trigger the damage efect
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

    private IEnumerator DamageVignetteEffect()
    {
        
        vignette.intensity.Override(1f);//setting the vignette intensity to maximum value

        
        yield return new WaitForSeconds(0.1f);//wait for a short time

       
        vignette.intensity.Override(0f);///setting the vignette intensity to minimum value
    }
}
