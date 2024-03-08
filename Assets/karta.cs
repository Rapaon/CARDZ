using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class karta : MonoBehaviour
{
    public TextMeshProUGUI tmpZivot;
    public int HP;
    public int DMG;
    public int IQ;
    public int DF;
    public bool mozeSaKliknut;
    public string meno;
    public string element;
    // Start is called before the first frame update
    void Start()
    {
         tmpZivot.text = HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void UpdateText()
    {
        print("karolcik");
        tmpZivot.text= HP.ToString();
    }
}
