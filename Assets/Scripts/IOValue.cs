using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum IOState {
    Input,
    Output
}

public class IOValue : MonoBehaviour {
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;

    private Chip holder;
    private IOState state;
    private bool isActive;
    private IOValue input;
    private List<IOValue> outputs;

    public event EventHandler<ValueChangedEventArgs> OnValueChanged;
    public class ValueChangedEventArgs : EventArgs {
        public bool isActive;

        public ValueChangedEventArgs(bool isActive) {
            this.isActive = isActive;
        }
    }

    private void Awake() {
        GetComponent<SpriteRenderer>().material = isActive ? onMaterial : offMaterial;
    }

    public void SetHolder(Chip holder) {
        this.holder = holder;
    }

    private void OnInputValueChanged(object sender, ValueChangedEventArgs value) {
        SetIsActive(value.isActive);
        OnValueChanged?.Invoke(this, new ValueChangedEventArgs(isActive));
    }

    public void SetRelativeHeight(float relativeHeight) {
        switch (state) {
            case IOState.Input:
                transform.position = new Vector2(holder.GetInputsX(), relativeHeight);
                break;
            case IOState.Output:
                transform.position = new Vector2(holder.GetOutputsX(), relativeHeight);
                break;
        }
    }

    public void SetInput(IOValue input) {
        this.input = input;
        input.OnValueChanged += OnInputValueChanged;
    }

    public bool GetIsActive() {
        return isActive;
    }

    public void SetIsActive(bool isActive) {
        this.isActive = isActive;
        GetComponent<SpriteRenderer>().material = isActive ? offMaterial : onMaterial;
    }

    public void SetState(IOState state) {
        this.state = state;
        switch (state) {
            case IOState.Input:
                transform.position = new Vector2(holder.GetInputsX(), transform.position.y);
                break;
            case IOState.Output:
                transform.position = new Vector2(holder.GetOutputsX(), transform.position.y);
                break;
        }
    }
}
