using UnityEngine;

public class CameraSwitch2 : MonoBehaviour
{
    public Camera mainCamera; // Camera principală (3D, care urmărește jucătorul)
    public Camera camera2D; // Noua cameră 2D poziționată în fața tablei
    public DialogueManager manager;

    private bool is2D = false; // Flag pentru a urmări dacă suntem în modul 2D sau 3D

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShowDialogue");
            manager.PlayDialogue("Ec001_in");

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifică dacă tasta P a fost apăsată
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Tasta P a fost apăsată in ec001!");

                // Comută între 2D și 3D
                if (is2D)
                {
                    SwitchTo3DView();
                }
                else
                {
                    SwitchTo2DView();
                }

                is2D = !is2D; // Schimbă starea între 2D și 3D
            }
        }
    }
    //functii schimbare:
    void SwitchTo2DView()
    {
        Debug.Log("Switching to 2D View");

        // Dezactivează camera principală și activează camera 2D
        mainCamera.enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;

        camera2D.enabled = true;
        camera2D.GetComponent<AudioListener>().enabled = true;

        Debug.Log("Camera 2D ec001 is active: " + camera2D.enabled);
    }

    void SwitchTo3DView()
    {
        Debug.Log("Switching to 3D View");

        camera2D.enabled = false;
        camera2D.GetComponent<AudioListener>().enabled = false;

        mainCamera.enabled = true;
        mainCamera.GetComponent<AudioListener>().enabled = true;

        Debug.Log("Main Camera is active: " + mainCamera.enabled);
    }


}
