using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
    /************************************************************************
	 * Ʈ������ (Transform)
	 * 
	 * ���ӿ�����Ʈ�� ��ġ, ȸ��, ũ�⸦ �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �θ�-�ڽ� ���¸� �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �ݵ�� �ϳ��� Ʈ������ ������Ʈ�� ������ ������ �߰� & ������ �� ����
	 ************************************************************************/

    /* Ʈ������ ���� */

    public Transform thisTransform;

    private void TransformReference()
    {
        thisTransform = transform;  // �ڱ� �ڽſ� ���� Ʈ�������� �̵����� �ְ� �ʹ� �� ��
    }


    /* Ʈ������ �̵� */

    float moveSpeed = 3;
    float rotateSpeed = 90;

    // Translate : Ʈ�������� �̵� �Լ�
    private void Translate()
    {
        // position�� �̿��� �̵�
        transform.position += new Vector3(1, 0, 0);     // Global ����

        // Translate�� �̿��� �̵�
        transform.Translate(1, 0, 0, Space.Self);       // Local ���� (Default)
        transform.Translate(1, 0, 0, Space.World);      // Global ����
        transform.Translate(1, 0, 0, Camera.main.transform);  // �ٸ� ����� �������� �̵�

        // ���͸� �̿��� �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // x,y,z�� �̿��� �̵�
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }


    /* Ʈ������ ȸ�� */

    // Rotate : Ʈ�������� ȸ�� �Լ�
    private void Rotate()
    {
        // Global ����
        transform.Rotate(Vector3.up, 30, Space.World);
        // Local ����
        transform.Rotate(Vector3.up, 30, Space.Self);
        // Ư�� ��ġ�� �������� ȸ��
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30);
        // Ư�� ��ġ�� �ٶ󺸸� ȸ��
        transform.LookAt(new Vector3(0, 0, 0));

        // ���� �̿��� ȸ�� (���� �������� �ð�������� ȸ��)
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        // ���Ϸ��� �̿��� ȸ��
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        // x,y,z�� �̿��� ȸ��
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }


    /* Ʈ������ �� */

    public Transform sphere;
    public Transform cube;

    private void Axis()
    {
        sphere.position = transform.position + 3 * Vector3.forward;  // Global ���� 3��ŭ �տ�
        cube.position = transform.position + 3 * transform.forward;  // 

        // Ʈ�������� x��
        Vector3 right = transform.right;
        // Ʈ�������� y��
        Vector3 up = transform.up;
        // Ʈ�������� z��
        Vector3 forward = transform.forward;  // ��ź ������ ���� �� ��ü ���� �������� ��������

        // �չ����� ���������� ����(����) ������ �� ����
        transform.forward = Vector3.right;
    }


    /* Ʈ������ �θ�-�ڽ� ���� */

    // Ʈ�������� �θ� Ʈ�������� ���� �� ����
    // �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
    // �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �̵��ϸ�, �հ����� ���� �̵���)
    // ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
    // �ڽ��� ��ġ�� ���� ������ �ƴ϶� �θ� �������� �� ( �θ�: (1, 1) / �ڽ�: (2, 2) �� �� �ڽ��� ���� �������δ� (3, 3)�� )
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // �θ� ����
        transform.parent = newGameObject.transform;

        // �θ� ���������� Ʈ������
        // transform.localPosition	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale		: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null;  // �ٽ� ���带 �������� �ϰ� ��

        // (�θ� ���� �� �ٽ�) ���带 ���������� Ʈ������
        // transform.localPosition == transform.position	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ��ġ
        // transform.localRotation == transform.rotation	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ȸ��
        // transform.localScale								: �θ�Ʈ�������� ���� ��� ���带 �������� �� ũ��
    }


    /* Quarternion & Euler */

    // ���Ϸ� �� (EulerAngle) : 1. (X, Y, Z) �� ���� ���� �������� ȸ���ϱ⿡ �������̰� ������ ����
    //                         2. ���Ϸ� ���� ����ϴµ� ��� ����� ŭ
    //                         3. ������ ������ �߻��Ͽ� ȸ���� ��ġ�� ���� ���� �� ����
    // ���ʹϾ� (Quaternion) : 1. (X, Y, Z, W) �� ���� ���� �̷������ �ϳ��� ����(x, y, z)�� �ϳ��� ��Į��(w, roll)�� �ǹ�
    //                        2. �� ���п� ���� ���� �� ������ ���� ����
    //                        3. �� ���� ���ÿ� ȸ����Ű�⿡ ������ ������ �߻����� ����
    //                        4. ���Ͱ� ��ġ(position)+����(direction) �̵���, ���ʹϾ��� ����(orientation)+ȸ��(rotation) ��
    // ������ (Gimbal Lock) : ���� �������� ������Ʈ�� �� ȸ�� ���� ��ġ�� ����

    // ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����
    private void Rotation()
    {
        // Ʈ�������� ȸ����
        // EulerAngle -> Quaternion
        transform.rotation = Quaternion.identity;

        // Quaternion -> EulerAngle
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

}
