using UnityEngine;

// Destroy owning GameObject if any collider with a specific tag is trespassing
public class DestroyOnTriggerPrize : MonoBehaviour
{
    //public string m_Tag = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            LivesandScore.playerScore += 10;
        }
            
        
    }
}
