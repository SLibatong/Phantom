using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenEyes : MonoBehaviour
{
    public Image myimage;
    public Image blackimage;
    private Animator myanim;
    // Start is called before the first frame update
    void Start()
    {
        myanim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void ImageChange()
    {
        myimage.DOFade(0,0.5f);
    }
    public void ImageBack()
    {
        myimage.DOFade(1,0.5f);
    }
    public void Eyes()
    {
        myanim.SetBool("IsOpen",true);
        Invoke("BlackScreen",3f);
    }
    public void BlackScreen()
    {
        blackimage.DOFade(1,1f);
        Invoke("Jump",2f);

    }
    private void Jump()
    {
        SceneManager.LoadScene(1);
    }


}
