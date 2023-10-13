using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {
    private IOValue start;
    private IOValue end;
    private bool followCursor;

    public void SetFollowCursor(bool follow) {
        followCursor = follow;
    }

    private void Update() {
        if (!followCursor) return;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
