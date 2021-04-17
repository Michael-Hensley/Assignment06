using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();
    public ThirdPersonCharacter character;

    public Text score;
    public Text lives;
    public GameObject lossScreen;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.updateRotation = false;
    }

    void Update()
    {

        score.text =LivesandScore.playerScore.ToString();
        lives.text =LivesandScore.playerLives.ToString();
        if (LivesandScore.playerLives <= 0)
            {
                lossScreen.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
            }

        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                m_Agent.destination = m_HitInfo.point;
        }
        if(m_Agent.remainingDistance > m_Agent.stoppingDistance)
        {
            character.Move(m_Agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
