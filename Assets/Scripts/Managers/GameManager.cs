using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject mainMenuUI;

    public static TestService Test { get { return SingleScript<TestService>.Instance; } }

    public static string testString = "Peepz";

    private void Awake()
    {
        if (mainMenuUI == null) mainMenuUI = GameObject.Find("MainMenuUI");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Test.SetValue(1111);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Test.PrintValue();
        }
        if (Input.GetKey(KeyCode.L))
        {
            //string jsonParams = EventManager.eventHelper.CreateEventString();
            var eventParams = ScriptableObject.CreateInstance<EventParams>();
            eventParams.numberInfo = 888;
            eventParams.ints[0] = 1;
            eventParams.ints[1] = 2321;

            EventManager.TriggerEvent("test", eventParams);
        }
    }

    public void OnPlayButtonPressed()
    {
        mainMenuUI.SetActive(false);
        EventManager.TriggerEvent("PlayButtonPressed"); //scripts can listen to this event to start certain actions
    }
}
