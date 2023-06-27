using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public GameObject conveyorManagerHamList;
    public List<GameObject> hamburgerList = new List<GameObject>();

    public void RemoveTableFood()
    {
        if (hamburgerList.Count > 0 && conveyorManagerHamList.GetComponent<ConveyorManager>().hamburgerNoRBList.Count > 0 )
        {
            Destroy(hamburgerList[hamburgerList.Count - 1]);
            hamburgerList.RemoveAt(hamburgerList.Count - 1);
            Destroy(conveyorManagerHamList.GetComponent<ConveyorManager>().hamburgerNoRBList[conveyorManagerHamList.GetComponent<ConveyorManager>().hamburgerNoRBList.Count - 1]);
            conveyorManagerHamList.GetComponent<ConveyorManager>().hamburgerNoRBList.RemoveAt(conveyorManagerHamList.GetComponent<ConveyorManager>().hamburgerNoRBList.Count - 1);

        }
    }
}
