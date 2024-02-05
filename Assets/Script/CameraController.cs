using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform follow;

    public Vector3 offset;

    // Camera는 무조건 LateUpdate()에서.
    // Update()에서 하면 프레임드랍이 있을 시 흔들리는 경우가 있음
    private void LateUpdate()
    {
        transform.position = follow.position + offset;
        transform.LookAt(follow.position);
    }
}
