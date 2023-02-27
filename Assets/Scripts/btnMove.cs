using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class btnMove : MonoBehaviour
{
    private Transform btntransform;
    public float movespeed=1f;
    
    // Start is called before the first frame update
    void Start()
    {
        btntransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter() 
    {
        btntransform.DOLocalMoveX(-845,0.5f);
    }
    public void OnPointerExit()
    {
        btntransform.DOLocalMoveX(-835,0.5f);

    }
}
