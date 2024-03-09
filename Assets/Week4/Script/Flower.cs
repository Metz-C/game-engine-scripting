using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject beePrefab;

    //Flower rate of nectar production
    public float nectarProduction = 1.0f;
    
    //Float that handles counting
    public float nectarProductionCounter = 0.0f;

    //Bool for if flower has Nectar
    private bool flowerHasNectar = true;

    public Color nectarReadyColor; 
    public Color noNectarColor; 
    private SpriteRenderer flowerRenderer;






    // Start is called before the first frame update
    void Start()
    {
        flowerRenderer = GetComponent<SpriteRenderer>();
        flowerRenderer.color = noNectarColor;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if there is no nectar in a flower

        if (!flowerHasNectar)
        {
            if (!flowerHasNectar)
            {
                nectarProductionCounter += Time.deltaTime;
                if (nectarProductionCounter >= nectarProduction)
                {
                    
                    flowerHasNectar = true;
                    nectarProductionCounter = 0.0f;
                    flowerRenderer.color = nectarReadyColor;

                }
            }
        }
        
    }

    //to show if there is nectar available
    public bool nectarAvailable()
    {
        return flowerHasNectar ;
    }

  
    public bool canTakeNectar()
    {
        if (flowerHasNectar)
        {
            flowerHasNectar = false;
            nectarProductionCounter = 0.0f;
            flowerRenderer.color = noNectarColor; 
            return true; 
        }
        else
        {
            return false; 
        }
    }


}
