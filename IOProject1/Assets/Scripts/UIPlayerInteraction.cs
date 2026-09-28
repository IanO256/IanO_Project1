using UnityEngine;
using UnityEngine.Rendering;

public class UIPlayerInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera playerCamera; //camera
                                                 
    [SerializeField] public float morality = 0.0f; // morality of player (e.g., Good/Evil)
    private void Awake()
    {
        morality = 0.0f;

    }
    void Update()
    {
        
       
    if (InteractWithCharacter() == true)
        {
            //Checks the result of the player interaction
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                morality++;
                Debug.Log("You chose the Good Choice.");

            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                morality--;
                Debug.Log("You chose the Bad Choice.");

            }
        }
    }


    private bool InteractWithCharacter()
    {
        //will be false if all actions do not work. 
        bool result = false;
        
        if (Input.GetMouseButton(0))
        {
            
            // Create a ray from the center of the camera viewport
            Ray originRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            
            
            if (Physics.Raycast(originRay, out hit))
            {
                

                // Try to find the IInteractable component on the hit object
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    // UI prompt (e.g., "Press E to Interact for Good interaction, R for Bad")
                    Debug.Log("Will you choose the good or bad interaction?");
                    Debug.Log("Good Interaction = Press E");
                    Debug.Log("Bad Interaction = Press R");
                    result = true;
                }
            }
        }
        return result;
        
    }
}