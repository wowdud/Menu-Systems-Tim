using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : Stats
{
    public Image deathImage;
    public Image damageImage;
    public Text deathText;
    public AudioClip deathClip;
    public AudioSource playerAudio;
    public Transform currentCheckpoint;

    public Color flashColour = new Color(1, 0, 0, 0.2f);
    public float flashSpeed;
    public static bool IsDead;
    public bool isDamaged;
    public bool canHeal;
    public float healDelayTimer;


    void DeathText()
    {
        deathText.text = "you ded";
    }

    void RespawnText()
    {
        deathText.text = "but not for long";
    }

    void Respawn()
    {
        //reset player
        deathText.text = "";
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].currentValue = attributes[i].maxValue;
        }
        IsDead = false;
        //load position
        transform.position = currentCheckpoint.position;
        transform.rotation = currentCheckpoint.rotation;
        //respawn
        deathImage.GetComponent<Animator>().SetTrigger("Respawn");
    }

    void Death()
    {
        IsDead = true;
        deathText.text = "";
        //set and play audio
        playerAudio.clip = deathClip;
        playerAudio.Play();
        //trigger death screen
        deathImage.GetComponent<Animator>().SetTrigger("IsDead");
        //2 seconds, set text to death text
        Invoke("DeathText", 2);
        //6 seconds, set text to respawn text
        Invoke("RespawnText", 6);
        //9 seconds, respawn player
        Invoke("Respawn", 9);
    }

    public void RegenOverTime(int valueIndex)
    {
        attributes[valueIndex].currentValue += Time.deltaTime * attributes[valueIndex].regenValue;
    }

    public void DamagePlayer(float damage)
    {
        //engage damage flicker
        isDamaged = true;
        //take damage
        attributes[0].currentValue -= damage;
        //delay healing
        canHeal = false;
        healDelayTimer = 0;
        //check if dead
        if (attributes[0].currentValue <= 0 && !IsDead)
        {
            Death();
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            DamagePlayer(10);
        }
#endif
        //showing bars
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].displayImage.fillAmount = Mathf.Clamp01(attributes[i].currentValue/attributes[i].maxValue);
        }
        //damage flash
        if (isDamaged && !IsDead)
        {
            damageImage.color = flashColour;
            isDamaged = false;
        }
        else if (damageImage.color.a > 0)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //can heal
        if (!canHeal)
        {
            healDelayTimer += Time.deltaTime;
            if (healDelayTimer >= 5)
            {
                canHeal = true;
            }
        }
        if (canHeal && attributes[0].currentValue < attributes[0].maxValue && attributes[0].currentValue > 0)
        {
            RegenOverTime(0);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            currentCheckpoint = other.transform;
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i].regenValue += 7;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i].regenValue -= 7;
            }
        }
    }
}
