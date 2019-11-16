using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    void Update()
    {
        HandleKeyboardControls();
    }

    private void HandleKeyboardControls()
    {
        // TODO: Replace these controls with mobile controls.
        if (Input.GetKey(KeyCode.W))
        {
            var moveEventParams = ScriptableObject.CreateInstance<EventParams>();
            moveEventParams.movement = new Vector3(0, 0, Time.deltaTime);

            EventManager.TriggerEvent("move", moveEventParams);
        }

        if (Input.GetKey(KeyCode.A))
        {
            var moveEventParams = ScriptableObject.CreateInstance<EventParams>();
            moveEventParams.movement = new Vector3(-Time.deltaTime, 0, 0);

            EventManager.TriggerEvent("move", moveEventParams);
        }

        if (Input.GetKey(KeyCode.S))
        {
            var moveEventParams = ScriptableObject.CreateInstance<EventParams>();
            moveEventParams.movement = new Vector3(0, 0, -Time.deltaTime);

            EventManager.TriggerEvent("move", moveEventParams);
        }

        if (Input.GetKey(KeyCode.D))
        {
            var moveEventParams = ScriptableObject.CreateInstance<EventParams>();
            moveEventParams.movement = new Vector3(Time.deltaTime, 0, 0);

            EventManager.TriggerEvent("move", moveEventParams);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var turnEventParams = ScriptableObject.CreateInstance<EventParams>();
            turnEventParams.yRotation = 270;

            EventManager.TriggerEvent("turn", turnEventParams);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var turnEventParams = ScriptableObject.CreateInstance<EventParams>();
            turnEventParams.yRotation = 0;

            EventManager.TriggerEvent("turn", turnEventParams);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var turnEventParams = ScriptableObject.CreateInstance<EventParams>();
            turnEventParams.yRotation = 90;

            EventManager.TriggerEvent("turn", turnEventParams);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var turnEventParams = ScriptableObject.CreateInstance<EventParams>();
            turnEventParams.yRotation = 180;

            EventManager.TriggerEvent("turn", turnEventParams);
        }
    }
}
