using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{

    public ObscuredInt maxHealt = 3;
    [SerializeField]
    public ObscuredInt currentHealth;

    public Stat damage;
    public Stat armor;
    public Stat invulnerable;
    public ObscuredBool isInvulnerable = false;




    void Awake()
    {
        currentHealth = maxHealt;
        this.GetComponent<SpriteRenderer>().color = Color.green;
    }



    public void TakenDamage(int damage)
    {
        if (!isInvulnerable)
        {
            damage -= armor.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, int.MaxValue);
            //Debug.Log(transform.name + " takes " + damage + " damage.");

            if (currentHealth == 2)
            {
                this.GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            else if (currentHealth == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isInvulnerable = true;
        this.GetComponent<PlayerMovement>().Respawn();
        this.GetComponent<SpriteRenderer>().color = Color.green;
        currentHealth = maxHealt;
        GameObject.Find("MissleCounter").GetComponent<MissleCounter>().Reset();
        isInvulnerable = false;

        //Debug.Log(transform.name + " dies.");
    }

    void OnGUI()
    {
        GUI.Box(new Rect(230, 10, 100, 25), "Leben: " + currentHealth);
    }

}


