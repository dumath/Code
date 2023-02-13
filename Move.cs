using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    #region Fields.
    private float speed = 5f; // �������� �����������.
    private float gravity = -9.8f; // ���� ����������.
    private CharacterController character; // ������ �� ���������.
    #endregion

    #region Awake, Start, Update, LateUpdate.
    // Start is called before the first frame update
    void Start() => this.character = GetComponent<CharacterController>();

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(x, gravity, z);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = this.transform.TransformDirection(movement);
        character.Move(movement);
#else
        float z = Vector3.forward.z * MoveStick.Sensativity * speed;
        Vector3 movement = new Vector3(0.0f, gravity, z);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = this.transform.TransformDirection(movement);
        character.Move(movement);
#endif
    }
    #endregion
}
