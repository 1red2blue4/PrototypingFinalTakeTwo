using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private UnitScript unitType; 

    /*[SerializeField]
     private Stat attack;

     [SerializeField]
     private Stat speed;

     [SerializeField]
     private Stat range;

     [SerializeField]
     private Stat cost;*/

    private void Awake()
    {
        health.Initialize();
       /* attack.Initialize();
        speed.Initialize();
        range.Initialize();
        cost.Initialize();*/
    }

    // Update is called once per frame
    void Update ()
    {
        //float linesOfInfo = unitType.unitSpeed;

        health.CurrentVal = 65;// GameObject.Find("YourBase1").GetComponent<UnitScript>().unitHealth;
        /* if (Input.GetKeyDown(KeyCode.Q))
         {
             health.CurrentVal -= 10;
         }
         if (Input.GetKeyDown(KeyCode.W))
         {
             health.CurrentVal += 10;
         }*/
    }
}
