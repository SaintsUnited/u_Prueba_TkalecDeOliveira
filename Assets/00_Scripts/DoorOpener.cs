using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour, Interactables
{
    private PlayerInteractions playerInteractions;
    public bool isAnimating;
    private bool isOpen;
    [SerializeField] private GameObject doorPivot;
    [SerializeField] private float rotation = -90;
    [SerializeField] private float rotationSpeed = 2f;
   
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private void Start()
    {
        //la variable gameObject doorPivot se auto asigna via codigo
        doorPivot = this.transform.parent.gameObject;
        //auto asigna la Layer de las puertas como un "Interactable"
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        closedRotation = doorPivot.transform.rotation;
        openRotation = Quaternion.Euler(0, rotation, 0) * closedRotation;
    }
    public void Interact()
    {
        if (!isAnimating)
        {
            ToggleDoor();
        }
    }
    public string GetInteractionText()
    {
        return isOpen ? "Press [E] to close the door" : "Press [E] to open the door";
    }
    public void ToggleDoor()
    {
        //codigo que intercabia el valor de la booleana "isOpen", inicia la corrutina "DoorOpeningAnimation()"
        isOpen = !isOpen;
        StartCoroutine(DoorOpeningAnimation());
    }
    private IEnumerator DoorOpeningAnimation()
    {
        isAnimating = true;
        Quaternion startRotation = doorPivot.transform.rotation; //Punto de animacion inicial
        Quaternion targetRotation = isOpen ? openRotation : closedRotation; //Punto al que la animacion debe llegar
        float elapsedTime = 0f; //variable que monitorea el progreso de la animacion, donde 0 es el inicio de la animacion y 1 es el final de la animacion
        
        while (elapsedTime < 1f)
        {
            elapsedTime += rotationSpeed * Time.deltaTime;
            doorPivot.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }
        doorPivot.transform.rotation = targetRotation; //Asegura que al final de la animacion la posicion de la puerta sea igual a la targetRotation
        isAnimating = false;
    }
}