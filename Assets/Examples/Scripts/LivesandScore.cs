using UnityEngine;
using UnityEngine.UI;

public class LivesandScore : MonoBehaviour
{

    public static int playerScore = 0;
    public static int playerLives = 3;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Text score;
    public Text lives;
    // Start is called before the first frame update
    void Start()
    {
        score.text =playerScore.ToString();
        lives.text =playerLives.ToString();
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

}
