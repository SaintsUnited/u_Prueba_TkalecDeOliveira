public interface Interactables
{
    //script... en realidad interfaz creada para almacenar los datos de objetos interactuables
    //el script de PlayerInteractions utiliza estos datos para mostrarlos en pantalla como feedback
    //y para interactuar con objetos
    void Interact();
    string GetInteractionText();
}