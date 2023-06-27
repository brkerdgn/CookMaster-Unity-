using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    Transform tablePos;
    NavMeshAgent agent;
    public Transform exitPoint;
    bool isWalking;
    public bool isGone = false;
    public int settedTable;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GetComponent<Animator>().SetBool("isWalking", isWalking);

        if (agent.velocity == Vector3.zero)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
            transform.LookAt(tablePos.parent.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitPoint"))
        {
            isGone = true;
            Destroy(gameObject);      
        }
    }


    public void WalkToTable(Transform pos)
    {
        tablePos = pos;
        agent.SetDestination(pos.position);
        isWalking = true;
    }

    public void LeaveRestourant()
    {
        agent.SetDestination(exitPoint.position); 
    }

    public int BurgerOrder()
    {
        return Random.Range(1, 5);
    }

    public int PizzaOrder()
    {
        return Random.Range(1, 5);
    }

    public int HotDogOrder()
    {
        return Random.Range(1, 5);
    }

}
