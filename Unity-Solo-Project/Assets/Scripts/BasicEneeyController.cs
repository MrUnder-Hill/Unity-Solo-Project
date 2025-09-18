using UnityEngine;
using UnityEngine.AI;

public class BasicEneeyController : MonoBehaviour
{
    public float speed = 2f;
   
    public int health = 3;
    public int maxHealth = 3;

    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
         void OnCollisionEnter(Collision collision)
        {
           agent.destination = GameObject.Find("Player").transform.position;
    
        
    }
}
