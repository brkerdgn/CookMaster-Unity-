using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TablesManager : MonoBehaviour
{
    public List<GameObject> customers = new List<GameObject>();
    public List<GameObject> eatenList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();
    public int tableNo;
    public GameObject hamburgerPref,hotDogPref,pizzaPref, charachter, moneyPref,level,waiter,player;
    public Transform hamburgerDropPo, moneyDropPoint;
    TableControl table;
    public int burgerNeeded, burgerGived, eatedBurger, money, oneBurgerMoney,burgerNeededText;
    public int pizzaNeeded, pizzaGived, eatedPizza,onePizzaMoney, pizzaNeededText;
    public int hotDogNeeded, hotDogGived, eatedHotdog, oneHotdogMoney, hotdogNeededText;
    public GameObject canvas;
    public TextMeshProUGUI burgerText,pizzaText,hotDogText;
    public Transform startPos, charachterPos;
    public float desiredDuration = 3f;
    public bool isCustomerEatedMeal,isCame,isTakeMoney;

    float timer,timer2,timer3;
    private void Awake()
    {
        table = GetComponentInParent<TableControl>();
    }

    //Charachterin elindeki hamburgerin masaya verilmesi
    public void GetHam()
    {
        if (table.isCame[tableNo] == true)
        {
            if (charachter.GetComponent<CollectManager>().foodList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (burgerGived < table.burgerOrder[tableNo] && table.burgerOrder[tableNo] > 0)
                        {
                            GameObject temp = Instantiate(hamburgerPref);
                            temp.transform.position = new Vector3(hamburgerDropPo.position.x, (1.9f + eatenList.Count) / 3, hamburgerDropPo.position.z);
                            eatenList.Add(temp);
                        }
                    }
                }
            }
        }
    }
    //Charachterin elindeki pizzanýn masaya verilmesi
    public void GetPizza()
    {
        if (table.isCame[tableNo] == true)
        {
            if (charachter.GetComponent<CollectManager>().pizzaList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (pizzaGived < table.pizzaOrder[tableNo] && table.pizzaOrder[tableNo] > 0)
                        {
                            GameObject temp = Instantiate(pizzaPref);
                            temp.transform.position = new Vector3(hamburgerDropPo.position.x, (1.9f + eatenList.Count) / 3, hamburgerDropPo.position.z);
                            eatenList.Add(temp);
                        }
                    }
                }
            }
        }
    }
    //Charachterin elindeki hotdogun masaya verilmesi
    public void GetHotdog()
    {
        if (table.isCame[tableNo] == true)
        {
            if (charachter.GetComponent<CollectManager>().hotdogList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (hotDogGived < table.hutDogOrder[tableNo] && table.hutDogOrder[tableNo] > 0)
                        {
                            GameObject temp = Instantiate(hotDogPref);
                            temp.transform.position = new Vector3(hamburgerDropPo.position.x, (1.9f + eatenList.Count) / 3, hamburgerDropPo.position.z);
                            eatenList.Add(temp);
                        }
                    }
                }
            }
        }
    }
    //Waiterýn elindeki Hotdogu Masaya Vermesi
    public void GetHotdogForWaiter()
    {
        if (table.isCame[tableNo] == true)
        {
            if (waiter.GetComponent<CollectManagerWaiter>().hotdogList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (hotDogGived < table.hutDogOrder[tableNo] && table.hutDogOrder[tableNo] > 0)
                        {
                            GameObject temp = Instantiate(hotDogPref);
                            temp.transform.position = new Vector3(hamburgerDropPo.position.x, (1.9f + eatenList.Count) / 3, hamburgerDropPo.position.z);
                            eatenList.Add(temp);
                        }
                    }
                }
            }
        }
    }

    //Waiterýn elindeki pizzanýn masaya verilmesi
    public void GetPizzaForWaiter()
    {
        if (table.isCame[tableNo] == true)
        {
            if (waiter.GetComponent<CollectManagerWaiter>().pizzaList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (pizzaGived < table.pizzaOrder[tableNo] && table.pizzaOrder[tableNo] > 0)
                        {
                            GameObject temp = Instantiate(pizzaPref);
                            temp.transform.position = new Vector3(hamburgerDropPo.position.x, (1.9f + eatenList.Count) / 3, hamburgerDropPo.position.z);
                            eatenList.Add(temp);
                        }
                    }
                }
            }
        }
    }


    //Charachterin elindeki hamburgeri silmek
    public void RemoveLastHam()
    {
        if (table.isCame[tableNo] == true)
        {
            if (charachter.GetComponent<CollectManager>().foodList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (burgerGived < table.burgerOrder[tableNo] && table.burgerOrder[tableNo] > 0)
                        {
                            Destroy(charachter.GetComponent<CollectManager>().foodList[charachter.GetComponent<CollectManager>().foodList.Count - 1]);
                            charachter.GetComponent<CollectManager>().foodList.RemoveAt(charachter.GetComponent<CollectManager>().foodList.Count - 1);
                            charachter.GetComponent<CollectManager>().yukseklik--;
                            burgerGived++;
                        }
                    }
                }
            }
        }
    }

    //Charachterin elindeki pizzayý silmek
    public void RemoveLastPizza()
    {
        if (table.isCame[tableNo] == true)
        {
            if (charachter.GetComponent<CollectManager>().pizzaList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (pizzaGived < table.pizzaOrder[tableNo] && table.pizzaOrder[tableNo] > 0)
                        {
                            Destroy(charachter.GetComponent<CollectManager>().pizzaList[charachter.GetComponent<CollectManager>().pizzaList.Count - 1]);
                            charachter.GetComponent<CollectManager>().pizzaList.RemoveAt(charachter.GetComponent<CollectManager>().pizzaList.Count - 1);
                            charachter.GetComponent<CollectManager>().yukseklik--;
                            pizzaGived++;
                        }
                    }
                }
            }
        }
    }

    //Charachterin elindeki hotdogu silmek
    public void RemoveLastHotDog()
    {
        if (table.isCame[tableNo] == true)
        {
            if (charachter.GetComponent<CollectManager>().hotdogList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (hotDogGived < table.hutDogOrder[tableNo] && table.hutDogOrder[tableNo] > 0)
                        {
                            Destroy(charachter.GetComponent<CollectManager>().hotdogList[charachter.GetComponent<CollectManager>().hotdogList.Count - 1]);
                            charachter.GetComponent<CollectManager>().hotdogList.RemoveAt(charachter.GetComponent<CollectManager>().hotdogList.Count - 1);
                            charachter.GetComponent<CollectManager>().yukseklik--;
                            hotDogGived++;
                        }
                    }
                }
            }
        }
    }

    //Waiterýn elindeki hotdogu silmek
    public void RemoveLastHotDogForWaiter()
    {
        if (table.isCame[tableNo] == true)
        {
            if (waiter.GetComponent<CollectManagerWaiter>().hotdogList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (hotDogGived < table.hutDogOrder[tableNo] && table.hutDogOrder[tableNo] > 0)
                        {
                            Destroy(waiter.GetComponent<CollectManagerWaiter>().hotdogList[waiter.GetComponent<CollectManagerWaiter>().hotdogList.Count - 1]);
                            waiter.GetComponent<CollectManagerWaiter>().hotdogList.RemoveAt(waiter.GetComponent<CollectManagerWaiter>().hotdogList.Count - 1);
                            waiter.GetComponent<CollectManagerWaiter>().yukseklik--;
                            hotDogGived++;
                        }
                    }
                }
            }
        }
    }

    //Waiterin elindeki pizzayý silmek
    public void RemoveLastPizzaForWaiter()
    {
        if (table.isCame[tableNo] == true)
        {
            if (waiter.GetComponent<CollectManagerWaiter>().pizzaList.Count > 0)
            {
                if (table.isTableEmpty[tableNo] == false)
                {
                    if (customers.Count > 0)
                    {
                        if (pizzaGived < table.pizzaOrder[tableNo] && table.pizzaOrder[tableNo] > 0)
                        {
                            Destroy(waiter.GetComponent<CollectManagerWaiter>().pizzaList[waiter.GetComponent<CollectManagerWaiter>().pizzaList.Count - 1]);
                            waiter.GetComponent<CollectManagerWaiter>().pizzaList.RemoveAt(waiter.GetComponent<CollectManagerWaiter>().pizzaList.Count - 1);
                            waiter.GetComponent<CollectManagerWaiter>().yukseklik--;
                            pizzaGived++;
                        }
                    }
                }
            }
        }
    }

    //Müþteriler Masaya Geldi Mi Kontrolü
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AI"))
        {
            table.isCame[tableNo] = true;
            isCame = true;
        }
        if (other.gameObject.CompareTag("Character"))
        {
            if(moneyList.Count > 0)
            {
                if (isTakeMoney)
                {
                    isTakeMoney = false;
                    StartCoroutine(CollectingCoin());
                }
              
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("AI"))
        {

            if (level.GetComponent<SpawnerArea>().level == 1)
            {
                canvas.SetActive(true);
                burgerNeeded = table.burgerOrder[tableNo];
                burgerNeededText = burgerNeeded;
                burgerNeededText = burgerNeeded - burgerGived;
                burgerText.text = burgerNeededText.ToString();
            }
            if (level.GetComponent<SpawnerArea>().level == 2)
            {
                canvas.SetActive(true);
                burgerNeeded = table.burgerOrder[tableNo];
                burgerNeededText = burgerNeeded;
                burgerNeededText = burgerNeeded - burgerGived;
                burgerText.text = burgerNeededText.ToString();


                pizzaNeeded = table.pizzaOrder[tableNo];
                pizzaNeededText = pizzaNeeded;
                pizzaNeededText = pizzaNeeded - pizzaGived;
                pizzaText.text = pizzaNeededText.ToString();
            }

            if (level.GetComponent<SpawnerArea>().level == 3)
            {
                canvas.SetActive(true);
                hotDogNeeded = table.hutDogOrder[tableNo];
                hotdogNeededText = hotDogNeeded;
                hotdogNeededText = hotDogNeeded - hotDogGived;
                hotDogText.text = hotdogNeededText.ToString();


                pizzaNeeded = table.pizzaOrder[tableNo];
                pizzaNeededText = pizzaNeeded;
                pizzaNeededText = pizzaNeeded - pizzaGived;
                pizzaText.text = pizzaNeededText.ToString();
            }
        }
    }





    //Müþterilerin Yemek Yeme Kontrolü
    public void Eating()
    {
        if (level.GetComponent<SpawnerArea>().level == 1)
        {
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (burgerGived > 0)
                        {
                            if (eatenList.Count > 0)
                            {
                                if (timer > 3.0f)
                                {
                                    timer = 0f;
                                    Destroy(eatenList[eatenList.Count - 1]);
                                    eatenList.RemoveAt(eatenList.Count - 1);
                                    eatedBurger++;
                                }
                            }
                        }
                    }
                }
            }
        }


        if (level.GetComponent<SpawnerArea>().level == 2)
        {
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (burgerGived > 0)
                        {
                            if (eatenList.Count > 0)
                            {
                                if(eatedBurger != burgerGived)
                                {
                                    if (timer > 3.0f)
                                    {
                                        timer = 0f;
                                        Destroy(eatenList[eatenList.Count - 1]);
                                        eatenList.RemoveAt(eatenList.Count - 1);
                                        eatedBurger++;
                                    }
                                }
                               
                            }
                        }
                    }
                }
            }
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (pizzaGived > 0)
                        {
                            if (eatenList.Count > 0)
                            {
                                if(eatedPizza != pizzaGived)
                                {
                                    if (timer2 > 3.0f)
                                    {
                                        timer2 = 0f;
                                        Destroy(eatenList[eatenList.Count - 1]);
                                        eatenList.RemoveAt(eatenList.Count - 1);
                                        eatedPizza++;
                                    }
                                }
                            
                            }
                        }
                    }
                }
            }
        }

        if (level.GetComponent<SpawnerArea>().level == 3)
        {
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (hotDogGived > 0)
                        {
                            if (eatenList.Count > 0)
                            {
                                if (eatedHotdog != hotDogGived)
                                {
                                    if (timer > 3.0f)
                                    {

                                        timer = 0f;
                                        Destroy(eatenList[eatenList.Count - 1]);
                                        eatenList.RemoveAt(eatenList.Count - 1);
                                        eatedHotdog++;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (pizzaGived > 0)
                        {
                            if (eatenList.Count > 0)
                            {
                                if (eatedPizza != pizzaGived)
                                {
                                    if (timer2 > 3.0f)
                                    {
                                        timer2 = 0f;
                                        Destroy(eatenList[eatenList.Count - 1]);
                                        eatenList.RemoveAt(eatenList.Count - 1);
                                        eatedPizza++;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AI"))
        {
            table.isCame[tableNo] = false;
            isCame = false;
            canvas.SetActive(false);
        }
    }

    private void Update()
    {
        if(level.GetComponent<SpawnerArea>().level == 1)
        {
            //Müþterilerin Para Býrakýp Gitmesi
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (eatedBurger == burgerNeeded)
                        {
                            eatedBurger = 0;
                            StartCoroutine(MoneyCreater((hotDogNeeded + pizzaNeeded + burgerNeeded) * oneBurgerMoney));
                            musterileriKov();

                            if (isCustomerEatedMeal)
                            {
                                isCustomerEatedMeal = false;
                                customers.Clear();
                                table.ClearTable(tableNo);
                                burgerGived = 0;
                                eatedBurger = 0;
                                burgerNeededText = 0;
                            }
                        }
                    }
                }
            }
        }

        if (level.GetComponent<SpawnerArea>().level == 2)
        {
            //Müþterilerin Para Býrakýp Gitmesi
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (eatedBurger == burgerNeeded)
                        {
                            if(eatedPizza == pizzaNeeded)
                            {
                                eatedPizza = 0;

                                StartCoroutine(MoneyCreater((hotDogNeeded + pizzaNeeded + burgerNeeded) * oneBurgerMoney));
                                musterileriKov();
                            }
                            if (isCustomerEatedMeal)
                            {
                                money = 0;
                                isCustomerEatedMeal = false;
                                customers.Clear();
                                table.ClearTable(tableNo);
                                burgerGived = 0;
                                eatedBurger = 0;
                                burgerNeededText = 0;

                                pizzaGived = 0;
                                eatedPizza = 0;
                                pizzaNeededText = 0;
                         
                            }
                        }
                    }
                }
            }
        }

        if (level.GetComponent<SpawnerArea>().level == 3)
        {
            //Müþterilerin Para Býrakýp Gitmesi
            if (table.isTableEmpty[tableNo] == false)
            {
                if (customers.Count > 0)
                {
                    if (table.isCame[tableNo] == true)
                    {
                        if (eatedHotdog == hotDogNeeded)
                        {
                            if (eatedPizza == pizzaNeeded)
                            {
                                eatedPizza = 0;
                                StartCoroutine(MoneyCreater((hotDogNeeded + pizzaNeeded + burgerNeeded) * oneBurgerMoney));
                                musterileriKov();
                            }
                            if (isCustomerEatedMeal)
                            {
                                isCustomerEatedMeal = false;
                                customers.Clear();
                                table.ClearTable(tableNo);
                                hotDogGived = 0;
                                eatedHotdog = 0;
                                hotdogNeededText = 0;

                                pizzaGived = 0;
                                eatedPizza = 0;
                                pizzaNeededText = 0;

                            }
                        }
                    }
                }
            }
        }

        //Müþterilerin Yemek Yeme Süresi
        if (eatenList.Count > 0)
        {
            timer += Time.deltaTime;
        }
        //Müþterilerin Yemek Yeme Süresi
        if (eatenList.Count > 0)
        {
            timer2 += Time.deltaTime;
        }
        Eating();
        //Müþteriler Geldiyse Burger Ýstesinler
        if (customers.Count > 0)
        {
            if(level.GetComponent<SpawnerArea>().level == 1)
            {
                burgerNeeded = table.burgerOrder[tableNo];
            }
            if(level.GetComponent<SpawnerArea>().level == 2)
            {
                pizzaNeeded = table.pizzaOrder[tableNo];
                burgerNeeded = table.burgerOrder[tableNo];
            }
            if (level.GetComponent<SpawnerArea>().level == 3)
            {
                pizzaNeeded = table.pizzaOrder[tableNo];
                hotDogNeeded = table.hutDogOrder[tableNo];
            }

        }
    }

    IEnumerator MoneyCreater(int amount)
    {
        
            for (int i = 0; i < amount; i++)
            {
                GameObject mpref = Instantiate(moneyPref);
                mpref.transform.position = new Vector3(moneyDropPoint.position.x, moneyDropPoint.position.y, moneyDropPoint.position.z);
                moneyList.Add(mpref);
                yield return new WaitForSeconds(0.1f);
            }
            isTakeMoney = true;
            yield return null;
          
    }
    IEnumerator CollectingCoin()
    {
       
        for (int i = moneyList.Count; i > 0; i--)
        {
            moneyList[i - 1].GetComponent<CoingLerping>().isCollectingNow = true;

            yield return new WaitForSeconds(0.1f);
        }
        moneyList.Clear();
        yield return null;
    }


    // müþteriyi restorandan göndermek için
    public void musterileriKov()
    {
        foreach (GameObject gameObject in customers)
            gameObject.GetComponent<NavMesh>().LeaveRestourant();

        isCustomerEatedMeal = true;
    }
}