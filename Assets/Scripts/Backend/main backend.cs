using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainbackend : MonoBehaviour
{
    string account;
    int[] money = new int[5];
    string line;
    public TextMeshProUGUI penge1;
    public TextMeshProUGUI penge2;
    public TextMeshProUGUI penge3;
    // Start is called before the first frame update
    void Start()
    {
        GameObject accountscript = GameObject.Find("loginphase");
        account = accountscript.GetComponent<loginphase>().filename;
        System.IO.StreamReader objreader = new System.IO.StreamReader(account);
        for(int i = 0; i < money.Length; i++)
        {
            money[i] = int.Parse(objreader.ReadLine());
        }
        penge1.text = money[1].ToString();
        penge2.text = money[2].ToString();
        penge3.text = money[3].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
