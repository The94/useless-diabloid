using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private Texture       _normal    = null;
    [SerializeField] private Texture       _mouseOver = null;
    [SerializeField] private Texture       _pressed   = null;
    [SerializeField] private RectTransform _textRect  = null;

    private Vector2  _offsetDefault = new Vector2(0,   0);
    private Vector2  _offsetPressed = new Vector2(0, -10);
    private RawImage _buttonImage;

    private void SetButtonTexture(Texture texture)
    {
        if (texture != null)
        {
            _buttonImage.texture = texture;
        }
    }

    private void SetTextOffset(Vector2 offsetMax)
    {
        if (_textRect != null)
        {
            _textRect.offsetMax = offsetMax;
        }
    }

    private void Start()
    {
        _buttonImage = GetComponent<RawImage>();
        if(_buttonImage == null)
        {
            Debug.LogError("Button component RawImage not found!");
        }
        SetButtonTexture(_normal);
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButton(0))
        {
            SetButtonTexture(_mouseOver);
        }
    }

    private void OnMouseExit()
    {
        if (!Input.GetMouseButton(0))
        {
            SetButtonTexture(_normal);
        }
    }

    private void OnMouseDown()
    {
        SetButtonTexture(_pressed);
        SetTextOffset(_offsetPressed);
    }

    private void OnMouseUp()
    {
        SetButtonTexture(_normal);
        SetTextOffset(_offsetDefault);
    }
}

