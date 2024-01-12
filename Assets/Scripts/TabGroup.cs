using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public Color colorIdle;
    public Color colorHover;
    public Color colorActive;
    
    public TabButton selectedTab;

    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        button.toggleObject.SetActive(false);
        button.background.color = colorIdle;
        button.background.sprite = tabIdle;
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab != null && button ==  selectedTab)
        {
            return;
        }
        button.background.color = colorHover;
        button.background.sprite = tabHover;
    }

    public void OnTabExit(TabButton button) 
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.toggleObject.SetActive(true);
        button.background.color = colorActive;
        button.background.sprite = tabActive;
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
            {
                continue;
            }
            button.toggleObject.SetActive(false);
            button.background.color = colorIdle;
            button.background.sprite = tabIdle;
        }
    }
}
