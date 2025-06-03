using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    [SerializeField] private string BodyPartName;
    [SerializeField] private Sprite GreyedOut;
    [SerializeField] private Sprite ColoredIn;
    private Image IconImage;
    private IInventory PlayerInv;

    private void Start()
    {
        IconImage = GetComponent<Image>();
        PlayerInv = Object.FindFirstObjectByType<PlayerScript>().PlayerInventory;
    }

    private void Update()
    {
        if (PlayerInv.HasItem(BodyPartName))
        {
            IconImage.sprite = ColoredIn;
        }
        else
        {
            IconImage.sprite = GreyedOut;
        }
    }
}
