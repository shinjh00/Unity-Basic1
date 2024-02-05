using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerTransform : MonoBehaviour
{
    [SerializeField] Transform transform;
    [SerializeField] Rigidbody rigidBody;
    public float moveSpeed;
    //public float jumpSpeed;
    [SerializeField] float jumpCoolTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.z += moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSpeed;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            pos.y += jumpSpeed;
        }*/

        transform.position = pos;

        /* Jump */
        jumpCoolTime += Time.deltaTime;

        if (jumpCoolTime >= 2f && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            jumpCoolTime = 0f;
        }
    }
}
