using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KYS : MonoBehaviour {
    private GameObject player;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject spawnpoint;


    private GameObject body1 = null;
    private GameObject body2 = null;
    private GameObject body3 = null;


    private void Start() {
        player = Instantiate(playerPrefab, spawnpoint.transform.position, transform.rotation);
    }



    private void Reset() {



        body1 = player.gameObject;
        if (body1 != null && body2 != null) {
            body3 = player.gameObject;
        }
        if (body1 != null) {
            body2 = player.gameObject;
        }
        Destroy(player);
        Instantiate(playerPrefab);
    }
}
