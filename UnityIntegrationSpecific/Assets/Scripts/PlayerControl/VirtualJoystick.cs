//using UnityEngine;
//using UnityEngine.EventSystems;

//public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
//{
//    private Image bgImg;
//    private Image joystickImg;
//    private Vector2 inputVector;
//    private CharacterMovement characterMovement;

//    void Start()
//    {
//        bgImg = GetComponent<Image>();
//        joystickImg = transform.GetChild(0).GetComponent<Image>();
//        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
//    }

//    public virtual void OnDrag(PointerEventData ped)
//    {
//        Vector2 pos;
//        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
//        {
//            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
//            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

//            inputVector = new Vector2(pos.x * 2, pos.y * 2);
//            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

//            joystickImg.rectTransform.anchoredPosition = new Vector2(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 2), inputVector.y * (bgImg.rectTransform.sizeDelta.y / 2));

//            characterMovement.SetMovement(inputVector);
//        }
//    }

//    public virtual void OnPointerDown(PointerEventData ped)
//    {
//        OnDrag(ped);
//    }

//    public virtual void OnPointerUp(PointerEventData ped)
//    {
//        inputVector = Vector2.zero;
//        joystickImg.rectTransform.anchoredPosition = Vector2.zero;
//        characterMovement.SetMovement(Vector2.zero);
//    }
//}
