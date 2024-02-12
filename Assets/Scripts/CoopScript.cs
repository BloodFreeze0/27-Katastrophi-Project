using UnityEngine;
using System.Collections;
using TMPro;

public class CoopScript : MonoBehaviour
{
    private bool coopUnlocked = false;
    public int eggsPertime = 3;
    private bool isCooldown = false;
    public float cooldownDuration = 180f;
    public TextMeshProUGUI cooldownText;

    public AudioSource source;
    public AudioClip clip;

    //kyrio meros collision kai unlock
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCooldown && !coopUnlocked)
        {
            if (GameManager.instance.CanUnlockCoop())
            {
                GameManager.instance.UnlockCoop();
                coopUnlocked = true;
                GameManager.instance.UpdateCounters();
            }
        }
        else if (collision.tag == "Player" && coopUnlocked && !isCooldown)
        {
            GameManager.instance.AddEggs(eggsPertime);
            source.PlayOneShot(clip);
            StartEggCooldown();
        }
    }

    //cooldown gia auga
    private void StartEggCooldown()
    {
        if (!isCooldown)
        {
            StartCoroutine(EggCooldown());
        }
    }

    //coroutine tou cooldown
    private IEnumerator EggCooldown()
    {
        isCooldown = true;

        float cooldownTimer = cooldownDuration;

        while (cooldownTimer > 0f)
        {
            cooldownText.text = Mathf.Floor(cooldownTimer / 60).ToString("00") + ":" + Mathf.Floor(cooldownTimer % 60).ToString("00");
            yield return new WaitForSeconds(1f);
            cooldownTimer -= 1f;
        }

        cooldownText.text = "";
        isCooldown = false;
    }
}
