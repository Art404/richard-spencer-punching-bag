using UnityEngine;
using System.Collections;

public class DummyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.name);
        Debug.Log(col.gameObject.name);
    }
}
