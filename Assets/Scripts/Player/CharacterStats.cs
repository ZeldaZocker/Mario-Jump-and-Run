using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealt = 3;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;



    void Awake()
    {
        currentHealth = maxHealt;
    }

    public void TakenDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        switch (currentHealth)
        {
            case '2':
                this.GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case '1':
                this.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten
        this.GetComponent<PlayerMovement>().Respawn();
        Debug.Log(transform.name + " dies.");
    }

    public void Reset()
    {
        currentHealth = maxHealt;
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

}