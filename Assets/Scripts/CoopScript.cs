using UnityEngine;

public class CoopScript : MonoBehaviour
{
    private bool coopUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !coopUsed)
        {
            if (GameManager.instance.CanUnlockCoop())
            {
                GameManager.instance.UnlockCoop();
                coopUsed = true;
            }
        }
        else if (collision.tag == "Player" && coopUsed)
        {
            GameManager.instance.AddEggs(3);
        }
    }
}
