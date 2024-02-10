using UnityEngine;
using System.Collections;
using TMPro;

public class TreeScript : MonoBehaviour
{
    public float cooldownDuration = 180f;
    private bool isCooldown = false;

    public TextMeshProUGUI cooldownText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isCooldown)
        {
            int applesToAdd = 5;
            GameManager.instance.AddApples(applesToAdd);
            StartCoroutine(TreeCooldown());
        }
    }

    IEnumerator TreeCooldown()
    {
        isCooldown = true;

        float cooldownTimer = cooldownDuration;

        while (cooldownTimer > 0f)
        {
            cooldownText.text = string.Format("{0:00}:{1:00}", Mathf.Floor(cooldownTimer / 60), Mathf.Floor(cooldownTimer % 60));
            yield return new WaitForSeconds(1f);
            cooldownTimer -= 1f;
        }

        isCooldown = false;
        cooldownText.text = "";

        yield return null;
    }
}
