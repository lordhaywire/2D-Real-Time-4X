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
        TimeKeeper.Instance.PauseTime();

        if (WorldMapLoad.Instance.countyPopulationDictionary[WorldMapLoad.Instance.currentlySelectedCounty] != null)
        {
            var countyList = WorldMapLoad.Instance.countyPopulationDictionary[WorldMapLoad.Instance.currentlySelectedCounty];
            //var factionList =
            //    WorldMapLoad.Instance.factionHeroesDictionary[WorldMapLoad.Instance.counties[WorldMapLoad.Instance.currentlySelectedCounty].faction.name];

            // This is for the leaders of each faction.
            /*
            for (int i = 0; i < factionList.Count; i++)
            {
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
            */
            for (int i = 0; i < countyList.Count; i++)
            {
                //int listIndex = i + factionList.Count;
                //Debug.Log("List Index: " + listIndex);
                //Debug.Log("County List Length: " + countyList.Count);
                populationListClones.Add
                    (Instantiate(prefabHorizontalPopulationListText, parentPopulationListGroup.transform));
                populationListClones[i].GetComponent<UIHorizontalPopulationListText>().nameText.text =
                    countyList[i].firstName + " " + countyList[i].lastName;
                populationListClones[i].GetComponent<UIHorizontalPopulationListText>().ageText.text =
                    countyList[i].age.ToString();
                if (countyList[i].isMale == true)
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().sexText.text = "Male";
                }
                else
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().sexText.text = "Female";
                }
                // This makes it so the text box looks right.
                if (countyList[i].currentBuilding == null)
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().currentActivityText.text =
                                        $"{countyList[i].currentActivity}";
                }
                else
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().currentActivityText.text =
                    $"{countyList[i].currentActivity} \n {countyList[i].currentBuilding.name}";
                }
                // This makes it so the text box looks right.
                if (countyList[i].nextBuilding == null)
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().nextActivityText.text =
                    $"{countyList[i].nextActivity}";
                }
                else
                {
                    populationListClones[i].GetComponent<UIHorizontalPopulationListText>().nextActivityText.text =
                    $"{countyList[i].nextActivity} \n {countyList[i].nextBuilding.name}";
                }

            }
        }
        else
        {
            Debug.Log("The Currently Selected County is null, dipshit.");
        }
    }
    private void OnDisable()
    {
        TimeKeeper.Instance.UnpauseTime();
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
