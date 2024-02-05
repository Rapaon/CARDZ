using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manazer : MonoBehaviour

    
{
    public List<GameObject> balik = new List<GameObject>();
    public List<GameObject> hrac1 = new List<GameObject>();
    public List<GameObject> hrac2 = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        rozdajKarty();

        



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rozdajKarty()
    {
        for (int i = 0; i < 5; i++)
        {
            hrac1.Add(balik[i]);
            hrac2.Add(balik[i + 5]);
        }
        Instantiate(hrac1[0], new Vector3(-34, 16, 0), Quaternion.identity);
        Instantiate(hrac1[1], new Vector3(-17, 16, 0), Quaternion.identity);
        Instantiate(hrac1[2], new Vector3(0, 16, 0), Quaternion.identity);
        Instantiate(hrac1[3], new Vector3(17, 16, 0), Quaternion.identity);
        Instantiate(hrac1[4], new Vector3(34, 16, 0), Quaternion.identity);

        Instantiate(hrac2[0], new Vector3(-34, -16, 0), Quaternion.identity);
        Instantiate(hrac2[1], new Vector3(-17, -16, 0), Quaternion.identity);
        Instantiate(hrac2[2], new Vector3(0, -16, 0), Quaternion.identity);
        Instantiate(hrac2[3], new Vector3(17, -16, 0), Quaternion.identity);
        Instantiate(hrac2[4], new Vector3(34, -16, 0), Quaternion.identity);
        
        for (int i = 0; i < hrac1.Count; i++)
        {
            hrac1[i].GetComponent<karta>().mozeSaKliknut = true;
            hrac2[i].GetComponent<karta>().mozeSaKliknut = false;
            
        }
        
    }

}
