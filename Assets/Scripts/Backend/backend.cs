using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class backend : MonoBehaviour
{
    //kontoens identifikation
    string account;

    //mengden af bankkontoer man har lov til at have
    string[] money = new string[5];

    //display af bankkontoer
    public TextMeshProUGUI penge1;
    public TextMeshProUGUI penge2;
    public TextMeshProUGUI penge3;

    //oop adgang til det andet script
    public GameObject accountscript;
    // Start bliver kaldet når ==mainmenu== bliver sat som aktivt
    void Start()
    {
        //her får vi fat i det andet script så vi kan bruge verdien "filename" og skriven den ind til account verdien
        if (this.isActiveAndEnabled == true) { account = accountscript.GetComponent<loginphase>().filename; }

        //her læser vi filen under navnet der er givet til account verdien
        System.IO.StreamReader objreader = new System.IO.StreamReader(account);

        //et for loop der tager hver linje og propper dem ind i seperate ankkontoer
        for (int i = 0; i < money.Length; i++)
        {
            money[i] = objreader.ReadLine();
        }
        //til display
        penge1.text = "konto 1      " + money[0] + " DKK";
        penge2.text = "konto 2      " + money[1] + " DKK";
        penge3.text = "konto 3      " + money[2] + " DKK";

    }

    public void konto1()
    {
        ScreenTransitionManagaer.GetInstance().LoginScreenSlideLeft();
    }
    public void konto2()
    {

    }
    public void konto3()
    {

    }
}
