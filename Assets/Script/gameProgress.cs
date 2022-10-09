using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameProgress : MonoBehaviour
{
    public float playerLive = 10;

    public float coinCollectedCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // method untuk ngurangi nilai nyawa
    public float liveDecrease(){
        playerLive--;
        return playerLive;
    }

    // method untuk menambah nilai koin
    public float coinCollected(){
        coinCollectedCount++;
        return coinCollectedCount;
    }
}
