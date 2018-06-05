using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Walk : MonoBehaviour {
    public float speed = 3.0f;
    public bool moveForward = false;
    public float cameraFallYPos = -15.0f;
    public int count;
    public Text countText;

	// Use this for initialization
	void Start () {
        count = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            moveForward = !moveForward;
        }

        //move the player camera in a forward direction if the trigger button is pressed
        if (moveForward) {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

        //restart the game once the player falls below cameraFallYPos
        if (transform.position.y < cameraFallYPos) {
            SceneManager.LoadScene("mainScene");
        }

}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible")) {
            count -= 1;
            Counter();
            Destroy(other.gameObject);
        }

        if (count == 0) {
            countText.text = "Collect Your Trophy!";
        }

        if (count == 0 && other.gameObject.CompareTag("Trophy"))
        {
            SceneManager.LoadScene("endScene");
        }
    }

    public void Counter() {
        countText.text = "COUNT: " + count.ToString();
    }
}
