using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    [SerializeField] Animator heartAnim;

    private void Update()
    {
        if (PlayerStats.Health <= 2)
            heartAnim.SetBool("isLowHealth", true);
        else
            heartAnim.SetBool("isLowHealth", false);
    }

    public void SetMaxHealth()
    {
        slider.value = PlayerStats.Health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = PlayerStats.Health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
