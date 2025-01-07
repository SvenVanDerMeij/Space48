using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] public static float moveSpeed = 5f;
    [SerializeField] public static float rotationSpeed = 25f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] public static float cooldownTime = 3f;
    [SerializeField] public static Image itemImageHolder;
    [SerializeField] private TMP_Text messageField;

    private float cooldownCounter = 0f;
    
    public static int activeItemIndex = -1;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {      
        Shoot();
    }

    
    void Shoot() { 
        cooldownCounter += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item")) {
            gameObject.GetComponent<ItemUse>().PickUpItem(other.gameObject);
        }
    }
    
    
   

    /*TO DO 
    
    Optie 1:

    void GetHit(){ 
        //zorg voor enemies die terugschieten. Als je geraakt wordt gaan er levens af. als je levens op zijn ben je af en herstart de game.
    }  
    void HealthBoost(){ 
        //zorg voor een extra powerup die je een health boost geeft
    }

    Optie 2:

    void ActivateShield(){ 
        //Zorg voor een energie schild dat aangezet kan worden     
    }
    void DeactivateShield(){
        //Zorg dat je het schild uit kunt zetten om energie te sparen
    }
    void CheckShieldEnergy(){
        //zorg dat je energie op gaat bij gebruik van het schild
        //is de energie op dan gaat het schild uit
    }
    void RegenerateShield(){
        //Zorg dat je schild langzaam regenereert
    } 

    */

}
