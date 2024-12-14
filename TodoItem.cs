using System.ComponentModel;

namespace MauiApp1
{
    public class TodoItem : INotifyPropertyChanged
    {
        private string _status = "To Do";
        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                    OnPropertyChanged(nameof(TextDecorations)); // Update UI when status changes
                }
            }
        }

        // Property to set strikethrough if the task is "Completed"
        public TextDecorations TextDecorations => Status == "Completed" ? TextDecorations.Strikethrough : TextDecorations.None;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
