using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
[Serializable]
public struct myMaterials
{
    public Material clr1;
    public Material clr2;
}
public class jayantManager : MonoBehaviour
{
    public delegate void pointerUpEvent();//any argument
    public event pointerUpEvent onPointerUp,onPointerDown;

    public static jayantManager instance;
    public GameObject menuUI, gameUI,emptyObj;

    public bool gameStart = false;
    public bool touchPointer = false;

    public jayantPlayer jp;
    public GameObject ragdoll;

    public Slider levelSlider;
    public GameObject scrorer;
    public myMaterials[] mat;

    public GameObject wonUI, loseUI,tapBtn;

    public GameObject hand;
    public Animation circle;

    public GameObject finishRodHolder;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        hand.transform.position = Input.mousePosition;
        levelSlider.value = jayantPlayer.instance.gameObject.transform.position.z;
    }
    public void pointerDown() {
        circle.Play("handUp");

        jp.enabled = true;
        gameStart = true;
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        touchPointer = true;
        if (!jayantPlayer.instance.finishCrossed) {
            onPointerDown?.Invoke(); 
        }
       
        
    }
    public void pointerUp() {
        circle.Play("handDown"); 


        if (!jayantPlayer.instance.finishCrossed) onPointerUp?.Invoke();
        touchPointer = false;
    }

    public void levelCleared() {
        tapBtn.SetActive(false);
        StartCoroutine(lc());
    }
    IEnumerator lc() {
        yield return new WaitForSeconds(1f);
        wonUI.SetActive(true);
    }
    public void levelFailed()
    {
        tapBtn.SetActive(false);

        StartCoroutine(lf());
    }
    IEnumerator lf()
    {
        yield return new WaitForSeconds(1f);
        loseUI.SetActive(true);
    }
    public void retryClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void nextClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void changeFinishRodColor(Material mat) {
        for (int i = 0; i < finishRodHolder.transform.childCount; i++)
        {
            finishRodHolder.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
