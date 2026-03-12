

using UnityEngine;

public class CoinTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameManager.Instance.playerScore++;
            Destroy(gameObject);
        }
    }
}