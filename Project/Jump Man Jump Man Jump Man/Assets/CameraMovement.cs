using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float min;
    public float max;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame at the end of others
	void LateUpdate () {
            float x = Mathf.Clamp(player.transform.position.x, min, max);
            gameObject.transform.position = new Vector3(x, player.transform.position.y, gameObject.transform.position.z);
    }
}
