using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecondTest : MonoBehaviour
{
    //SingleScripts > Singleton ScriptableObjects
    public static TestService Test { get { return SingleScript<TestService>.Instance; } }

    // make sure to include the string here.
    private UnityAction<string> EventListener;

    private void Awake()
    {
        //EventListener = new UnityAction<string>(SomeListener);
        EventListener = new UnityAction<string>(SomeListener);
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("test", EventListener);
        EventManager.StartListening("PlayButtonPressed", StartPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Test.SetValue(9099);
        }
        if (Input.GetKey(KeyCode.O))
        {
            Test.PrintValue();
        }
        if (Input.GetKey(KeyCode.J))
        {
            GameManager.testString = "loser";
            Debug.Log(GameManager.testString);
        }
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log(GameManager.testString);
        }
    }

    void SomeListener(string jsonParams)
    {
        var eventParams = ScriptableObject.CreateInstance<EventParams>();
        JsonUtility.FromJsonOverwrite(jsonParams, eventParams);
        Debug.Log("listened: " + eventParams.numberInfo);
        Debug.Log(eventParams.ints[0]);
        Debug.Log(eventParams.ints[1]);
    }

    void StartPlaying()
    {
        Debug.Log("startPLaying");
    }
}
