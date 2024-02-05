using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform follow;

    public Vector3 offset;

    // Camera�� ������ LateUpdate()����.
    // Update()���� �ϸ� �����ӵ���� ���� �� ��鸮�� ��찡 ����
    private void LateUpdate()
    {
        transform.position = follow.position + offset;
        transform.LookAt(follow.position);
    }
}
