using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckCodeSequence : MonoBehaviour
{
    public GameObject[] cubes; // Array to hold references to the three cubes
    private int currentIndex = 0; // Index to keep track of the current cube in the order

    // Define the predefined order of cubes
    public GameObject[] predefinedOrder;

    // Cooldown period in seconds
    public float interactionCooldown = 0.5f;
    private float lastInteractionTime; // Track the time of the last interaction

    void Start()
    {
        // Ensure that all cubes have the XR Poke Interactor component attached
        foreach (GameObject cube in cubes)
        {
            cube.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor>();
        }

        // Debug.Log("Predefined Order:");
        // foreach (GameObject cube in predefinedOrder)
        // {
        //     Debug.Log(cube.name);
        // }

        // Debug.Log("Cubes array contents:");
        // foreach (GameObject cube in cubes)
        // {
        //     Debug.Log(cube.name); // Log the name of each GameObject in the array
        // }
    }

    // Wrapper method to use as an event handler for Unity events
    public void OnCubePoked(GameObject pokedCube)
    {
        CheckPokedCube(pokedCube);
    }

    // Function to check if the poked cube is in the correct order
    public void CheckPokedCube(GameObject pokedCube)
    {
        // Check if enough time has passed since the last interaction
        if (Time.time - lastInteractionTime < interactionCooldown)
        {
            Debug.Log("Interaction cooldown active. Ignoring this poke.");
            return; // Exit the function without processing the interaction
        }

        // Update the time of the last interaction
        lastInteractionTime = Time.time;

        // Log the name of the poked cube along with its index
        // Debug.Log("Poked cube: " + pokedCube.name + ", Index: " + currentIndex);

        // Get the name of the cube in the predefined order at the current index
        string expectedCubeName = predefinedOrder[currentIndex].name;
        Debug.Log("Expected cube: " + expectedCubeName + ", poked cube: " + pokedCube.name);

        // If the name of the poked cube matches the name of the expected cube in the predefined order
        if (pokedCube.name == expectedCubeName)
        {
            currentIndex++; // Move to the next cube in the order

            // If all cubes are poked in the correct order
            if (currentIndex == predefinedOrder.Length)
            {
                Debug.Log("All cubes poked in the correct order!");
                // Do something when all cubes are poked in the correct order
                // Reset currentIndex for the next sequence
                currentIndex = 0;
            }
        }
        else // If the poked cube is not in the correct order
        {
            Debug.Log("Incorrect cube poked!");
            // Reset the order tracking (or handle as per your game logic)
            currentIndex = 0;
        }
    }
}
