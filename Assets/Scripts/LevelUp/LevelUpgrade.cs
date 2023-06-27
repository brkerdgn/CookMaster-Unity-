using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUpgrade : MonoBehaviour
{
    public GameObject Joystick, levelUpgrade, spawnerArea, door, charachter;
    public GameObject[] box,food,pizza,hotDog; 
    public float cost;
    public static bool isUpgradeLevel;

    public TextMeshProUGUI textmesh;
    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 12;

        if (cost <= 0)
        {
            box = GameObject.FindGameObjectsWithTag("Box");
            food = GameObject.FindGameObjectsWithTag("Hamburger");
            pizza= GameObject.FindGameObjectsWithTag("Pizza");
            hotDog = GameObject.FindGameObjectsWithTag("HotDog");
            for (int i = 0; i < charachter.GetComponent<CollectManager>().boxList.Count; i++)
            {
                Destroy(box[i]);
            }
            for (int i = 0; i < charachter.GetComponent<CollectManager>().foodList.Count; i++)
            {
                Destroy(food[i]);
            }
            for (int i = 0; i < charachter.GetComponent<CollectManager>().pizzaList.Count; i++)
            {
                Destroy(pizza[i]);
            }
            for (int i = 0; i < charachter.GetComponent<CollectManager>().hotdogList.Count; i++)
            {
                Destroy(hotDog[i]);
            }

            charachter.GetComponent<CollectManager>().pizzaList.Clear();
            charachter.GetComponent<CollectManager>().hotdogList.Clear();
            charachter.GetComponent<CollectManager>().foodList.Clear();
            charachter.GetComponent<CollectManager>().boxList.Clear();
            door.GetComponent<BoxCollider>().isTrigger = true;
            Joystick.SetActive(false);
            levelUpgrade.SetActive(false);
            isUpgradeLevel = true;
            this.enabled=false;
        }
    }
}