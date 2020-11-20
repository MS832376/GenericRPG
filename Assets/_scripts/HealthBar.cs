using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private static Image HealthBarImage;
    public static void SetHealthBarValue(float value){
        HealthBarImage.fillAmount = value;
        if(HealthBarImage.fillAmount <= 0.3f){
            SetHealthBarColor(Color.red);
        }else if(HealthBarImage.fillAmount <= 0.5f){
            SetHealthBarColor(Color.yellow);
        }else{
            SetHealthBarColor(Color.green);
        }
    }
    public static float GetHealthBarValue(){
        return HealthBarImage.fillAmount;
    }

    public static void SetHealthBarColor(Color theColor){
        HealthBarImage.color = theColor;
    }

    void Awake(){
        HealthBarImage = GetComponent<Image>();
    }
}
