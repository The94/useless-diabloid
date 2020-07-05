using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private Texture _normal;
    [SerializeField] private Texture _mouseOver;
    [SerializeField] private Texture _pressed;
    [SerializeField] private RectTransform _textRect;

    private RawImage _buttonImage;

    private void SetButtonTexture(Texture texture)
    {
        _buttonImage.texture = texture;
    }

    private void SetTextOffset(Vector2 offsetMax)
    {
        if (_textRect != null)
        {
            _textRect.offsetMax = offsetMax;
        }
    }

    private void Start() {
        _buttonImage = GetComponent<RawImage>();
        SetButtonTexture(_normal);
    }

    private void OnMouseOver() {
        if (!Input.GetMouseButton(0)) {
            SetButtonTexture(_mouseOver);
        }
    }

    private void OnMouseExit() {
        if (!Input.GetMouseButton(0)) {
            SetButtonTexture(_normal);
        }
    }

    private void OnMouseDown() {
        SetButtonTexture(_pressed);
        SetTextOffset(new Vector2(0, -10));
    }

    private void OnMouseUp() {
        SetButtonTexture(_normal);
        SetTextOffset(new Vector2(0, 0));
    }
}

