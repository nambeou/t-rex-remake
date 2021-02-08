using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    TextMeshProUGUI textElemet;
    // Start is called before the first frame update
    void Start()
    {
        textElemet = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textElemet.text = FindObjectOfType<GameSession>().GetPoint().ToString();
    }
}
