
public class CountyPopulation
{
    public string firstName;
    public string lastName;

    public bool isFactionLeader;
    public bool isHero;
    public bool isWorker;
    public bool isMale;
    public int age;

    public string currentActivity;
    public string currentBuilding;
    public string nextActivity;
    public string nextBuilding;

    public CountyPopulation(string firstName, string lastName, bool isFactionLeader, bool isHero, bool isWorker,
         bool isMale, int age, string currentActivity, string currentBuilding, string nextActivity,  string nextBuilding)
    {
        this.firstName = firstName;
        this.lastName = lastName;

        this.isFactionLeader = isFactionLeader;
        this.isHero = isHero;
        this.isWorker = isWorker;
        this.isMale = isMale;
        this.age = age;

        this.currentActivity = currentActivity;
        this.currentBuilding = currentBuilding;
        this.nextActivity = nextActivity;  
        this.nextBuilding = nextBuilding;
    }
}
