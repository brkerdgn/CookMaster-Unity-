using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarrierMan : MonoBehaviour
{
    public List<GameObject> manList = new List<GameObject>();
    public Transform palletPos, hamPos, pizzaPos, carrierPos;
    NavMeshAgent agent;
    public GameObject palette, charachter, conveyor, conveyor2,spawnerArea;
    public bool isWalking, isPizzaMoreThanHam, isEqual;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if(spawnerArea.GetComponent<SpawnerArea>().level == 2)
        {
            if (conveyor.GetComponent<ConveyorManager>().boxConList.Count < conveyor2.GetComponent<ConveyorPizza>().boxConList.Count)
            {
                isPizzaMoreThanHam = true;
                isEqual = false;
            }
            else if (conveyor.GetComponent<ConveyorManager>().boxConList.Count > conveyor2.GetComponent<ConveyorPizza>().boxConList.Count)
            {
                isPizzaMoreThanHam = false;
                isEqual = false;
            }
            else
            {
                isEqual = true;
            }

        }

        else if (spawnerArea.GetComponent<SpawnerArea>().level == 3)
        {
            if (conveyor.GetComponent<ConveyorHotDog>().boxConList.Count < conveyor2.GetComponent<ConveyorPizza>().boxConList.Count)
            {
                isPizzaMoreThanHam = true;
                isEqual = false;
            }
            else if (conveyor.GetComponent<ConveyorHotDog>().boxConList.Count > conveyor2.GetComponent<ConveyorPizza>().boxConList.Count)
            {
                isPizzaMoreThanHam = false;
                isEqual = false;
            }
            else
            {
                isEqual = true;
            }
        }

       
        GetComponent<Animator>().SetBool("isWalking", isWalking);

        if (agent.velocity == Vector3.zero)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }


        if (palette.GetComponent<TruckManager>().boxList.Count > 0)
        {
            agent.SetDestination(palletPos.position);
        }
        if (charachter.GetComponent<CollectManager2>().boxList.Count == 4)
        {
            if (isPizzaMoreThanHam == true)
            {
                agent.SetDestination(hamPos.position);
            }
            else if (isPizzaMoreThanHam == false)
            {
                agent.SetDestination(pizzaPos.position);

            }
            else if (isEqual == true)
            {
                agent.SetDestination(hamPos.position);
            }
        }
    }
}
