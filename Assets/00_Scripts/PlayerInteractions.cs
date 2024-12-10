using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f; // Distancia máxima para interactuar
    [SerializeField] private TextMeshProUGUI interactText; // Referencia al texto de interacción
    [SerializeField] private LayerMask interactableLayer; // Capa de los objetos interactuables

    private Camera playerCamera;
    private DoorOpener currentInteractable;
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

        if (Physics.Raycast(ray, out var hit, interactionDistance, interactableLayer))
        {
            DoorOpener doorOpener = hit.transform.GetComponent<DoorOpener>();
            if (doorOpener)
            {
                //Activa un display de texto
                currentInteractable = doorOpener;
                interactText.gameObject.SetActive(true);
                return;
            }
        }
        currentInteractable = null; 
        interactText.gameObject.SetActive(false);
    }
    private void HandleInteraction()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E) && !currentInteractable.isAnimating)
        {
            currentInteractable.ToggleDoor();
        }
    }
}