using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewPanel : MonoBehaviour
{
    public GameObject[] scrollViewArr;
    private int index = 0;
    private float deltaTime;
    public TextMeshProUGUI text;
    public TextMeshProUGUI title;

    private void Start()
    {
        OnClickLeft();
    }

    public void OnClickLeft()
    {
        scrollViewArr[index].SetActive(false);
        index = Mathf.Max(index - 1, 0);
        scrollViewArr[index].SetActive(true);
        title.text = scrollViewArr[index].name;
    }

    public void OnClickRight()
    {
        scrollViewArr[index].SetActive(false);
        index = Mathf.Min(index + 1, scrollViewArr.Length - 1);
        scrollViewArr[index].SetActive(true);
        title.text = scrollViewArr[index].name;
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / Time.deltaTime;

        // 텍스트 업데이트
        text.text = $"FPS: {fps:0.}";
    }
}
