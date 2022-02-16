using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int current;
    public int maximum;
    [SerializeField]
    Image fill;
    [SerializeField]
    PlayerProgress player;
    [SerializeField]
    TMP_Text koinsText;
    [SerializeField]
    TMP_Text equippedText;
    [SerializeField]
    TMP_Text levelText;

    // Update is called once per frame
    void Update()
    {
        GetMaximum();
        GetCurrentFill();
        SetValues();
    }

    private void GetMaximum()
    {
        maximum = 100 + player.level * 10;
    }

    private void GetCurrentFill()
    {
        current = player.killScore;
        float fillAmount = (float)current / (float)maximum;
        fill.fillAmount = Mathf.MoveTowards(fill.fillAmount, fillAmount, 0 + Time.unscaledDeltaTime);
    }
    private void SetValues()
    {
        levelText.text = "LVL: " + player.level.ToString();
        koinsText.text = player.koins.ToString();
        switch (player.activeWeapon)
        {
            case 0:
                equippedText.text = "EQUIPPED: COBRA";
                return;
            case 1:
                equippedText.text = "EQUIPPED: COLT 2021";
                return;
            case 2:
                equippedText.text = "EQUIPPED: TEC-17";
                return;
            case 3:
                equippedText.text = "EQUIPPED: MP-69";
                return;
            case 4:
                equippedText.text = "EQUIPPED: SMAG-9";
                return;
            case 5:
                equippedText.text = "EQUIPPED: BLOB-3";
                return;
            case 6:
                equippedText.text = "EQUIPPED: R90";
                return;
            case 7:
                equippedText.text = "EQUIPPED: MK-47";
                return;
            case 8:
                equippedText.text = "EQUIPPED: AK-77";
                return;
            case 9:
                equippedText.text = "EQUIPPED: M5D1";
                return;
            case 10:
                equippedText.text = "EQUIPPED: AR-514";
                return;
            case 11:
                equippedText.text = "EQUIPPED: SG-15";
                return;


        }
    }
}
