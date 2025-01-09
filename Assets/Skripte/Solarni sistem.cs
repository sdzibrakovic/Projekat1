using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.MemoryProfiler;
using UnityEngine;



public class Solarnisistem : MonoBehaviour
{
    public GameObject[] SolarniSistem; 
    public Vector3 rotationAxis = new Vector3(0, 1, 0); 
    public float rotationSpeed = 50f; 
    private float[] rotationSpeeds; 
    private GameObject mesec;
    private GameObject zemlja;
    private Vector3 pozicijaZemlje;

    void Start()
    {
      
        zemlja = transform.Find("Zemlja").gameObject;
        mesec = zemlja.transform.Find("Mesec").gameObject;

        rotationSpeeds = new float[SolarniSistem.Length];
        for (int i = 0; i < SolarniSistem.Length; i++)
        {
            rotationSpeeds[i] = Random.Range(0.5f, rotationSpeed); 
        }
    }

    void Update()
    {
 
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

     
        for (int i = 0; i < SolarniSistem.Length; i++)
        {
            SolarniSistem[i].transform.RotateAround(transform.position, Vector3.up, rotationSpeeds[i] * Time.deltaTime);
        }

    
        if (mesec != null && zemlja != null)
        {
            pozicijaZemlje = zemlja.transform.position;
            mesec.transform.RotateAround(pozicijaZemlje, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
