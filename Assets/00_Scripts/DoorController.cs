using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private KeyScript keyScript;
    private Animator openDoorAnimator;

    private void Start()
    {
        openDoorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyScript.hasKey)
        {
            openDoorAnimator.SetBool("openDoor", true);
            Debug.Log("Opening door");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoorAnimator.SetBool("openDoor", false);
            Debug.Log("Closing door");
        }
    }
}
