using UnityEngine;
using TMPro;
public class ItemCollection : MonoBehaviour
{
    int coins = 0;

    [SerializeField] TMP_Text coinsText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;

        

        }
    }

    
    
}
