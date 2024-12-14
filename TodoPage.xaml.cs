using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class TodoPage : ContentPage
    {
        public ObservableCollection<TodoItem> TaskList { get; set; }

        public TodoPage()
        {
            InitializeComponent();
            TaskList = new ObservableCollection<TodoItem>();
            TaskListView.ItemsSource = TaskList;
        }

        private void OnTaskAdded(object sender, EventArgs e)
        {
            string task = TaskInputField.Text?.Trim();
            if (!string.IsNullOrEmpty(task))
            {
                TaskList.Add(new TodoItem { Title = task, Status = "To Do" });
                TaskInputField.Text = string.Empty;
            }
        }

        private void OnCompleteTask(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var taskItem = (TodoItem)button.BindingContext;

            if (taskItem != null)
            {
                // Toggle between "To Do" and "Completed"
                taskItem.Status = taskItem.Status == "To Do" ? "Completed" : "To Do";
            }
        }

        private void OnRemoveTask(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var taskItem = (TodoItem)button.BindingContext;

            if (taskItem != null && TaskList.Contains(taskItem))
            {
                TaskList.Remove(taskItem);
            }
        }

        private async void OnNavigateToWeather(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
