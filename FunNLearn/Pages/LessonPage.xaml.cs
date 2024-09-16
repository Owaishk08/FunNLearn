using FunNLearn.Model;

namespace FunNLearn.Pages;

public partial class LessonPage : ContentPage
{
	private List<Level> levels;
	public LessonPage()
	{
		InitializeComponent();
        InitializeLevels();
	}

    private void InitializeLevels()
    {
        levels = new List<Level>
        {
            new Level { LevelNumber = 1, LevelDescription = "Counting Objects", LevelDifficulty = "Easy", LevelTask = RunCountingObjects, isLocked = false },
            new Level { LevelNumber = 2, LevelDescription = "Basic Addition", LevelDifficulty = "Easy", LevelTask = RunBasicAddition, isLocked = true },
            new Level { LevelNumber = 3, LevelDescription = "Pattern Recognition", LevelDifficulty = "Easy", LevelTask = RunPatternRecognition, isLocked = true },
        };
        LevelListView.ItemsSource = levels;
    }
    private async void OnLevelSelected(object sender, ItemTappedEventArgs e)
    {
        if(e.Item == null) 
            return;

        var selectedLevel = (Level)e.Item;

        if (selectedLevel != null && !selectedLevel.isLocked)
        {
            bool isTaskCompleted = await selectedLevel.LevelTask();

            if (isTaskCompleted)
            {
                await DisplayAlert("Success", "You completed the level!", "Next Level");
                UnlockNextLevel(selectedLevel.LevelNumber);
            }
            else
            {
                await DisplayAlert("Try Again", "You didn't complete the level. Try again", "Retry");
            }
        }
        ((ListView)sender).SelectedItem = null;
    }

    private void UnlockNextLevel(int currentLevelNumber)
    {
        var nextLevel = levels.FirstOrDefault(l=> l.LevelNumber == currentLevelNumber + 1);
        if (nextLevel != null)
        {
            nextLevel.isLocked = false;
        }
        LevelListView.ItemsSource = null;
        LevelListView.ItemsSource = levels;
    }

    private async Task<bool> RunCountingObjects()
	{
		int correctCount = 3;
		string userInput = await DisplayPromptAsync("Counting", "How many apple are there?");

		if(int.TryParse(userInput, out int userCount) && userCount == correctCount)
		{
			return true;
		}
		return false;
	}
    private async Task<bool> RunBasicAddition()
    {
        int correctAnswer = 5;
        string userAnswer = await DisplayPromptAsync("Math", "What is 3 + 2 ?");

        if (int.TryParse(userAnswer, out int userSum) && userSum == correctAnswer)
        {
            return true;
        }
        return false;
    }
    private async Task<bool> RunPatternRecognition()
    {
        int correctAnswer = 8;
        string userAnswer = await DisplayPromptAsync("What number comes next in the pattern 2,4,6,_,10",null,"OK");

        if (userAnswer == correctAnswer.ToString())
        {
            return true;
        }
        return false;
    }

    
}