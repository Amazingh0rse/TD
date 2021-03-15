using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Setting player max health
    public int maxHealth = 100;
    // Current health
    public int currentHealth;

    // Add reference to healthbar
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        // When the game starts call the health bar and set the max health from the HealthBar script
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    // On space the player will take 20 damage each time
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("MINUS 20 DKP");
            TakeDamage(20);
        }

        if (currentHealth <= 0)
        {
            // Activivate ragdoll effect
            var ragdoll = GetComponentInParent<RagdollHandler>();
                if (ragdoll) 
                    ragdoll.GoRagdoll(true);

            // Destroy player object after 3 seconds
            Destroy(gameObject, 3f);        
            
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag == "canonball"){
            TakeDamage(20);
        }
    }

    // Take damage method
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Update the health bar everytime the player takes damage (again taken from the HealthBar script)
        healthBar.SetHealth(currentHealth);
    }

}
