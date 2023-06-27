using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoingLerping : MonoBehaviour
{
    public GameObject players;
    public float desiredDuration = 3.0f;
    public float timer3;
    public bool isCollectingNow;
    public void Lerping()
    {
        players = GameObject.FindGameObjectWithTag("Character");
        //timer3 += Time.deltaTime;
        //float percentageComple = timer3 / desiredDuration;
       transform.position = Vector3.Lerp(transform.position, players.transform.position + (Vector3.up * 2), 10 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character") && isCollectingNow)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(isCollectingNow == true)
        {
            Lerping(); 
        }
    }
}
