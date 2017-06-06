using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private int count;
	public Text countText;
	public Text winText;

	public float speed;

	private Rigidbody playerRigidBody;

	// Use this for initialization
	void Start () {
		count = 0;
		playerRigidBody = GetComponent<Rigidbody> ();
		UpdateCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		playerRigidBody.AddForce (movement * speed);
	}

	void UpdateCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 8) {
			winText.text = "You are winner!";
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			++count;
			UpdateCountText ();
		}
	}
}
