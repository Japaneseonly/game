using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour
{
Button ExploreButton;
 
    void Start () 
    {
        ExploreButton = GetComponent<Button>();
    }
 
    public void OneClick() 
    {
        ExploreButton.interactable = false;
    }

}
