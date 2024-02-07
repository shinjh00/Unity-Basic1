using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	������ ���� :
	�������� ��ü�� ���� ��ȭ�� �����ϴ� ������
	�������ü�� ���������� ����� ����Ͽ� ����
	�������ü�� ���� ��ȭ�� ���� ������ ����� �������鿡�� �˸�

	���� :
	0. C#�� ��� event delegate�� �̿��Ͽ� ������ ������ ���밡��
	0. Unity�� ��� UnityEvent�� �̿��Ͽ� ������ ������ ���밡��

	1. �������ü�� ���������� ��ϰ� �������� ���, ������ ����
	2. �������� �������ü�� ���� ��ȭ�� �˸� �ް� ���� ��� ��Ͽ� ���
	3. �������ü�� ���� ���ϰ� �ִ� ��� ����� ���������� ��ȸ�ϸ� �˸�

	���� :
	1. Ŭ�������� ������ ���ᱸ���� ������ ��ü���� �ý����� ����
	2. ��������Ģ�� �ؼ��ϰ� ��
	3. �����Ӹ��� ���� ��ȭ�� Ȯ���ϴ� ������� �ݹ����� ���� ���귮�� ���� �� ����

	���� :
	1. �˸��� ���� ������ ������ �� ����
	2. �������� ����� �̺�Ʈ ����, ��ȯ ���� ���� ������ ���� �� ����
*/

public class Observer : MonoBehaviour
{
    public void Notify() { }
}

public class Subject
{
    private List<Observer> observerList;

    public void RegisterObserver(Observer observer)
    {
        observerList.Add(observer);
    }

    public void UnregisterObserver(Observer observer)
    {
        observerList.Remove(observer);
    }

    private void NotifyObserver()
    {
        foreach (Observer observer in observerList)
        {
            observer.Notify();
        }
    }
}
