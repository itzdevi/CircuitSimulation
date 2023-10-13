using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour {
    protected List<IOValue> inputs;
    protected List<IOValue> outputs;

    [SerializeField] protected Transform inputsPosition;
    [SerializeField] protected Transform outputsPosition;
    
    public static void CreateChip(Vector2 pos, ChipSave chipSave) {

    }

    public float GetInputsX() {
        return inputsPosition.position.x;
    }

    public float GetOutputsX() {
        return outputsPosition.position.x;
    }
}
