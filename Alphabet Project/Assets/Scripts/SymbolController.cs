using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolController : MonoBehaviour {

    private Vector3 originalPos;
    private bool isGrabbed;
    private float mouseLift;
    private SpriteRenderer sprite;

    public Text letterText;

    private void Start()
    {
        originalPos = transform.position;
        isGrabbed = false;
        mouseLift = 0.5f;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && isGrabbed)
        {
            transform.position = originalPos;
            sprite.sortingLayerName = "Alphabet";
            isGrabbed = false;
        }
    }

    private void OnMouseDrag()
    {
        isGrabbed = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = mouseLift;
        transform.position = mousePos;
        sprite.sortingLayerName = "Lifted";
    }
}
