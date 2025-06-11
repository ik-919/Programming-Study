using System.Collections;
using UnityEngine;

// RGB Lamp의 색상을 정한 시간에 따라 순차적으로 깜박이게 한다.
// 속성: 시간, 램프 색상
public class LampManager : MonoBehaviour
{
    public float time;
    public Renderer redLamp;
    public Renderer greenLamp;
    public Renderer blueLamp;
    Coroutine lampCoroutine;

    void Start()
    {
        // 처음 시작시 색상을 검게 초기화
        // _Color 는 Shader의 특정 속성: 파이프 라인에 따라 다음
        redLamp.material.SetColor("_BaseColor", Color.black);
        greenLamp.material.SetColor("_BaseColor", Color.black);
        blueLamp.material.SetColor("_BaseColor", Color.black);

        lampCoroutine = StartCoroutine(CoStartLamp()); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(lampCoroutine); // 코루틴 강제 종료
        }
         
    }

    // 코루틴을 사용, time 간격으로 점등, 점멸하는 Lamp
    IEnumerator CoStartLamp()
    {
        while (true)
        {
            redLamp.material.SetColor("_BaseColor", Color.red);
            greenLamp.material.SetColor("_BaseColor", Color.black);
            blueLamp.material.SetColor("_BaseColor", Color.black);
            yield return new WaitForSeconds(2);

            redLamp.material.SetColor("_BaseColor", Color.black);
            greenLamp.material.SetColor("_BaseColor", Color.green);
            yield return new WaitForSeconds(3);

            greenLamp.material.SetColor("_BaseColor", Color.black);
            yield return new WaitForSeconds(1);

            blueLamp.material.SetColor("_BaseColor", Color.blue);
            yield return new WaitForSeconds(1);

            blueLamp.material.SetColor("_BaseColor", Color.black);

        }


    }

}
