using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manazer : MonoBehaviour

    
{
    private List<GameObject> balik = new List<GameObject>();
    public GameObject prefabKarty;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 11; i++)
        {
        balik.Add(Instantiate( prefabKarty,
                                new Vector3(i,0,0),
                                Quaternion.identity
                                )
            );

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
