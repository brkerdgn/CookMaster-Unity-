using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WaiterWomanControl : MonoBehaviour
{
    public Transform conveyorPiz, conveyorHotdog, table1, table2, table3, table4, table5,garbage;
    public GameObject tablecontrol;
    NavMeshAgent agent;
    public bool isWalking;
    [SerializeField] TablesManager[] table;

    public Transform[] deliver;
    int index;
    public bool refilledPizza, refilledHotDog;
    CollectManagerWaiter collect;
    public ConveyorHotDog conveyorHotDog;
    public ConveyorPizza conveyorPizza;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        collect = GetComponent<CollectManagerWaiter>();

    }

    void Start()
    {
    }


    void Update()
    {
        if (collect.pizzaList.Count == 0 && collect.hotdogList.Count == 0 && conveyorPizza.pizzaNoRBList.Count <= conveyorHotDog.hotDogNoRBList.Count)
        {
            agent.SetDestination(conveyorHotdog.transform.position);
        }

        else if (collect.pizzaList.Count == 0 && collect.hotdogList.Count == 0 && conveyorPizza.pizzaNoRBList.Count > conveyorHotDog.hotDogNoRBList.Count)
        {
            agent.SetDestination(conveyorPiz.transform.position);
        }

        if(collect.pizzaList.Count == 4)
        {
            refilledPizza = true;
        }
        if(collect.hotdogList.Count == 4){
            refilledHotDog = true;
        }

        //CharachterControl
        if (LocateTable() != -1)
        {
            if(gameObject.GetComponent<CollectManagerWaiter>().pizzaList.Count > 0)
            {
                if (table[LocateTable()].pizzaNeeded - table[LocateTable()].pizzaGived == collect.pizzaList.Count && collect.pizzaList.Count != 0 || refilledPizza)
                {
                    agent.SetDestination(deliver[LocateTable()].position);

                    if(gameObject.GetComponent<CollectManagerWaiter>().pizzaList.Count == 0 && gameObject.GetComponent<CollectManagerWaiter>().hotdogList.Count == 0)
                    {
                        refilledPizza = false;   
                    }
                }
            }

            else if(gameObject.GetComponent<CollectManagerWaiter>().hotdogList.Count > 0)
            {
                if (table[LocateTable()].hotDogNeeded - table[LocateTable()].hotDogGived == collect.hotdogList.Count && collect.hotdogList.Count != 0 || refilledHotDog)
                {
                    agent.SetDestination(deliver[LocateTable()].position);

                    if (gameObject.GetComponent<CollectManagerWaiter>().pizzaList.Count == 0 && gameObject.GetComponent<CollectManagerWaiter>().hotdogList.Count == 0)
                    {
                        refilledHotDog = false;
                    }
                }
            }
        }
        //Animasyon
        GetComponent<Animator>().SetBool("isWalking", isWalking);

        if (agent.velocity == Vector3.zero)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }


 


    }

    int LocateTable()
    {
        int index = -1 ;
        int i = 0;
        int miniH = -1;
        int miniP = -1;

        if (tablecontrol.GetComponent<TableControl>().tableCountForWaiter != 1)
        {
            int[] hotDogTable = new int[tablecontrol.GetComponent<TableControl>().tableCountForWaiter];
            int[] pizzaTable = new int[tablecontrol.GetComponent<TableControl>().tableCountForWaiter];

            for (i = 0; i < tablecontrol.GetComponent<TableControl>().tableCountForWaiter; i++)
            {
                if (table[i].isCame == true)
                {
                    hotDogTable[i] = table[i].hotDogNeeded - table[i].hotDogGived;
                    pizzaTable[i] = table[i].pizzaNeeded - table[i].pizzaGived;
                }
                else
                {
                    hotDogTable[i] = -1;
                    pizzaTable[i] = -1;
                }
            }

            System.Array.Sort(hotDogTable);
            System.Array.Sort(pizzaTable);

            for (i = 0; i < tablecontrol.GetComponent<TableControl>().tableCountForWaiter; i++)
            {
                if (hotDogTable[i] == -1 || hotDogTable[i] == 0)
                    continue;
                
                miniH = hotDogTable[i];
                break;
            }

            for (i = 0; i < tablecontrol.GetComponent<TableControl>().tableCountForWaiter; i++)
            {
                if (pizzaTable[i] == -1 || pizzaTable[i] == 0)
                    continue;

                miniP = pizzaTable[i];
                break;
            }

            if (collect.hotdogList.Count > 0)
            {
                for (i = 0; i < tablecontrol.GetComponent<TableControl>().tableCountForWaiter; i++)
                {
                    if (table[i].isCame)
                    {
                        if (table[i].hotDogNeeded - table[i].hotDogGived == miniH)
                        {
                            index = i;
                        }
                    }
                }
            }
            else if (collect.pizzaList.Count > 0)
            {
                for (i = 0; i < tablecontrol.GetComponent<TableControl>().tableCountForWaiter; i++)
                {
                    if (table[i].isCame)
                    {
                        if (table[i].pizzaNeeded - table[i].pizzaGived == miniP)
                        {
                            index = i;
                        }
                    }
                }
            }

        }
        else
        {
            if (table[i].isCame)
            {
                index = 0;
            }
        }
        return index;
    }
}

