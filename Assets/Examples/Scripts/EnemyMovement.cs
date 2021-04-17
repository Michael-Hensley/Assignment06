using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent m_Agent;
    Vector3 originalPos = new Vector3(-12, 5, -3);
    RaycastHit m_HitInfo = new RaycastHit();
    public ThirdPersonCharacter character;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.updateRotation = false;
    }

    void Update()
    {

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

    //public string m_Tag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LivesandScore.playerLives -=1;
            gameObject.transform.position = originalPos;
            m_Agent.speed += 1;
        }
            
    }
}
