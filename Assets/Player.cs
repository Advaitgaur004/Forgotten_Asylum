using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public BoxCollider boxcollider;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        boxcollider = GetComponentInChildren<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (boxcollider.bounds.Intersects(GetComponent<Collider>().bounds))
        {
            // Reduce health by 5
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}