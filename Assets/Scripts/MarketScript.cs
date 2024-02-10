using UnityEngine;

public class MarketScript : MonoBehaviour
{
    public int coinsToAddPerApple = 2;
    public int coinsToAddPerEgg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int subtractedApples = GameManager.instance.GetAppleCount();
            int subtractedEggs = GameManager.instance.GetEggCount();

            int coinsEarned = (subtractedApples * coinsToAddPerApple) + (subtractedEggs * coinsToAddPerEgg);

            GameManager.instance.AddApples(-subtractedApples);
            GameManager.instance.AddEggs(-subtractedEggs);
            GameManager.instance.coinCount += coinsEarned;
            GameManager.instance.UpdateCounters();
        }
    }
}
