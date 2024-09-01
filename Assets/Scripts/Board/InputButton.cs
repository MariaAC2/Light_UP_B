using UnityEngine;

public class InputButton : BoardObject {
    public Sprite sprite0; // Sprite-ul pentru valoarea 0
    public Sprite sprite1; // Sprite-ul pentru valoarea 1
    private SpriteRenderer spriteRenderer; // SpriteRenderer-ul asociat butonului

    public new bool Value {
        get => base.Value;
        set {
            base.Value = value;
            UpdateSprite(); // Schimbă sprite-ul când se schimbă valoarea
            NotifyOutputs();
            ChangeWires();
        }
    }

    private void Start() {
        // Obține referința la SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite(); // Setați sprite-ul inițial
    }

    public void Init() {
        // Seteaza starea initiala in intreg circuitul
        foreach (var output in Outputs) {
            output.onChange();
        }
    }

    private void OnMouseDown() {
        // Comută starea între TRUE și FALSE când utilizatorul face clic pe buton
        Value = !Value;
    }

    private void NotifyOutputs() {
        foreach (var output in Outputs) {
            output.onChange();
        }
    }

    private void UpdateSprite() {
        // Schimbă sprite-ul în funcție de valoare
        if (Value) {
            spriteRenderer.sprite = sprite1; // Afișează sprite-ul 1 dacă valoarea este TRUE
        } else {
            spriteRenderer.sprite = sprite0; // Afișează sprite-ul 0 dacă valoarea este FALSE
        }
    }

    private void ChangeWires() {
        foreach (var wire in Wires) {
            // Schimbă culoarea firului în funcție de valoarea butonului
            wire.startColor = Value ? Color.green : Color.blue;
            wire.endColor = Value ? Color.green : Color.blue;
        }
    }
}