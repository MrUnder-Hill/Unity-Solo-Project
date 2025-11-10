using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;
using UnityEngine.SceneManagement;

public class BasicEnemyController : MonoBehaviour
{
    PlayerController player;
    Animator myAnim;

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
       
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;


        if (isFollowing)
        {
            agent.isStopped = false;
            agent.SetDestination(player);
            myAnim.SetBool("isAttacking", true);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
            agent.isStopped = true;
        }

        if (health <= 0)
        {
            agent.isStopped = true;
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