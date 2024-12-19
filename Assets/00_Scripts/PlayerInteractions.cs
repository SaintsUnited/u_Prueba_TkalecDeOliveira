using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f; // Distancia máxima para interactuar
    [SerializeField] private TextMeshProUGUI interactText; // Referencia al texto de interacción
    [SerializeField] private LayerMask interactableLayer; // Capa de los objetos interactuables

    private Camera playerCamera;
    private Interactables currentInteractable;
    void Start()
    {
        playerCamera = Camera.main;
        interactText.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckForInteractable();
        HandleInteraction();
    }
    private void CheckForInteractable()
    {
        // Lanza un raycast desde la cámara hacia adelante
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
        {
            Interactables interactable = hit.collider.GetComponent<Interactables>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                interactText.text = interactable.GetInteractionText();
                interactText.gameObject.SetActive(true);
                return;
            }
        }
        currentInteractable = null; 
        interactText.gameObject.SetActive(false);
    }
    private void HandleInteraction()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }
}