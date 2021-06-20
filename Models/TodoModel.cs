using System;
using System.ComponentModel;

namespace TodoList.Models
{
    class TodoModel : INotifyPropertyChanged
    {
        private bool isDone;
        private string text;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return isDone; }
            set 
            {
                if (isDone == value)
                    return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string Text
        {
            get { return text; }
            set 
            {
                if (text == value)
                    return;
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
