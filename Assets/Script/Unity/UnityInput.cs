using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
    /*** Device ***/

    // 특정한 장치를 기준으로 입력 감지
    // 특정한 장치의 입력을 감지하기 때문에 여러 플랫폼에 대응이 어려움
    // ==> 자주 사용하지 않을것임
    private void InputByDevice()
    {
        /* 키보드 */

        // GetKeyDown : 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key is down");
        }
        // GetKey : 누르고 있는 중에
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key is pressing");
        }
        // GetKeyUp : 뗐을 때
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key is up");
        }

        /* 마우스 */

        // GetMouseButtonDown : 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse left button is down");
        }
        // GetMouseButton : 누르고 있는 중에
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse left button is pressing");
        }
        // GetMouseButtonUp : 뗐을 때
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse left button is up");
        }
    }


    /*** InputManager ***/

    // 여러 장치의 입력을 입력매니저에 이름과 입력을 정의
    // 입력매니저의 이름으로 정의한 입력의 변경사항을 확인
    // 유니티 에디터의 Edit -> Project Settings -> Input Manager 에서 관리
    // Name 임의로 변경해서 사용 가능
    // 누를 때마다 Update하면서 확인함

    // 단, 유니티 초창기의 방식이기 때문에 키보드, 마우스, 조이스틱에 대한 장치만을 고려함 (모바일, VR 없음)
    // 추가) VR Oculus Integraion Kit 같은 경우 입력매니저와 유사한 방식을 사용
    private void InputByInputManager()
    {
        /* 축 입력 */
        // WASD, 화살표
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(3 * x * Time.deltaTime, 3 * y * Time.deltaTime, 0);

        /* 버튼 입력 */
        // Fire1 버튼 : 키보드(좌Ctrl), 마우스(좌클릭)
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

    // Unity 2019.1 부터 지원하게 된 입력방식
    // 컴포넌트를 통해 입력의 변경사항을 확인
    // GamePad, JoyStick, Mouse, Keyboard, Pointer, Pen, TouchScreen, XR 기기 등을 지원
    private void InputByInputSystem()
    {
        // InputSystem은 이벤트 방식으로 구현됨
        // Update마다 입력변경사항을 확인하는 방식 대신 변경이 있을 경우 이벤트로 확인
        // 메시지를 통해 받는 방식과 이벤트 함수를 직접 연결하는 방식 등으로 구성
    }

    Vector3 moveDir;

    // 메시지 이벤트 방식. InputManager보다 자원 소모가 적음.
    // Move 입력에 반응하는 OnMove 메시지 함수
    // PlayerInput 밑에 메세지 뭐라고 나와있는 곳에 있음.
    // InputAction에 Actions 항목 있으면 포함된 함수들 호출 가능
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
