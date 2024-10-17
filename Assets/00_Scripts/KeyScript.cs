using System;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject key;
    public bool hasKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("Key acquired");
        }
    }
}
