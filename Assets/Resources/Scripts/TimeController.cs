using UnityEngine;
using System.Collections;

/////////////////////////////////////////////////////////////////////
// Class TimeController
// 
// Usage:
//     Attach to a persistent GameObject in a scene
/////////////////////////////////////////////////////////////////////
public class TimeController : MonoBehaviour {
 
    public static float deltaTime;
    private static float _lastframetime;
	void Start () {
        _lastframetime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.realtimeSinceStartup - _lastframetime;
        _lastframetime = Time.realtimeSinceStartup;
	}
}