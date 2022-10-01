using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Background : MonoBehaviour, IPointerEnterHandler
{
    public Color BcolorTurn = Color.white;
    public Color TcolorTurn = Color.white;

    public Texture2D sprRightArrow;
    public Texture2D sprLeftArrow;
    public Texture2D sprDownArrow;

    private GameObject mainCamera;

    private Text authorText;
    private Text flippersText;
    private Text impulseText;
    private Text escText;

    private RawImage rightArrowImg;
    private RawImage leftArrowImg;
    private RawImage downArrowImg;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        getTexts();
        getImages();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        mainCamera.GetComponent<Camera>().backgroundColor = BcolorTurn;

        authorText.color = TcolorTurn;
        flippersText.color = TcolorTurn;
        impulseText.color = TcolorTurn;
        escText.color = TcolorTurn;

        rightArrowImg.texture = sprRightArrow;
        leftArrowImg.texture = sprLeftArrow;
        downArrowImg.texture = sprDownArrow;
    }

    private void getTexts()
    {
        authorText = GameObject.Find("Canvas").transform.Find("Author").GetComponent<Text>();
        flippersText = GameObject.Find("Canvas").transform.Find("Flippers").GetComponent<Text>();
        impulseText = GameObject.Find("Canvas").transform.Find("Impulse").GetComponent<Text>();
        escText = GameObject.Find("Canvas").transform.Find("Esc").GetComponent<Text>();
    }

    private void getImages()
    {
        rightArrowImg = GameObject.Find("Canvas").transform.Find("RightArrow").GetComponent<RawImage>();
        leftArrowImg = GameObject.Find("Canvas").transform.Find("LeftArrow").GetComponent<RawImage>();
        downArrowImg = GameObject.Find("Canvas").transform.Find("DownArrow").GetComponent<RawImage>();
    }

}
