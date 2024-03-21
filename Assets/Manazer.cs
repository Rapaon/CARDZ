using System.Collections.Generic;
using UnityEngine;

public class Manazer : MonoBehaviour
{
    public List<GameObject> balik = new List<GameObject>();
    public List<GameObject> hrac1 = new List<GameObject>();
    public List<GameObject> hrac2 = new List<GameObject>();
    public Camera kamera;
    private GameObject volba1, volba2;
    private bool jeNatahuhrac1 = true;

    void Start()
    {
        rozdajKarty();
    }

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
<<<<<<< HEAD
                    

                    if (hit.collider.gameObject.GetComponent<karta>().mozeSaKliknut)
                    {

                        if (jeNatahuhrac1 == true)
                        {
                            volba1 = hit.collider.gameObject;
                            // hit.collider.gameObject.GetComponent<karta>().HP -= hit.collider.gameObject.GetComponent<karta>().DMG;
                            //hit.collider.gameObject.GetComponent<karta>().UpdateText();
                            print("hrac1");
                            //print(volba1.GetComponent<karta>().meno);

                            //if (utoci == 0)
                            //{
                            //    utoci = 1;

                           //     volba1.transform.GetChild(0).gameObject.SetActive(false);
                            //}
                            //else
                            //{
                             //   utoci = 0;
                             //
                               // volba1.transform.GetChild(0).gameObject.SetActive(true);
                            //}

=======
                    if (hit.collider.gameObject.GetComponent<karta>().mozeSaKliknut)
                    {
                        if (jeNatahuhrac1)
                        {
                            volba1 = hit.collider.gameObject;
>>>>>>> 4fe9ee1be60df8e96d05864aae4dae4e9c920ed6
                            jeNatahuhrac1 = false;
                        }
                        else
                        {
                            volba2 = hit.collider.gameObject;
<<<<<<< HEAD

                            volba2.GetComponent<karta>().HP -= volba1.GetComponent<karta>().DMG;
                            volba2.GetComponent<karta>().UpdateText();
                            print("hrac2");
                            //print(volba2.GetComponent<karta>().meno);

                            volba2.transform.GetChild(0).gameObject.SetActive(true);
                            Invoke("ResetUtoci", 1f);


                            jeNatahuhrac1 = false;
                            for (int i = 0; i < hrac1.Count; i++)
=======
                            jeNatahuhrac1 = true;

                            if (volba1 != null && volba2 != null)
>>>>>>> 4fe9ee1be60df8e96d05864aae4dae4e9c920ed6
                            {
                                volba1.GetComponent<karta>().HP -= volba2.GetComponent<karta>().DMG;
                                volba1.GetComponent<karta>().UpdateText();
                                print("Hrac 2 útoèí na Hráè 1. Zbývající HP hráèe 1: " + volba1.GetComponent<karta>().HP);
                                if (volba1.GetComponent<karta>().HP < 1)
                                {
                                    volba1.GetComponent<SpriteRenderer>().material.SetFloat("_GrayscaleAmount", 1f);
                                    volba1.GetComponent<karta>().mozeSaKliknut = false;
                                }
                                volba1 = null;
                                volba2 = null;
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
            int poradie = Random.Range(0, balik.Count);
            h1.Add(balik[poradie]);
            balik.RemoveAt(poradie);
        }
        for (int i = 0; i < 5; i++)
        {
            int poradie = Random.Range(0, balik.Count);
            h2.Add(balik[poradie]);
            balik.RemoveAt(poradie);
        }

        for (int i = 0; i < 5; i++)
        {
            hrac1.Add(Instantiate(h1[i], new Vector3(-34 + i * 17, 16, 1), Quaternion.identity));
            hrac2.Add(Instantiate(h2[i], new Vector3(-34 + i * 17, -16, 1), Quaternion.identity));
        }

        for (int i = 0; i < 5; i++)
        {
            hrac1[i].GetComponent<karta>().mozeSaKliknut = true;
            hrac2[i].GetComponent<karta>().mozeSaKliknut = true;
        }
    }
<<<<<<< HEAD
    void ResetUtoci()
    {
        volba2.transform.GetChild(0).gameObject.SetActive(false);
    }

=======
>>>>>>> 4fe9ee1be60df8e96d05864aae4dae4e9c920ed6
}
