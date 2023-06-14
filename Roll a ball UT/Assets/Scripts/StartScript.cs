using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void StartTheActualGame()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;

    }

}
