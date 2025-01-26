using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;

    private void Start()
    { }
            public void OnPointerDown(PointerEventData eventData)
        {
            _img.sprite = _pressed;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _img.sprite = default;
        }

public void QuitButtonIsClick()
    {
        SceneManager.LoadScene("Quit");
    }

}
    
