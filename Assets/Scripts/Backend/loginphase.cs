using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loginphase : MonoBehaviour
{
    
    string username;
    string password;
    public string combined;
    public string filename;

    public GameObject homescreen;

    // Start is called before the first frame update
    void Start()
    {
        //slår homescreen fra
        homescreen.SetActive(false);
        
        //her laver vi en sample account der automatisk bliver skabt når man åbner programmet
        //så man kan få et eksempel på hvordan en typisk bruger af programmet ser ud
        filename = "sample1sample";
        System.IO.StreamWriter objwriter = new System.IO.StreamWriter(filename);
        objwriter.WriteLine(100);
        objwriter.WriteLine(123);
        objwriter.WriteLine(111);
        objwriter.Close();
    }

    //gæmmer username verdien når der bliver redigeret i tekstboksen "username"
    public void loginUsername(string user) { username = user; }

    //gæmmer password verdien når der bliver redigeret i tekstboksen "password"
    public void LoginpassWord(string pass) { password = pass; }
    
    //når login knappen bliver aktiveret tjekker den om logkritirierne paser med en kontofil
    public void loginCheck()
    {
        combined = username + "1" + password;
        print(combined);
        System.IO.StreamReader objreader = new System.IO.StreamReader(combined);
        if (objreader != null)
        {
            print("yes");
            homescreen.SetActive(true);
            ScreenTransitionManagaer.GetInstance().LoginScreenSlideLeft();
            filename = combined;
        }
        
    }
    //skaber en kontofil når knappen bliver aktiveret så længe at der ikke allerade eksistere 
    public void adduser()
    {
        combined = username + "1" + password;
        Debug.Log(System.IO.File.Exists(combined));
        print("pressed");
        
        //hvis filen allerade eksistere skaber den ikke en ny fil
        if (System.IO.File.Exists(combined))
        {
            print("it exists");
        }
        else
        {
            filename = combined;
            System.IO.StreamWriter objwriter = new System.IO.StreamWriter(filename);
            objwriter.Write(0);
            objwriter.Close();
            print("added");
        }
        
    }
}
