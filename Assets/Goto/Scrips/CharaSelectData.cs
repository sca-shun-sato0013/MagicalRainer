using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonlyUsed;

public class CharaSelectData : MonoBehaviour
{
    [SerializeField]
    GameObject MagicalGirlImage;

    [SerializeField]
    GameObject MagicSwordsMan;

    [SerializeField]
    Loading loadingA,loadingB;

    [SerializeField,Header("CharacterTextBox")]
    Image characterInfoTextBox;

    [SerializeField, Header("スキル動画フレーム")]
    Image skillPreviewImage;
    [SerializeField,Header("スキル情報フレーム")]
    Image skillInfoImage;

    public string CharaName { get; set; } = "";

    public void CharaSelect(Button button)
    {
        if (CharaName == "MagicalGirl")
        {
            MagicalGirlImage.SetActive(true);
            MagicSwordsMan.SetActive(false);
            button.onClick.AddListener(loadingA.LoadNextScene);
            ImageLoading.ImageLoadingAsync(characterInfoTextBox,"CharacterTextBox_A");
        }

        //スプライトがSwordではなくSowrd
        if (CharaName == "MagicSowrdsMan")
        {
            MagicalGirlImage.SetActive(false);
            MagicSwordsMan.SetActive(true);
            button.onClick.AddListener(loadingB.LoadNextScene);
            ImageLoading.ImageLoadingAsync(characterInfoTextBox, "CharacterTextBox_B");
        }
    }

    public void SkillSelect()
    {
        if (CharaName == "MagicalGirl")
        {
            ImageLoading.ImageLoadingAsync(skillInfoImage, "SkillInfo_Pink");
            ImageLoading.ImageLoadingAsync(skillPreviewImage, "SkillPreview_Pink");
        }

        //スプライトがSwordではなくSowrd
        if (CharaName == "MagicSowrdsMan")
        {
            ImageLoading.ImageLoadingAsync(skillInfoImage, "SkillInfo_Blue");
            ImageLoading.ImageLoadingAsync(skillPreviewImage, "SkillPreview_Blue");
        }
    }
}