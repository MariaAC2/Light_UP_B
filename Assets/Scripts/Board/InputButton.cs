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
        }
    }

    private void Start() {
        // Obține referința la SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite(); // Setați sprite-ul inițial
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
}