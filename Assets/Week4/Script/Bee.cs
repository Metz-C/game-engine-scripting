using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Bee : MonoBehaviour
{
    private Beehive hive;

    public void Init(Beehive hive)
    {
        this.hive = hive;
    }

    void Update()
    {
        
        CheckAnyFlower();
    }

   
    private void CheckAnyFlower()
    {

        Flower[] flowers = FindObjectsOfType<Flower>();

        foreach (Flower flower in flowers)
        {
            if (flower.nectarAvailable())
            {
               
                transform.DOMove(flower.transform.position, 1f).OnComplete(() =>
                {
                    
                    if (flower.canTakeNectar())
                    {
                        
                        transform.DOMove(hive.transform.position, 1f).OnComplete(() =>
                        {
                            hive.GiveNectar();
                        
                            CheckAnyFlower();
                        }).SetEase(Ease.Linear);
                    }
                    else
                    {
                       CheckAnyFlower();
                    }
                }).SetEase(Ease.Linear);
            }
        }
    }

}
