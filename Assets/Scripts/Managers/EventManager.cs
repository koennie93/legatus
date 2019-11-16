using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Replacement of the basic Unityevent with a unity event that has a string that will be used to serialize JSON
[System.Serializable]
public class ThisEvent : UnityEvent<EventParams> { }

public class EventManager : Singleton<EventManager>
{
    public static EventHelper eventHelper { get { return SingleScript<EventHelper>.Instance; } }

    private Dictionary<string, UnityEvent> eventDictionary;

    private Dictionary<string, ThisEvent> eventParamDictionary;

    private void Awake()
    {
        if (eventParamDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
            eventParamDictionary = new Dictionary<string, ThisEvent>();
        }
    }

    // function called to insert an event in the dictionary
    public static void StartListening(string eventName, UnityAction<EventParams> listener)
    {
        ThisEvent thisEvent = null;
        if (Instance.eventParamDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new ThisEvent();
            thisEvent.AddListener(listener);
            Instance.eventParamDictionary.Add(eventName, thisEvent);
        }
    }

    // removes an event from the dictionary
    public static void StopListening(string eventName, UnityAction<EventParams> listener)
    {
        if (Instance == null) return;
        ThisEvent thisEvent = null;
        if (Instance.eventParamDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    // event trigger with a string passed as a parameter.
    public static void TriggerEvent(string eventName, EventParams eventParams)
    {
        ThisEvent thisEvent = null;
        if (Instance.eventParamDictionary.TryGetValue(eventName, out thisEvent))
        {
            // finally passes the message.
            thisEvent.Invoke(eventParams);
        }
    }
    

    //Paramless events
    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (Instance == null) return;
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
