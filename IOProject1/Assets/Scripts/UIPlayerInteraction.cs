using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class UIPlayerInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera playerCamera; //camera
    [SerializeField] public TextMeshProUGUI myText;
    [SerializeField] public float morality = 0.0f; // morality of player (e.g., Good/Evil)

    private InputAction goodAction;
    private InputAction badAction;
    private InputAction action;
    public bool wasClicked;
    private void Awake()
    {
        morality = 0.0f;

    }

    private void Start()
    {
        goodAction = InputSystem.actions.FindAction("Interact");
        action = InputSystem.actions.FindAction("NPCInteract");
        badAction = InputSystem.actions.FindAction("BadInteract");
       // MeshRenderer renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        InteractWithCharacter();


    if (wasClicked == true)
        {
            //Checks the result of the player interaction
            
            if (goodAction.WasPressedThisFrame())
            {
                morality++;
                myText.text = "You made the good choice!";
               // GetComponent<MeshRenderer>().color = Color.blue;
                wasClicked = false;
            }
            else if (badAction.WasPressedThisFrame())
            {
                morality--;
                
                myText.text = "You chose the Bad Choice.";
                wasClicked = false;
            }
        }
    }


    private void InteractWithCharacter()
    {
        //will be false if all actions do not work. 
        
        
        if (action.WasPressedThisFrame())
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
                    myText.text = "Will you choose the good or bad interaction? " +
                        "Good Interaction = Press E" +
                        "Bad Interaction = Press R";
                    wasClicked = true;
                    
                }
            }
        }
        
       
        
    }
}