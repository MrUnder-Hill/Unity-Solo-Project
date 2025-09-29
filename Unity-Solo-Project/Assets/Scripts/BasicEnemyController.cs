using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyController : MonoBehaviour
{
    PlayerController player;

    [Header("Logic")]
    NavMeshAgent agent;
    public bool isFollowing = false;

    [Header("Enemy Stats")]
    public int health = 3;
    public int maxHealth = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
            agent.destination = player.transform.position;

        if (health <= 0)
        { 
            agent.isStopped= true;
            Destroy(gameObject);
        }
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "proj")
        {
            health--;
        }
    }
}