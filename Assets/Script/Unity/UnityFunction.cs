using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFunction : MonoBehaviour
{
    [Header("This")]
    public GameObject thisGameObject;
    public string thisName;
    public bool thisActive;
    public string thisTag;
    public int thisLayer;

    [Header("GameObject")]
    public GameObject newGameObject;
    public GameObject destroyGameObject;
    public GameObject findWithName;
    public GameObject findWithTag;

    [Header("Component")]
    //public Component newComponent;
    public Component addComponent;
    public Component destroyComponent;
    public Component getComponent;
    public Component findComponent;

    private void Start()
    {
        //ThisFunction();
        //GameObjectFunction();
        ComponentFunction();
    }

    private void ThisFunction()
    {
        /* ���� ���� ������Ʈ ���� */

        // ������Ʈ�� �پ��ִ� ���� ������Ʈ�� Component�� ������ gameObject �Ӽ��� �̿��Ͽ� ���ٰ���
        thisGameObject = gameObject;                // ������Ʈ�� �پ��ִ� ���� ������Ʈ
        thisName = gameObject.name;                 // ���� ������Ʈ�� �̸�
        thisActive = gameObject.activeSelf;         // ���� ������Ʈ�� Ȱ��ȭ ���� (activeInHierarchy : ���Ӿ����� Ȱ��ȭ ����)
        thisTag = gameObject.tag;                   // ���� ������Ʈ�� �±�
        thisLayer = gameObject.layer;               // ���� ������Ʈ�� ���̾�
    }

    private void GameObjectFunction()
    {
        /* ���� ������Ʈ ���� */
        newGameObject = new GameObject("NewGameObject");

        /* ���� ������Ʈ ���� */
        if (destroyGameObject != null)
        {
            //Destroy(destroyGameObject);
            Destroy(destroyGameObject, 3f);  // 3f : 3�� �ڿ� ����
        }
        // ���� ������Ʈ�� �̿��� �ٸ� ������Ʈ ����, ���� ����


        /* ���� ������Ʈ Ž�� */
        findWithName = GameObject.Find("Main Camera");        // �̸����� ã�� (�̸� ��Ÿ, ��ü Ž�� ��ȿ����. ���� �Ⱦ�)
        findWithTag = GameObject.FindWithTag("MainCamera");     // �±׷� ã�� (�� ����)
    }

    private void ComponentFunction()
    {
        /* ������Ʈ �߰� */
        //newComponent = new Rigidbody();  // �ǹ̾���. ������Ʈ�� ���� ������Ʈ�� �����Ǿ� ������ �� �ǹ̰� ����
        addComponent = gameObject.AddComponent<Rigidbody>();

        /* ������Ʈ ���� */
        if (destroyComponent != null)
        {
            Destroy(destroyComponent);
        }

        /* ������Ʈ Ž�� - ���� ���� ������Ʈ���� ã�� */
        getComponent = gameObject.GetComponent<Collider>();  // ������ ã�� ������ none

        /* ������Ʈ Ž�� - ������ ã�� */
        findComponent = Component.FindObjectOfType<Camera>();

    }
}
