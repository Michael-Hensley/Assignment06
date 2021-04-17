using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwakens : MonoBehaviour
{
    public GameObject enemy;
    public GameObject winCube;
    void Start()
    {
        enemy.SetActive(false);
    }

    
    void Update()
    {
        if(LivesandScore.playerScore >= 10)
        {
            enemy.SetActive(true);
        }
        if(LivesandScore.playerScore <30)
        {
            winCube.SetActive(false);
        }
        else
        {
            winCube.SetActive(true);
        }
    }
}
