using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWinScreen : MonoBehaviour
{
    public string m_Tag = "Player";
    public GameObject winScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == m_Tag)
            winScreen.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        
    }
}
