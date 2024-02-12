using UnityEngine;
using System.Collections;
using TMPro;

public class CoopScript : MonoBehaviour
{
    private bool coopUsed = false;
    public int eggsPertime = 3;
    private bool isCooldown = false;
    public float cooldownDuration = 180f;
    public TextMeshProUGUI cooldownText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCooldown && !coopUsed)
        {
            if (GameManager.instance.CanUnlockCoop())
            {
                GameManager.instance.UnlockCoop();
                coopUsed = true;
            }
        }
        else if (collision.tag == "Player" && coopUsed)
        {
            GameManager.instance.AddEggs(eggsPertime);
        }
    }
}
