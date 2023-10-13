using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour {
    public static Prefabs Instance { get; private set; }

    public IOValue IOValuePrefab;

    private void Awake() {
        if (!Instance)
            Instance = this;
        else
            Destroy(this);
    }
}
