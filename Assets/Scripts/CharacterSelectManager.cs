using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
////TODO: Create way of interacting and invoking the Select Character Method
public class CharacterSelectManager : MonoBehaviour
{
    private GridLayoutGroup gridLayout;
    [HideInInspector]
    public Vector2 slotArtworkSize;


    public static CharacterSelectManager instance;

    [Header("Characters List")]
    public List<CharacterSelectData> characters = new List<CharacterSelectData>();
    [Space]
    [Header("Public References")]
    public GameObject charCellPrefab;
    public GameObject gridBgPrefab;
    public Transform playerSlotsContainer;
    [Space]
    [Header("Current Confirmed Character")]
    public CharacterSelectData confirmedCharacter;


    public CharacterSelectEvent OnCharacterSelect;

    public void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(gridLayout.cellSize.x * 5, gridLayout.cellSize.y * 2);
        RectTransform gridBG = Instantiate(gridBgPrefab, transform.parent).GetComponent<RectTransform>();
        gridBG.transform.SetSiblingIndex(transform.GetSiblingIndex());
        gridBG.sizeDelta = GetComponent<RectTransform>().sizeDelta;

        slotArtworkSize = playerSlotsContainer.GetChild(0).Find("Artwork").GetComponent<RectTransform>().sizeDelta;

        foreach (CharacterSelectData character in characters)
        {
            SpawnCharacterCell(character);
        }
    }

    private void SpawnCharacterCell(CharacterSelectData character)
    {
        GameObject charCell = Instantiate(charCellPrefab, transform);

        charCell.name = character.characterName;

        Image artwork = charCell.transform.Find("Artwork").GetComponent<Image>();
        //TextMeshProUGUI name = charCell.transform.Find("nameRect").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = character.characterSprite;
        //name.text = character.characterName;

        artwork.GetComponent<RectTransform>().pivot = uiPivot(artwork.sprite);
        //artwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
    }

    public void ShowCharacterInSlot(int player, CharacterSelectData character)
    {
        bool nullChar = (character == null);

        Color alpha = nullChar ? Color.clear : Color.white;
        Sprite artwork = nullChar ? null : character.characterSprite;
        string name = nullChar ? string.Empty : character.characterName;
        string playernickname = "Player " + (player + 1).ToString();
        string playernumber = "P" + (player + 1).ToString();

        Transform slot = playerSlotsContainer.GetChild(player);

        Transform slotArtwork = slot.Find("Artwork");
        Transform slotIcon = slot.Find("Icon");

        //Sequence s = DOTween.Sequence();
        //s.Append(slotArtwork.DOLocalMoveX(-300, .05f).SetEase(Ease.OutCubic));
        //s.AppendCallback(() => slotArtwork.GetComponent<Image>().sprite = artwork);
        //s.AppendCallback(() => slotArtwork.GetComponent<Image>().color = alpha);
        //s.Append(slotArtwork.DOLocalMoveX(300, 0));
        //s.Append(slotArtwork.DOLocalMoveX(0, .05f).SetEase(Ease.OutCubic));

        if (nullChar)
        {
            //slotIcon.GetComponent<Image>().DOFade(0, 0);
            return;
        }
        else
        {
            slotIcon.GetComponent<Image>().sprite = character.characterIcon;
            //slotIcon.GetComponent<Image>().DOFade(.3f, 0);
        }

        if (artwork != null)
        {
            slotArtwork.GetComponent<RectTransform>().pivot = uiPivot(artwork);
            slotArtwork.GetComponent<RectTransform>().sizeDelta = slotArtworkSize;
            //slotArtwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
        }
        //slot.Find("name").GetComponent<TextMeshProUGUI>().text = name;
        //slot.Find("player").GetComponentInChildren<TextMeshProUGUI>().text = playernickname;
        //slot.Find("iconAndPx").GetComponentInChildren<TextMeshProUGUI>().text = playernumber;
    }

    public void ConfirmCharacter(int player, CharacterSelectData character)
    {
        if (confirmedCharacter == null)
        {
            confirmedCharacter = character;
            //playerSlotsContainer.GetChild(player).DOPunchPosition(Vector3.down * 3, .3f, 10, 1);
        }
    }

    public Vector2 uiPivot(Sprite sprite)
    {
        Vector2 pixelSize = new Vector2(sprite.texture.width, sprite.texture.height);
        Vector2 pixelPivot = sprite.pivot;
        return new Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);
    }
}

[Serializable]
public class CharacterSelectEvent : UnityEvent<int, ActorData>
{

}
