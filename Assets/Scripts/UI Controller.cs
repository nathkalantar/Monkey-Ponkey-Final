using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Slider slider;
    public TMPro.TextMeshProUGUI bananaText;
    public bool Slidercito=true;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateBananaCount();
        UpdateBarraDeteccion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBarraDeteccion()
    {
        if (Slidercito)
        {
            slider.value = LevelManager.instance.valordedeteccion;
        }
        
    }

    public void UpdateBananaCount()
    {
        bananaText.text = LevelManager.instance.bananaCollected.ToString();
    }
}
