/*
	<싱글톤 패턴>
	- 오직 한 개의 클래스 인스턴스만을 갖도록 보장
	- 이에 대한 전역적인 접근점을 제공

	장점 :
	1. 하나뿐인 존재로 주요 클래스, 관리자의 역할을 함
	2. 전역적 접근으로 참조에 필요한 작업이 없이 빠른 접근 가능
	3. 인스턴스들이 싱글톤을 통하여 데이터를 공유하기 쉬워짐

	단점 :
	1. 싱글톤이 너무 많은 책임을 짊어지는 경우를 주의해야함
	2. 싱글톤의 남발로 전역접근이 많아지게 되는 경우, 의존도가 높아지고 참조한 코드 결합도가 높아짐
	3. 싱글톤의 데이터를 공유할 경우 데이터 변조에 주의해야함

	구현 :
	1. 생성자의 접근권한을 외부에서 생성할 수 없도록 제한
	2. 정적변수를 활용하여 캡슐화를 진행
	3. 전역에서 접근 가능한 인스턴스를 갖기 위해 정적변수(데이터 영역 메모리 공간)를 사용
	4. GetInstance 함수를 통해서 단일객체가 없는 경우 생성
	5. 단일 객체가 있는 경우는 단일 객체를 반화해 주도록 구현
	(Instance 속성를 통해 인스턴스에 접근할 수 있도록 함)
	(instance 변수는 단 하나만 있도록 유지)
*/

public class SingleTon
{
    private static SingleTon instance;

    // 생성자에 접근제한자를 private으로 주면 인스턴스 여러개 못 만들게 막아줌
    private SingleTon() { }

    // 요걸 통해서 단일 인스턴스 만들기
    public static SingleTon GetInstance()
    {
        if (instance == null)  // 1. 생성된 인스턴스 없으면
        {
            instance = new SingleTon();  // 2. 만들고
        }
        return instance;  // 3. 인스턴스 반환
    }
}

public class OtherClass
{
    public void Function()
    {
        //SingleTon instance1 = new SingleTon();
        //SingleTon instance2 = new SingleTon();

        // 위에서 객체는 하나만 만들었고 여기서 인스턴스를 여러번 가져올 수 있음?
        SingleTon a = SingleTon.GetInstance();
        SingleTon b = SingleTon.GetInstance();
        SingleTon c = SingleTon.GetInstance();
    }
}

