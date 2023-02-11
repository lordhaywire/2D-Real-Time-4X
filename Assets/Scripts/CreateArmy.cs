using TMPro;
using UnityEngine;

public class CreateArmy : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private GameObject armyListGameObject;

    //private int numberOfArmies = 0; // This is the current number of armies spawned by the player.
    public void CreateArmyButton()
    {
        // This is so we can only create the army in our own counties.
        if (WorldMapLoad.counties[SelectCounty.currentlySelectedCounty].ownerName == WorldMapLoad.playerName)
        {
            var armyNumber = WorldMapLoad.armies.Count;
            var newArmyList = new Army(null, null, null, null, null, null,false, false,false, "Player", "Fuck Stick" + armyNumber, Random.Range(1, 1001));

            WorldMapLoad.armies.Add(newArmyList);

            newArmyList.gameObject = Instantiate(unitPrefab, WorldMapLoad.counties[SelectCounty.currentlySelectedCounty].countyCenterGameObject.transform.position,
              Quaternion.identity);
            //Debug.Log("New Army Game Object: " + newArmyList.gameObject);
            // Change name of GameObject in the inspector
            newArmyList.gameObject.name = armyNumber.ToString();

            // This just sets it to it's basic starting color.
            newArmyList.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            // Move GameObject to army list in Inspector.
            newArmyList.gameObject.transform.parent = armyListGameObject.transform;

            // This is for the text box above the army's gameObject in the game.
            newArmyList.armyTimerCanvasGameObject = newArmyList.gameObject.transform.GetChild(0).gameObject;
            newArmyList.armyTimerText = newArmyList.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

            // This is the ArmyMovement script attached to the gameObject as a component.
            newArmyList.armyMovement = newArmyList.gameObject.GetComponent<ArmyMovement>();
            Debug.Log("Army Movement Script? " + newArmyList.armyMovement);
            
            // Store the current location name of the army.
            newArmyList.location = SelectCounty.currentlySelectedCounty;
            Debug.Log("Current Location: " + newArmyList.location);

            // Sets the army Destination to its current location.
            newArmyList.armyDestination = SelectCounty.currentlySelectedCounty;

            // Change the Army Info Panel to have the new army info from list.
            WorldMapLoad.armyInfoPanel.SetActive(true);

            UIArmyPanel.armyOwnerText.text = "Owner: " + newArmyList.owner; //WorldMapLoad.armies[numberOfArmies].owner;
            UIArmyPanel.armyNameText.text = "Name: " + newArmyList.name; //WorldMapLoad.armies[numberOfArmies].name;
            UIArmyPanel.armySizeText.text = "Size: " + newArmyList.size.ToString(); //WorldMapLoad.armies[numberOfArmies].size.ToString();


            WorldMapLoad.countyInfoPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You don't own this county, so you can't spawn armies here.");


        }

    }
}
