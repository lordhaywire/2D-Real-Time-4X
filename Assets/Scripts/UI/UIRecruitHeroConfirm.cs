using TMPro;
using UnityEngine;

public class UIRecruitHeroConfirm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI areYouSureHeroText;
    private CountyPopulation countyPopulation;
    private void OnEnable()
    {
        countyPopulation = WorldMapLoad.Instance.currentlySelectedCountyPopulation;

        areYouSureHeroText.text = $"{AllText.UIText.AREYOUSUREHERO} {countyPopulation.firstName} {countyPopulation.lastName}";
    }

    public void ConfirmHeroRecruitment()
    {
        var heroList = WorldMapLoad.Instance.heroes;
        Hero hero = new(null, countyPopulation, WorldMapLoad.Instance.playerFaction
            , WorldMapLoad.Instance.counties[WorldMapLoad.Instance.CurrentlySelectedCounty].gameObject, null, false, false, false);

        heroList.Add(hero);

        WorldMapLoad.Instance.currentlySelectedCountyPopulation.hero = hero;

        UICountyPanel.Instance.heroScrollView.SetActive(true);
    }
}
