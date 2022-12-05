using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    [SerializeField] int takeDamage = 10;

    [SerializeField] float[] weight = null;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        int t_damage = takeDamage;
        t_damage = (int)(t_damage * weight[amount]);
        currentHealth -= t_damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
