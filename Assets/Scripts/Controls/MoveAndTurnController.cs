using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveAndTurnController : MonoBehaviour
{
    private UnityAction<EventParams> MoveEventListener;
    private UnityAction<EventParams> TurnEventListener;

    private void Awake()
    {
        //EventListener = new UnityAction<string>(SomeListener);
        MoveEventListener = new UnityAction<EventParams>(Move);
        TurnEventListener = new UnityAction<EventParams>(Turn);
    }

    void Start()
    {
        EventManager.StartListening("move", MoveEventListener);
        EventManager.StartListening("turn", TurnEventListener);
    }

    private void Move(EventParams eventParams)
    {
        transform.Translate(eventParams.movement, Space.World);
    }

    private void Turn(EventParams eventParams)
    {
        transform.rotation = Quaternion.Euler(0, eventParams.yRotation, 0);
    }

}
