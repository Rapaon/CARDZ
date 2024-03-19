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
                    if (hit.collider.gameObject.GetComponent<karta>().mozeSaKliknut)
                    {
                        if (jeNatahuhrac1)
                        {
                            volba1 = hit.collider.gameObject;
                            jeNatahuhrac1 = false;
                        }
                        else
                        {
                            volba2 = hit.collider.gameObject;
                            jeNatahuhrac1 = true;

                            if (volba1 != null && volba2 != null)
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
}
