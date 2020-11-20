using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Compass : MonoBehaviour
{
    public Vector3 north;
    public Transform player;
    public RectTransform northLayer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        changeNorth();
    }
    void changeNorth(){
        north.z = -player.eulerAngles.y;
        northLayer.localEulerAngles = north;
    }
}
