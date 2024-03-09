using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Beehive : MonoBehaviour
{
    public GameObject beePrefab;
    private List<Bee> bees = new List<Bee>();

    
    //timer, will count down if only it has honey
    public float honeyProduction = 1.0f;

    //starting number of bees
    public int beePopulation = 3;

    //int for nectar it has
    private int nectar = 0;

    //int for honey it has
    private int honey = 0;

    //hive timer
    private float hiveTimer = 0;

   
    void Start()
    {
        
        for (int i = 0; i < beePopulation; i++)
        {
            GameObject beeObj = Instantiate(beePrefab, transform.position, UnityEngine.Quaternion.identity);
            Bee bee = beeObj.GetComponent<Bee>();
            bee.Init(this); // Pass the hive reference to the bee
            bees.Add(bee);
        }
    }

    void Update()
    {
       
        if (nectar > 0)
        {
            hiveTimer -= Time.deltaTime;
            if (hiveTimer <= 0)
            {
                
                nectar--;
                honey++;
                hiveTimer = 1.0f / honeyProduction;
                if (nectar > 0)
                {
                    hiveTimer = 1.0f / honeyProduction;
                }

            }
        }

    }

    public void GiveNectar()
    {
        nectar++;
        if (hiveTimer <= 0)
        {
            hiveTimer = 1.0f / honeyProduction;
        }
    }

}
