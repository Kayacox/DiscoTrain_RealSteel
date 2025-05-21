using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Manager : MonoBehaviour
{
    public int gold = 100;

    public S_Scroll scrollData;

    public Canvas scrollCanvas;
    private TextMeshProUGUI canvasText;

    public Canvas goldCanvas;
    private TextMeshProUGUI goldText;

    public Canvas tutorialCanvas;
    private TextMeshProUGUI tutorialText;

    // Start is called before the first frame update
    void Start()
    {
        canvasText = scrollCanvas.GetComponentInChildren<TextMeshProUGUI>();
        goldText = goldCanvas.GetComponentInChildren <TextMeshProUGUI>();
        tutorialText = tutorialCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasText.text = FormatArray(scrollData.currentParts);
        goldText.text = "Gold: "+gold.ToString();
        tutorial();
    }

    string FormatArray(string[] arr) 
    {
        string[] labels = { "Material", "Pommel", "Guard", "Wrap" };

        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        for (int i = 0; i < arr.Length && i < labels.Length; i++)
        {
            builder.AppendLine($"{labels[i]}: {arr[i]}");
        }

        return builder.ToString();
    }
    void tutorial()
    {
        Debug.Log("here");
        tutorialText.text = "Taketh thy " + scrollData.currentParts[0] + " ore from the storage room, and place it with the furnace with coal to purify it into ingot form\n" +
            "Take your " + scrollData.currentParts[0] + " ingot and hammer it upon the anvil, with four precise strikes.\n" +
            "After the blade has been hammered, quench it in a tank to cool it.\n" +
            "After cooling, take the blade to the grindstone to sharpen its edge.\n" +
            "After the edge has been sharpened, hold your blade above the wrapping station and add a " + scrollData.currentParts[1] + " guard, "+ scrollData.currentParts[3] + " wrapping, and " + scrollData.currentParts[2] + "pommel.\n" +
            "After this, your sword has been completed and is ready for sale.";
    }
}
