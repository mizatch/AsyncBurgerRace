using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AsyncFirstExample
{
    public partial class MainWindow : Window
    {
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();
            resultsTextBox_Copy.Clear();

            BuildBurgerWithSingleCook();

            BuildBurgerWithMultipleCooks();
        }

        private async Task BuildBurgerWithSingleCook()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var textBoxToLog = resultsTextBox;

            AddLog("I will make a burger!", textBoxToLog);

            var bun = await GetBun(textBoxToLog);

            var cheese = await GetCheese(textBoxToLog);

            await AddToBun(bun, cheese, textBoxToLog);

            var ketchup = await GetKetchup(textBoxToLog);

            await AddToBun(bun, ketchup, textBoxToLog);

            var mustard = await GetMustard(textBoxToLog);

            await AddToBun(bun, mustard, textBoxToLog);

            var pickle = await GetPickle(textBoxToLog);

            await AddToBun(bun, pickle, textBoxToLog);

            var patty = await GetPatty(textBoxToLog);

            await CookPatty(patty, textBoxToLog);

            await AddToBun(bun, patty, textBoxToLog);

            stopwatch.Stop();

            AddLog($"This burger was created in {stopwatch.ElapsedMilliseconds} milliseconds", textBoxToLog);
        }

        private async Task BuildBurgerWithMultipleCooks()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var textBoxToLog = resultsTextBox_Copy;

            AddLog("Let us all make a burger!", textBoxToLog);

            var bun = GetBun(textBoxToLog);
            var cheese = GetCheese(textBoxToLog);
            var ketchup = GetKetchup(textBoxToLog);
            var mustard = GetMustard(textBoxToLog);
            var pickle = GetPickle(textBoxToLog);
            var patty = GetPatty(textBoxToLog);

            var cookPatty = CookPatty(await patty, textBoxToLog);

            await AddToBun(await bun, await cheese, textBoxToLog);

            await AddToBun(await bun, await ketchup, textBoxToLog);

            await AddToBun(await bun, await mustard, textBoxToLog);

            await AddToBun(await bun, await pickle, textBoxToLog);

            await AddToBun(await bun, await cookPatty, textBoxToLog);

            stopwatch.Stop();

            AddLog($"This burger was created in {stopwatch.ElapsedMilliseconds} milliseconds", textBoxToLog);
        }

        private async Task<Ingredient> GetPatty(TextBox textBoxToLog)
        {
            AddLog("Getting Patty", textBoxToLog);
            await Task.Delay(1000);

            return new Ingredient("patty");
        }

        private async Task<Ingredient> GetCheese(TextBox textBoxToLog)
        {
            AddLog("Getting Cheese", textBoxToLog);
            await Task.Delay(1000);

            return new Ingredient("cheese");
        }

        private async Task<Ingredient> GetBun(TextBox textBoxToLog)
        {
            AddLog("Getting Bun", textBoxToLog);
            await Task.Delay(1000);

            return new Ingredient("bun");
        }

        private async Task<Ingredient> GetKetchup(TextBox textBoxToLog)
        {
            AddLog("Getting Ketckup", textBoxToLog);
            await Task.Delay(1000);
            
            return new Ingredient("ketchup");
        }

        private async Task<Ingredient> GetMustard(TextBox textBoxToLog)
        {
            AddLog("Getting Mustard", textBoxToLog);
            await Task.Delay(1000);

            return new Ingredient("mustard");
        }

        private async Task<Ingredient> GetPickle(TextBox textBoxToLog)
        {
            AddLog("Getting Pickle", textBoxToLog);
            await Task.Delay(1000);

            return new Ingredient("pickle");
        }

        private async Task<Ingredient> CookPatty(Ingredient patty, TextBox textBoxToLog)
        {
            AddLog("Cooking patty", textBoxToLog);
            await Task.Delay(2000);
            return patty;
        }

        private async Task<Ingredient> AddToBun(Ingredient bun, Ingredient ingredient, TextBox textBoxToLog)
        {
            AddLog($"Adding {ingredient.Name} to {bun.Name}", textBoxToLog);
            await Task.Delay(500);

            return new Ingredient("bun");
        }

        private static void AddLog(string message, TextBox textBoxToLog)
        {
            textBoxToLog.Text += $"{message}\r\n";
        }

    }

    class Ingredient
    {
        public Ingredient(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}