using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static TestService Test { get { return SingleScript<TestService>.Instance; } }

    public static string testString = "Peepz";

    private void Awake()
    {

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
            var eventParams = ScriptableObject.CreateInstance<EventParams>();
            eventParams.numberInfo = 888;
            eventParams.ints[0] = 1;
            eventParams.ints[1] = 2321;

            string jsonParams = JsonUtility.ToJson(eventParams);
            EventManager.TriggerEvent("test", jsonParams);
        }
    }
}
