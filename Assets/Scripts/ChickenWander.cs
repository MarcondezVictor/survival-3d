using UnityEngine;
using UnityEngine.AI;

public class ChickenWander : MonoBehaviour
{
    [SerializeField] private float wanderRadius = 10f;
    [SerializeField] private float minWaitTime = 1f;
    [SerializeField] private float maxWaitTime = 4f;

    private NavMeshAgent agent;
    private float waitTimer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTimer -= Time.deltaTime;

            if(waitTimer <= 0f)
            {
                PickNewDestination();
                waitTimer = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }

    private void PickNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
