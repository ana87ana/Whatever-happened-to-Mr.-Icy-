using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class JournalUI : MonoBehaviour
{
    public GameObject journalPanel;
    public Text leftPageText;
    public Text rightPageText;
    public Button nextButton;
    public Button prevButton;

    private int currentPageIndex = 0;

    
    private List<string> allPageContents = new List<string>()
    {
        "Day 1\nAS I ARRIVE IN THIS STRANGE PLACE, I CAN'T HELP BUT WONDER HOW WAS IT EVEN MADE. WHAT IS THE REASON? WHY WAS IT SO HARD TO FIND? WHAT IS AT THE TOP? AS I MAKE MY WAY UP, WHAT WILL I DISCOVER?",
        "Day 2\nI'M STILL NOT PAST THIS STUPID, COLD PART OF THE TOWER. i CAN'T EVEN SEE THE TOP OF IT WHEN LOOKING UP. AND THESE PEOPLE REALLY NEED TO CHILL.",
        "Day 3\nTHE PEOPLE IN THIS TOWER HAVE BEEN PRETTY NICE SO FAR, THEY STILL WON'T TELL ME WHAT'S AT THE TOP, BUT IT DOESN'T MATTER, I'LL FIND OUT.",
        "Day 4\nTHESE PEOPLE ARE USELESS. THEY KEEP TALKING ABOUT NONSENSE, THEY JUST DON'T UNDERSTAND THE TRAVELER'S NEED TO EXPLORE.",
        "Day 5\nI MUST BE CLOSE. WHEN I LOOK UP I CAN SEE THE TOWER STARTING TO CHANGE. I THINK THERE'S PROBABLY TREASURE UP THERE, OR MAYBE A MAP TO THE TREASURE.",

        "Day 6\nIT TURNS OUT THIS IS NOT, IN FACT THE TOP OF THE TOWER, IT IS MERELY JUST ANOTHER SECTOR OF IT. I'M NOT TOO UPSET THOUGHT, IT IS MY GOAL TO EXPLORE AS MUCH AS I CAN.",
        "Day 7\nGOING FROM A FREEZING ENVIRONMET TO SWEATING IN A JUNGLE CLIMATE IS REALLY NOT IDEAL. THERE ARE A LOT LESS PEOPLE HERE WHICH IS NICE. THEY KEPT TELLING ME TO BE CAREFUL, BUT I'M A PROFESSIONAL.",
        "Day 9\nOF COURSE THE ONE PERSON THAT'S HERE IS USELESS. THEY'RE TELLING ME IT'S TOO DANGEROUS FOR ME TO MOVE ON TO THE NEXT PART AND TO JUST LEAVE. NONE OF THESE PEOPLE GET IT. THEY'RE ALL IDIOTS.",
        "Day 12\nAFTER SCOWERING AROUND THE TOWER AND GATHERING MATERIALS, I FINALLY CONVICED THE PERSON HERE TO BUILD ME WHAT I NEED. I'M NOW ONE STEP CLOSER TO THE TOP.",
        "Day 13\nI SEE ANOTHER PORTAL AT THE TOP. HOPEFULLY THIS IS TO THE TOP OF THE TOWER. THE WIZARD I'VE MET HERE IS QUITE NICE, BUT TOO CAUTIOUS. NOTHING IS TOO DANGEROUS FOR THE BEST EXPLORER IN THE WORLD",

        "Day 17\nTHANK GOD I'M FINALLY OUT OF THAT WATER DUNGEON. I CAN'T REMEMBER A MORE DIFFICULT EXPEDITION THAN THIS ONE. ALTHOUGH, I AM SURPRISED THE WATER DIDN'T DAMAGE THE JOURNAL. GOOD MAGIC.",
        "Day 18\nTHIS PART OF THE TOWER FEELS... WEIRD. I CAN'T REALLY EXPLAIN IT. IT FEELS LIKE IT'S HIDING SOMETHING. MAYBE THE WIZARDS PARANOIA IS FINALLY GETTING TO ME. HE SEEMS MORE AND MORE RESERVED.",
        "Day 20\nI HAD TO TAKE A DAY OFF FROM GOING UP. IT WAS TOO TIRING. AFTER I GET TO THE TOP, I DON'T THINK I'LL EVER COME BACK HERE.",
        "Day 22\nTHIS CLIMB FEELS LIKE IT'LL LAST FOREVER. IT JUST KEEPS GOING UP AND UP AND UP...",
        "Day 25\nI'M SO TIRED, WHY CAN'T I JUST GET TO THE TOP. THESE STUPID PEOPLE IN THE TOWER SHOULD HAVE JUST TOLD ME WHAT'S AT THE TOP, HOW DARE THEY LIE TO ME. THEY KNOW, THEY ALL KNOW.",
        "Day 26\nALMOST THERE. I CAN FEEL IT. IT'S JUST A LITTLE BIT FARTHER",
        "Day 29??\nI KEEP FEELING\n\n\n           LIKE I'M GOING IN\n\n\n\n                                 CIRCLES",
        "Day ...\nWHERE IS IT?!?!\n WHAT AM I LOOKING FOR?!!?!?!?",
        "Day xx\n IT'S BEEN SO LONG SINCE I'VE SEEN SUNLIGHT...",
        "UZFTUZ  FOI  NOOOO!  ZTDZR\n ZGUKHJGC  SFJLIH\n\n\nJZFKJL\n\n\n\n                       KJAEABJAV"
    };

    private void Start()
    {
        Keybinds.LoadKeybinds();   
    }

    private void Update()
    {
        if (Input.GetKey(Keybinds.keys["Journal"]) && InventoryManager.Instance.generalItems.Contains("Journal"))
        {
            if (journalPanel.activeSelf)
                CloseJournal();
            else
                OpenJournal();
        }
    }

    public void OpenJournal()
    {
        journalPanel.SetActive(true);
        Time.timeScale = 0;
        UpdateJournalUI();
    }

    public void CloseJournal()
    {
        journalPanel.SetActive(false);
        Time.timeScale = 1;
    }

  public void NextPage()
{
    int totalReadablePages = JournalProgress.Instance.GetTotalReadablePages();
    if (currentPageIndex + 2 < totalReadablePages)
    {
        currentPageIndex += 2;
        UpdateJournalUI();
    }
}

public void PreviousPage()
{
    if (currentPageIndex >= 2)
    {
        currentPageIndex -= 2;
        UpdateJournalUI();
    }
}


    void UpdateJournalUI()
    {
        int readablePages = JournalProgress.Instance.GetTotalReadablePages();

        leftPageText.text = GetPageContent(currentPageIndex, readablePages);
        rightPageText.text = GetPageContent(currentPageIndex + 1, readablePages);

        prevButton.interactable = currentPageIndex > 0;
        nextButton.interactable = currentPageIndex + 2 < readablePages;
    }

    string GetPageContent(int index, int readablePages)
    {
        if (index >= allPageContents.Count)
            return "";
        else if (index < readablePages)
            return allPageContents[index];
        else
            return "MISSING";
    }
}
