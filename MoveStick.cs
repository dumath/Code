using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveStick : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    #region Fileds.
    private Vector2 startPos; // Начальная точка положения стика. Возврат стика.
    private Color currentColor; // Цвет по умолчанию. 
    private float minDragPos; // Минимальная точка, на которую может сдвинуться стик.
    private float maxDragPos; // Максимальная точка, на которую может сдвинуться стик.
    private float minK = -1.0f; // Аналог Input.GetAxis, без падения скорости.
    private float maxK = 1.0f; // Аналог Input.GetAxis, без падения скорости.
    [SerializeField] RectTransform downLayer; // Площадка стика.
    #endregion

    #region Static output.
    private static float _sensativity; // Показатель передвижения мыши/удержания(Touch). 0 - скорость отсутствует.
    public static float Sensativity { get => _sensativity; }
    #endregion

    #region Awake, Start, Update, LateUpdate.
    // Start is called before the first frame update
    void Start()
    {
        minDragPos = downLayer.rect.size.y / 4.0f + downLayer.rect.yMin;
        maxDragPos = downLayer.rect.size.y / 4.0f + downLayer.rect.yMax;
    }

    // Update is called once per frame
    void Update() { }
    #endregion

    #region Handlers of pointer.
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        currentColor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.cyan;
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(eventData.position.y, minDragPos, maxDragPos);
        _sensativity = AdditionalMath.Lerp(minDragPos, maxDragPos, minK, maxK, pos.y);
        transform.position = pos;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
        GetComponent<Image>().color = currentColor;
        _sensativity = 0.0f;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        
    }
    #endregion
}