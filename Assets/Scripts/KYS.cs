using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class KYS : MonoBehaviour {
    private GameObject player;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject spawnpoint;
    public GameObject endText;

    public bool goal;

    [SerializeField] private List<GameObject> bodies = new List<GameObject>();

    private void Start() {
        player = Instantiate(playerPrefab, spawnpoint.transform.position, transform.rotation);
        endText = GameObject.FindGameObjectWithTag("EndText");
        endText.SetActive(false);  
    }

    public void Reset() {
        bodies.Add(player);

        if (bodies.Count > 3) {
            Destroy(bodies[0]);
            bodies.RemoveAt(0);
        }

        foreach(GameObject body in bodies) {
            body.tag = "Corpse";
        }
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<PlayerCamera>().enabled = false;
        var cam = GameObject.Find("Main Camera");
        cam.gameObject.SetActive(false);
        player = Instantiate(playerPrefab, spawnpoint.transform.position, transform.rotation);
    }

    private void Update()
    {
     if(goal == true)
        {
           endText.SetActive(true);
            Time.timeScale = 0;
        }       
    }
}
