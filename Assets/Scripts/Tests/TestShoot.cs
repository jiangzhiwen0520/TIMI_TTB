using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShoot : MonoBehaviour
{
    // Start is called before the first frame update
    private bool s = false;
    private GameObject[] objects ;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        s = !s;
        objects = GameObject.FindGameObjectsWithTag("VirusFiles");
        foreach (GameObject v in objects) {
            v.GetComponent<VirusProduction>().SetCanShoot(s);
        }
        objects = GameObject.FindGameObjectsWithTag("RVFiles");
        foreach (GameObject v in objects)
        {
            v.GetComponent<VirusProduction>().SetCanShoot(s);
        }
    }
}
