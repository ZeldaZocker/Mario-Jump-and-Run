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
    public ObscuredBool isInvulnerable = false;




    void Awake()
    {
        currentHealth = maxHealt;
        //this.GetComponent<SpriteRenderer>().color = Color.green;
        isInvulnerable = false;
    }



    public IEnumerator TakenDamage(int damage)
    {
        if (isInvulnerable == false)
        {
            //Debug.Log(damage);
            //damage -= armor.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, int.MaxValue);
            //Debug.Log(transform.name + " takes " + damage + " damage.");

            isInvulnerable = true;
            yield return new WaitForSeconds(1);
            isInvulnerable = false;


            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void ResetInvulnerability()
    {
        isInvulnerable = true;
    }

    private void Die()
    {
        isInvulnerable = true;
        this.GetComponent<PlayerMovement>().Death();
        //this.GetComponent<SpriteRenderer>().color = Color.green;
        currentHealth = maxHealt;
        GameObject.Find("MissleCounter").GetComponent<MissleCounter>().Reset();
        isInvulnerable = false;

        //Debug.Log(transform.name + " dies.");
    }


    // Heart UI in HeartSystem vorhanden!
    //void OnGUI()
    //{
    //   GUI.Box(new Rect(230, 10, 100, 25), "Leben: " + currentHealth);
    //}

}


