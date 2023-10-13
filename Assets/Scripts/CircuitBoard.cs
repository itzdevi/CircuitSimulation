using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircuitBoard : Chip {
    public static CircuitBoard Instance { get; private set; }

    private List<Chip> chips;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        inputs = new List<IOValue>();
        outputs = new List<IOValue>();
        chips = new List<Chip>();

        AddInput(3);
        AddOutput(4);
    }

    public void AddInput(float mouseY) {
        IOValue val = Instantiate(Prefabs.Instance.IOValuePrefab);
        val.SetHolder(this);
        val.SetState(IOState.Input);
        val.SetRelativeHeight(mouseY);
        inputs.Add(val);
    }

    public void RemoveInput(IOValue val) {
        inputs.Remove(val);
        Destroy(val.gameObject);
    }

    public void AddOutput(float mouseY) {
        IOValue val = Instantiate(Prefabs.Instance.IOValuePrefab);
        val.SetHolder(this);
        val.SetState(IOState.Output);
        val.SetRelativeHeight(mouseY);
        outputs.Add(val);
    }

    public void RemoveOutput(IOValue val) {
        outputs.Remove(val);
        Destroy(val.gameObject);
    }

    private void Update() {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (!hit) return;

        if (hit.transform.TryGetComponent(out IOValue value))
            if ((inputs.Contains(value) || outputs.Contains(value)) && Input.GetMouseButtonDown(0))
                value.SetIsActive(!value.GetIsActive());
    }
}
