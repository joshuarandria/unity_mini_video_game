using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCooldown : MonoBehaviour
{
    [SerializeField] Image imageCooldown;
    [SerializeField] TMP_Text textCooldown;
    private bool isCooldown = false;
    public float cooldownTimer = 0.0f;
    [SerializeField] float cooldownTime;


    // Start is called before the first frame update
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            //Debug.Log("coolDown true");
            ApplyCooldown();
        }
    }

    public void ApplyCooldown()
    {
        //Debug.Log("Application du cooldown");
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }
    public void UseSpell()
    {
        if (isCooldown)
        {
            //Debug.Log("already used");
        }
        else
        {
            isCooldown = true;
            //Debug.Log("Début du cooldow");
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            //Debug.Log("is cooldown = true");
        }
    }
}
