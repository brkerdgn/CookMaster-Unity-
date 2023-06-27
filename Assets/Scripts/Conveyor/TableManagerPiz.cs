using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManagerPiz : MonoBehaviour
{
    public GameObject conveyorManagerPizList;
    public List<GameObject> PizzaList = new List<GameObject>();

    public void RemoveTableFood()
    {
        if (PizzaList.Count > 0 && conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList.Count > 0)
        {
            Destroy(PizzaList[PizzaList.Count - 1]);
            PizzaList.RemoveAt(PizzaList.Count - 1);
            Destroy(conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList[conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList.Count - 1]);
            conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList.RemoveAt(conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList.Count - 1);

        }
    }
}
