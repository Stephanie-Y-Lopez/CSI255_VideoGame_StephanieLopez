using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called before the first frame update

/// <summary>
/// Awake is called when the script instance is being loaded.
/// </summary>
    private void Awake()
    {
        Debug.Log($"{this.name} was Awake");
    }

    void Start()
    {
        Debug.Log($"{this.name} was Start");  
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{this.name} was Update");       
    }

    ~DebugScript() {
        Debug.Log($"{this.name} was Destroyed");
    }
}
