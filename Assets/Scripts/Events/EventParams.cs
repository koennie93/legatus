using UnityEngine;

// just a scriptable object class to test passing json serialized parameters as strings with an event manager
public class EventParams : ScriptableObject
{
    // Add variables as needed
    public int numberInfo;
    public string stringInfo;
    public bool BoolInfo;
    public int[] ints = new int[2];

    // Movement
    public Vector3 movement;
    public float yRotation;
}