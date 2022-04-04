using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopoUP : MonoBehaviour
{
    [SerializeField]
    Text startText, salonText, toiletText, garageText, cuisineText;
    
    [SerializeField]
    Image back;

    [SerializeField]
    float maxTime = 1;

    float timeValue;
    float timeSalonValue;
    float timeToiletteValue;
    float timeGarageValue;
    float timeCuisineValue;



    bool inSalon = true;
    bool inToilette = true;
    bool inGarage = true;
    bool inCuisine = true;




    private void Start()
    {
        salonText.enabled = false;
        toiletText.enabled = false;
        garageText.enabled = false;
        cuisineText.enabled = false;
    }

    private void Update()
    {
        StartText();    
    }

    void StartText()
    {
        if (timeValue <= maxTime)
        {
            timeValue += Time.deltaTime;
        }
        else
        { 
            timeValue = maxTime;
            startText.enabled = false;
            back.enabled = false;
        }
    }
    public void SalonText()
    {  
        if(inSalon == true)
        {
            salonText.enabled = true;
            back.enabled = true;

            if (timeSalonValue <= maxTime)
            {
                timeSalonValue += Time.deltaTime;
            }
            else
            {
                timeSalonValue = maxTime;
                salonText.enabled = false;
                back.enabled = false;
                inSalon = false;
            }
        }
        
        
        
    }

    public void ToiletteText()
    {
        if (inToilette == true)
        {
            toiletText.enabled = true;
            back.enabled = true;

            if (timeToiletteValue <= maxTime)
            {
                timeToiletteValue += Time.deltaTime;
            }
            else
            {
                timeToiletteValue = maxTime;
                toiletText.enabled = false;
                back.enabled = false;
                inToilette = false;
            }
        }
        
    }

    public void GarageText()
    {
        if (inGarage == true)
        {
            Debug.Log("la");
            garageText.enabled = true;
            back.enabled = true;

            if (timeGarageValue <= maxTime)
            {
                timeGarageValue += Time.deltaTime;
            }
            else
            {
                timeGarageValue = maxTime;
                garageText.enabled = false;
                back.enabled = false;
                inGarage = false;
            }
        }

    }

    public void CuisneText()
    {
        if (inCuisine == true)
        {
            cuisineText.enabled = true;
            back.enabled = true;

            if (timeCuisineValue <= maxTime)
            {
                timeCuisineValue += Time.deltaTime;
            }
            else
            {
                timeCuisineValue = maxTime;
                cuisineText.enabled = false;
                back.enabled = false;
                inCuisine = false;
            }
        }

    }
}
