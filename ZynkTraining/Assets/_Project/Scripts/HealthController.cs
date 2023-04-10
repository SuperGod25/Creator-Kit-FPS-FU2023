using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public InputField setHealthInput;

    public Button increaseButton;
    public Button decreaseButton;
    public InputField increaseDecreaseInput;



    int setHealthInputNum;
    int increaseDecreaseInputNum;
    // Start is called before the first frame update
    void Start()
    {
        
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }


    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth==0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void SetHealthByInput()
    {
        setHealthInputNum = System.Convert.ToInt32(setHealthInput.text);

        currentHealth = setHealthInputNum;
        if (setHealthInputNum>=100)
        {
            setHealthInput.text = "MAX HEALTH";
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        ///Fix health update
      
    }

    public void IncreaseHealth()
    {
        increaseDecreaseInputNum = System.Convert.ToInt32(increaseDecreaseInput.text);
        currentHealth += increaseDecreaseInputNum;//fix health bar
    }

    public void DecreaseHealth()
    {
        increaseDecreaseInputNum = System.Convert.ToInt32(increaseDecreaseInput.text);
        currentHealth -= increaseDecreaseInputNum;/// fix health bar
    }
}
