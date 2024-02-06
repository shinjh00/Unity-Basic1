using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
    /*** Device ***/

    // Ư���� ��ġ�� �������� �Է� ����
    // Ư���� ��ġ�� �Է��� �����ϱ� ������ ���� �÷����� ������ �����
    // ==> ���� ������� ��������
    private void InputByDevice()
    {
        /* Ű���� */

        // GetKeyDown : ������ ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key is down");
        }
        // GetKey : ������ �ִ� �߿�
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key is pressing");
        }
        // GetKeyUp : ���� ��
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key is up");
        }

        /* ���콺 */

        // GetMouseButtonDown : ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse left button is down");
        }
        // GetMouseButton : ������ �ִ� �߿�
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse left button is pressing");
        }
        // GetMouseButtonUp : ���� ��
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse left button is up");
        }
    }


    /*** InputManager ***/

    // ���� ��ġ�� �Է��� �Է¸Ŵ����� �̸��� �Է��� ����
    // �Է¸Ŵ����� �̸����� ������ �Է��� ��������� Ȯ��
    // ����Ƽ �������� Edit -> Project Settings -> Input Manager ���� ����
    // Name ���Ƿ� �����ؼ� ��� ����
    // ���� ������ Update�ϸ鼭 Ȯ����

    // ��, ����Ƽ ��â���� ����̱� ������ Ű����, ���콺, ���̽�ƽ�� ���� ��ġ���� ����� (�����, VR ����)
    // �߰�) VR Oculus Integraion Kit ���� ��� �Է¸Ŵ����� ������ ����� ���
    private void InputByInputManager()
    {
        /* �� �Է� */
        // WASD, ȭ��ǥ
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(3 * x * Time.deltaTime, 3 * y * Time.deltaTime, 0);

        /* ��ư �Է� */
        // Fire1 ��ư : Ű����(��Ctrl), ���콺(��Ŭ��)
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1 button is down");
        }
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire1 button is pressing");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Fire1 button is up");
        }
    }


    /*** InputSystem ***/

    // Unity 2019.1 ���� �����ϰ� �� �Է¹��
    // ������Ʈ�� ���� �Է��� ��������� Ȯ��
    // GamePad, JoyStick, Mouse, Keyboard, Pointer, Pen, TouchScreen, XR ��� ���� ����
    private void InputByInputSystem()
    {
        // InputSystem�� �̺�Ʈ ������� ������
        // Update���� �Էº�������� Ȯ���ϴ� ��� ��� ������ ���� ��� �̺�Ʈ�� Ȯ��
        // �޽����� ���� �޴� ��İ� �̺�Ʈ �Լ��� ���� �����ϴ� ��� ������ ����
    }

    Vector3 moveDir;

    // �޽��� �̺�Ʈ ���. InputManager���� �ڿ� �Ҹ� ����.
    // Move �Է¿� �����ϴ� OnMove �޽��� �Լ�
    // PlayerInput �ؿ� �޼��� ����� �����ִ� ���� ����.
    // InputAction�� Actions �׸� ������ ���Ե� �Լ��� ȣ�� ����
    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.y = inputDir.y;
        //Debug.Log(inputDir);
    }

    private void Move()
    {
        transform.position += moveDir * 3f * Time.deltaTime;
    }

    public Rigidbody rigidBody;

    private void OnJump(InputValue value)
    {
        bool inputButton = value.isPressed;
        //Debug.Log(inputButton); 
        Jump();
    }

    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }


    private void Update()
    {
        //InputByDevice();

        //InputByInputManager();

        /* InputSystem */
        Move();
    }
}
