using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera; // Camera principală
    public DialogueManager manager;

    private bool is2D = false; // Flag pentru a urmări dacă suntem în modul 2D sau 3D
    private Vector3 originalPosition; // Salvează poziția inițială a camerei 3D
    private Quaternion originalRotation; // Salvează rotația inițială a camerei 3D

    // Poziția și rotația corectă pentru camera în modul 2D (în fața tablei)
    public Vector3 position2D = new Vector3(15, -1, 1); // Ajustează această poziție în funcție de tabla ta
    public Quaternion rotation2D = Quaternion.Euler(0, 0, 0); // Rotație 2D, orientată drept înainte

    void Update()
    {
        // Verifică dacă tasta P a fost apăsată
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Tasta P a fost apăsată!");

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ShowDialogue");
            manager.PlayDialogue("Ec105_in2");
        }
    }

    void SwitchTo2DView()
    {
        // Salvează poziția și rotația curentă pentru a reveni la ele în modul 3D
        originalPosition = mainCamera.transform.position;
        originalRotation = mainCamera.transform.rotation;

        // Schimbă proiecția camerei la ortografică pentru 2D
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 5; // Ajustează în funcție de cât de departe vrei să fie camera

        // Setează camera în fața tablei
        mainCamera.transform.position = position2D;
        mainCamera.transform.rotation = rotation2D;
    }

    void SwitchTo3DView()
    {
        // Schimbă proiecția camerei înapoi la perspectiva 3D
        mainCamera.orthographic = false;

        // Reajustează poziția și rotația camerei la valorile salvate
        mainCamera.transform.position = originalPosition;
        mainCamera.transform.rotation = originalRotation;

    }

  
}
