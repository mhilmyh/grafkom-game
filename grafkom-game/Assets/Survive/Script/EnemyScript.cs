using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    Animator animate;

    // Start is called in the beginning
    void Start() 
    {
        animate = GetComponent<Animator>();
        animate.SetInteger("Walk", 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Agent will follow the target
        agent.SetDestination(target.transform.position);
    }
}
