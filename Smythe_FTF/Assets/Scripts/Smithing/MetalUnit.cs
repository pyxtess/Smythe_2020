using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalUnit : MonoBehaviour
{
    public string MetalName;

    //Bones
    public GameObject[] spine;
    public GameObject[] leftEdge;
    public GameObject[] rightEdge;
    
    //Width
    public float MaxConsolidation;
    //Length
    public float MaxSpread;
    //Brittlness (Critical Fail Threshold)
    public float Porosity;
}
