using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Manazer : MonoBehaviour


{

    public List<GameObject> balik = new List<GameObject>();
    public List<GameObject> hrac1 = new List<GameObject>();
    public List<GameObject> hrac2 = new List<GameObject>();
    public Camera kamera;

    private bool jeNatahuhrac1 = true;

    // Start is called before the first frame update
    void Start()
    {
        rozdajKarty();
    }

    // Update is called once per fram
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = kamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "karta")
                {
                   
                    if (hit.collider.gameObject.GetComponent<karta>().mozeSaKliknut)
                    {
                        if (jeNatahuhrac1 == true)
                        {
                            print("hrac1");
                            print(hit.collider.gameObject.GetComponent<karta>().meno);
                            jeNatahuhrac1 = false;
                            for (int i = 0; i < hrac1.Count; i++)
                            {
                                hrac1[i].GetComponent<SpriteRenderer>().material.SetFloat("_GrayscaleAmount", 1f);
                                hrac1[i].GetComponent<karta>().mozeSaKliknut = false;

                            }
                            for (int i = 0; i < hrac2.Count; i++)
                            {
                                hrac2[i].GetComponent<SpriteRenderer>().material.SetFloat("_GrayscaleAmount", 0f);
                                hrac2[i].GetComponent<karta>().mozeSaKliknut = true;
                            }
                        }
                        else
                        {
                            print("hrac2");
                            print(hit.collider.gameObject.GetComponent<karta>().meno);
                            jeNatahuhrac1 = true;
                            for (int i = 0; i < hrac1.Count; i++)
                            {
                                hrac1[i].GetComponent<karta>().mozeSaKliknut = true;
                                hrac1[i].GetComponent<SpriteRenderer>().material.SetFloat("_GrayscaleAmount", 0f);
                            }
                            for (int i = 0; i < hrac2.Count; i++)
                            {
                                hrac2[i].GetComponent<karta>().mozeSaKliknut = false;
                                hrac2[i].GetComponent<SpriteRenderer>().material.SetFloat("_GrayscaleAmount", 1f);
                            }
                        }


                    }
                }
            }   
        }

    }

    void rozdajKarty()
    {
        List<GameObject> h1 = new List<GameObject>();
        List<GameObject> h2 = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            int poradie = Random.Range(0, balik.Count); // vymysli si cislo od 0 po POCETvLISTE
            h1.Add(balik[poradie]); // prida hracovi 1 vec z balika podla vymysleneho cisla
            balik.RemoveAt(poradie); // z balika danu vec odstranu na zaklade poradoveho cisla
            
        }
        for (int i = 0; i < 5; i++)
        {
            int poradie = Random.Range(0, balik.Count);
            h2.Add(balik[poradie]);
            balik.RemoveAt(poradie);
            
        }

        hrac1.Add(Instantiate(h1[0], new Vector3(-34, 16, 0), Quaternion.identity));
        hrac1.Add(Instantiate(h1[1], new Vector3(-17, 16, 0), Quaternion.identity));
        hrac1.Add(Instantiate(h1[2], new Vector3(0, 16, 0), Quaternion.identity));
        hrac1.Add(Instantiate(h1[3], new Vector3(17, 16, 0), Quaternion.identity));
        hrac1.Add(Instantiate(h1[4], new Vector3(34, 16, 0), Quaternion.identity));

        hrac2.Add(Instantiate(h2[0], new Vector3(-34, -16, 0), Quaternion.identity));
        hrac2.Add(Instantiate(h2[1], new Vector3(-17, -16, 0), Quaternion.identity));
        hrac2.Add(Instantiate(h2[2], new Vector3(0, -16, 0), Quaternion.identity));
        hrac2.Add(Instantiate(h2[3], new Vector3(17, -16, 0), Quaternion.identity));
        hrac2.Add(Instantiate(h2[4], new Vector3(34, -16, 0), Quaternion.identity));


        for (int i = 0; i < 5; i++)
        {
            hrac1[i].GetComponent<karta>().mozeSaKliknut = true; 
            hrac2[i].GetComponent<karta>().mozeSaKliknut = false;

        }



    }


}
