using System.Collections.Generic;
using UnityEngine;

public class UIPopulationInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject prefabHorizontalPopulationListText;
    [SerializeField] private GameObject parentPopulationListGroup;
    [SerializeField] private GameObject populationInfoPanel;

    private readonly List<GameObject> populationListClones = new();

    private void OnEnable()
    {
        TimeKeeper.instance.OnPanelEnable();


        if (WorldMapLoad.instance.countyPopulationDictionary[WorldMapLoad.instance.currentlySelectedCounty] != null)
        {
            var countyList = WorldMapLoad.instance.countyPopulationDictionary[WorldMapLoad.instance.currentlySelectedCounty];
            var factionList =
                WorldMapLoad.instance.factionHeroesDictionary[WorldMapLoad.instance.counties[WorldMapLoad.instance.currentlySelectedCounty].faction.name];
            
            // This is for the leaders of each faction.
            for (int i = 0; i < factionList.Count; i++)
            {
                //Debug.Log("List Index: " + i);
                populationListClones.Add
                    (Instantiate(prefabHorizontalPopulationListText, parentPopulationListGroup.transform));
                populationListClones[i].GetComponent<UIHorizontalPopulationListText>().nameText.text =
                    factionList[i].firstName + " " + factionList[i].lastName;
                populationListClones[i].GetComponent<UIHorizontalPopulationListText>().ageText.text =
                    factionList[i].age.ToString();
                if (factionList[i].isMale == true)
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().sexText.text = "Male";
                }
                else
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().sexText.text = "Female";
                }
                populationListClones[i].GetComponent<UIHorizontalPopulationListText>().currentActivityText.text =
                    factionList[i].currentActivity;
                populationListClones[i].GetComponent<UIHorizontalPopulationListText>().nextActivityText.text =
                    factionList[i].nextActivity;
            }
            // This is for the normal population in the county.
            for (int i = 0; i < countyList.Count; i++) // populationListClones.Count
            {
                int listIndex = i + factionList.Count;
                //Debug.Log("List Index: " + listIndex);
                //Debug.Log("County List Length: " + countyList.Count);
                populationListClones.Add
                    (Instantiate(prefabHorizontalPopulationListText, parentPopulationListGroup.transform));
                populationListClones[listIndex].GetComponent<UIHorizontalPopulationListText>().nameText.text =
                    countyList[i].firstName + " " + countyList[i].lastName;
                populationListClones[listIndex].GetComponent<UIHorizontalPopulationListText>().ageText.text =
                    countyList[i].age.ToString();
                if (countyList[i].isMale == true)
                {
                    populationListClones[listIndex].GetComponent<UIHorizontalPopulationListText>().sexText.text = "Male";
                }
                else
                {
                    populationListClones[listIndex].GetComponent<UIHorizontalPopulationListText>().sexText.text = "Female";
                }
                populationListClones[listIndex].GetComponent<UIHorizontalPopulationListText>().currentActivityText.text =
                    countyList[i].currentActivity;
                populationListClones[listIndex].GetComponent<UIHorizontalPopulationListText>().nextActivityText.text =
                    countyList[i].nextActivity;
            }
        }
        else
        {
            Debug.Log("The Currently Selected County is null, dipshit.");
        }
    }
    private void OnDisable()
    {
        TimeKeeper.instance.OnPanelEnable();
    }
    public void CloseButton()
    {
        for (int i = 0; i < populationListClones.Count; i++)
        {
            Destroy(populationListClones[i]);
        }
        populationListClones.Clear();
    }
}
