using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Variables for resources
    public int appleCount = 0;
    public int coinCount = 0;
    public int eggCount = 0;

    // Coop-related variables
    private bool coopUnlocked = false;
    public TextMeshProUGUI coopUnlockText;

    // Cooldown duration for egg collection
    public float eggCooldownDuration = 180f;
    private bool isEggCooldown = false;

    // References to UI text elements
    public TextMeshProUGUI appleCounterText;
    public TextMeshProUGUI coinCounterText;
    public TextMeshProUGUI eggCounterText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCounters();
    }

    public void UpdateCounters()
    {
        appleCounterText.text = "Apples: " + appleCount;
        coinCounterText.text = "Coins: " + coinCount;
        eggCounterText.text = "Eggs: " + eggCount;
    }

    // Functions to manage resources

    public void AddApples(int amount)
    {
        appleCount += amount;
        UpdateCounters();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCounters();
    }

    public void AddEggs(int amount)
    {
        eggCount += amount;
        UpdateCounters();
    }

    // Functions related to coop

    public bool CanUnlockCoop()
    {
        return coinCount >= 20 && !coopUnlocked;
    }

    public void UnlockCoop()
    {
        if (CanUnlockCoop())
        {
            coinCount -= 20;
            coopUnlocked = true;

            if (coopUnlockText != null)
            {
                Destroy(coopUnlockText.gameObject);
            }

            StartCoroutine(EggCooldown());
        }
    }

    IEnumerator EggCooldown()
    {
        isEggCooldown = true;

        yield return new WaitForSeconds(eggCooldownDuration);

        isEggCooldown = false;
    }

    public bool IsEggCooldownActive()
    {
        return isEggCooldown;
    }

    // Methods to get apple and egg counts

    public int GetAppleCount()
    {
        return appleCount;
    }

    public int GetEggCount()
    {
        return eggCount;
    }
}
