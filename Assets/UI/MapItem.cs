using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator TitleLabel;
    public Animator OpenButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TitleLabel.SetBool("Show", true);
        OpenButton.SetBool("Show", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TitleLabel.SetBool("Show", false);
        OpenButton.SetBool("Show", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
