using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransitionManagaer : MonoBehaviour
{

    private static ScreenTransitionManagaer instance;

    public Animator InitialScreenAnimator;
    public Animator LoginScreenAnimator;
    public Animator CardsScreenAnimator;
    public Animator AccountsUsageAnimator;
    public Animator CanvasAnimator;
    public Animator HomeScreenAnimator;

    [Header("Screen gameobjects")]
    public GameObject AccountsScreen;
    public GameObject CardsScreen;
    public GameObject AccountUsageScreen;
    public GameObject UsageScreen;
    public GameObject InitialScreen;
    public GameObject MainMenuScreen;

    [Header("Home Buttons")]
    public Button HomeCardsBtn;
    public Button HomeAccountsUsageBtn;

    [Header("Cards Screen buttons")]
    public Button CardsHomeBtn;
    public Button CardsAccountsUsageBtn;

    [Header("Accounts Usage buttons")]
    public Button AccountsUsageHomeBtn;
    public Button AccountsUsageCardsBtn;
    

    [Header("Canvas Components")]
    public Canvas CardsCanvas;
    public Canvas AccountsCanvas;
    public Canvas AccountUsageCanvas;
    public Canvas UsageCanvas;
    public Canvas MainMenuCanvas;



    [Header("Screen positions")]
    
    public Transform LeftSideOfScreen;
    
    public Transform MiddleOfScreen;
    
    public Transform InitialScreenPosition;
    
    public GameObject[] LeftSideScreens;
    
    public GameObject[] MiddleScreens;
    
    [Header("Misc")]
    public GameObject CurrentScreen;
    public GameObject[] OnStartDeactivatedScreens;
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one ScreenTransitionManagaer in the scene");
        }

        instance = this;

        //which screens are supposed to be deactivated, to allow the user to navigate from home? 
        foreach (GameObject AllScreen in OnStartDeactivatedScreens)
        {
            AllScreen.SetActive(false);
        }


        //Where is the middle of the screen, for screens that dont move?
        MiddleOfScreen.position = InitialScreenPosition.position;

        //where does all the screens which come in from the left side have to be when the program launches?
        foreach (GameObject screens in LeftSideScreens)
        {
            screens.transform.position = LeftSideOfScreen.position;
        }

        //Where does all the screens which have to stay in the middle from the beginning have to be when program launches?
        foreach (GameObject MiddleScreensGB in MiddleScreens)
        {
            MiddleScreensGB.transform.position = MiddleOfScreen.position;
        }


        //which screen is the current one in the beginning? 
        CurrentScreen = MainMenuScreen;


        //what should each of the buttons on the main menu have as a function when clicked?
        HomeCardsBtn.onClick.AddListener(() => OverrideSortingAnim(MainMenuScreen, CardsScreen,CardsScreenAnimator,"CardsSlideRight"));
        HomeAccountsUsageBtn.onClick.AddListener(() => OverrideSortingAnim(MainMenuScreen, AccountUsageScreen, AccountsUsageAnimator, "AccountsUsageSlideRight"));


        //what should each of the buttons on the Cards screen have as a function when clicked?
        CardsHomeBtn.onClick.AddListener(() => OverrideSortingAnim(CardsScreen,MainMenuScreen,HomeScreenAnimator, "HomeSlideRight"));
        CardsAccountsUsageBtn.onClick.AddListener(() => OverrideSortingAnim(CardsScreen,AccountUsageScreen, AccountsUsageAnimator, "AccountsUsageSlideRight"));

        //what should each of the buttons on the AccountsUsage screen have as a function when clicked?
        AccountsUsageHomeBtn.onClick.AddListener(() => OverrideSortingAnim(AccountUsageScreen,MainMenuScreen,HomeScreenAnimator, "HomeSlideRight"));
        AccountsUsageCardsBtn.onClick.AddListener(() => OverrideSortingAnim(AccountUsageScreen, CardsScreen,CardsScreenAnimator, "CardsSlideRight"));



    }

    public void OverrideSorting(GameObject CurrentScreen, GameObject NextScreen)
    {
        NextScreen.GetComponent<Canvas>().sortingOrder = CurrentScreen.GetComponent<Canvas>().sortingOrder + 1;
        CurrentScreen.SetActive(false);
        NextScreen.SetActive(true);

        print("Current screen is: " + NextScreen.name);

    }


    public void OverrideSortingAnim(GameObject CurrentScreen, GameObject NextScreen, Animator ScreenAnimatorName, string AnimationName)
    {
        NextScreen.GetComponent<Canvas>().sortingOrder = CurrentScreen.GetComponent<Canvas>().sortingOrder + 1;
        CurrentScreen.SetActive(false);
        NextScreen.SetActive(true);

        ScreenAnimatorName.SetBool(AnimationName, true);

        print("Current screen is: " + NextScreen.name);
    }

    public static ScreenTransitionManagaer GetInstance()
    {
        return instance;
    }

    //Which 2 screens in the beginning need animations?
    public void InitialScreenSlideLeft()
    {
        InitialScreenAnimator.SetBool("InitialScreenSlideLeft", true);
        print("initial screen bypassed");
    }

    public void LoginScreenSlideLeft()
    {
        LoginScreenAnimator.SetBool("LoginScreenSlideLeft", true);
        LoginScreenAnimator.SetBool("LoginScreenSlideRight", false);
        print("login screen bypassed");
    }

    public void LoginScreenSlideRight()
    {
        LoginScreenAnimator.SetBool("LoginScreenSlideRight", true);
        LoginScreenAnimator.SetBool("LoginScreenSlideLeft", false);
    }

    /*GameObject[] FindGameObjectsWithLayer(int layer)
    {

        GameObject[] ForegroundGB = FindObjectsOfType(typeof(GameObject)) as GameObject[];

        List<GameObject> ForegroundList = new List<GameObject>();

        for (int i = 0; i < ForegroundGB.Length; i++)
        {

            if (ForegroundGB[i].layer == layer)
            {
                ForegroundList.Add(ForegroundGB[i]);
                //print(ForegroundGB[i].name);
            }
        }

        if (ForegroundList.Count == 0) 
        {
            return null;
        }

        return ForegroundList.ToArray();

    }*/


    /*void GBWithSpecificLayer()
    {
        GameObject[] temp = FindGameObjectsWithLayer(6);

        foreach (var item in temp)
        {
            // If within screen

        }
    }*/

}
