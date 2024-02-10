using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int appleCount = 0;
    public int coinCount = 0;
    public int eggCount = 0;
    private bool coopUnlocked = false;

    public TextMeshProUGUI appleCounterText;
    public TextMeshProUGUI coinCounterText;
    public TextMeshProUGUI eggCounterText;
    public TextMeshProUGUI coopUnlockText;

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

    public void UpdateCounters()
    {
        appleCounterText.text = appleCount.ToString();
        coinCounterText.text = coinCount.ToString();
        eggCounterText.text = eggCount.ToString();
    }

    public void AddApples(int amount)
    {
        appleCount += amount;
        UpdateCounters();
    }

    public int GetAppleCount()
    {
        return appleCount;
    }

    public bool CanHarvestApples()
    {
        return true;
    }

    public int SellApples()
    {
        int soldApples = appleCount;
        int coinsEarned = soldApples * 2;
        coinCount += coinsEarned;
        appleCount -= soldApples;
        UpdateCounters();
        return coinsEarned;
    }

    public bool CanUnlockCoop()
    {
        return coinCount >= 20;
    }

    public void UnlockCoop()
    {
        if (CanUnlockCoop())
        {
            coinCount -= 20;
            coopUnlocked = true;
            UpdateCounters();
            if (coopUnlockText != null)
            {
                Destroy(coopUnlockText.gameObject);
            }
        }
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public int GetEggCount()
    {
        return eggCount;
    }

    public void AddEggs(int amount)
    {
        eggCount += amount;
        UpdateCounters();
    }

    public int SellEggs()
    {
        int soldEggs = coopUnlocked ? 3 : 0;
        int coinsEarned = soldEggs * 3;
        coinCount += coinsEarned;
        eggCount -= soldEggs;
        UpdateCounters();
        return coinsEarned;
    }
}
