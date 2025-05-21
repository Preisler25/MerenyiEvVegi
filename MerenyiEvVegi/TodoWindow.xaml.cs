using System.Windows;
using System.Windows.Controls;
using static MerenyiEvVegi.TodoState;

namespace MerenyiEvVegi;

public partial class TodoWindow : Window
{
    public TodoWindow()
    {
        InitializeComponent();
        TodoListBox.ItemsSource = TodoDataSource.todos.Where(t => t.UserId == ActiveUserContext.User.Id).Select(t => $"{t.Id}, {t.State} \t|\t {t.Priority} \t|\t {t.Task}" );
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        string task = TaskTextBox.Text;
        string prio = PrioComboBox.Text;
        string state = StateComboBox.Text;

        if (String.IsNullOrEmpty(task) || String.IsNullOrEmpty(prio) || String.IsNullOrEmpty(state))
        {
            MessageBox.Show("Field can not be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (task.Contains(",") || prio.Contains(",") || state.Contains(","))
        {
            MessageBox.Show("Field can not contain commas!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        Todo todo = Todo.FromString($"{task},{ActiveUserContext.User.Id},{prio},{state},{TodoDataSource.todos.Count}"); 
        TodoDataSource.AddTodo(todo);
        TodoDataSource.SaveTodos();
        TodoListBox.ItemsSource = TodoDataSource.todos.Where(t => t.UserId == ActiveUserContext.User.Id).Select(t => $"{t.Id}, {t.State} \t|\t {t.Priority} \t|\t {t.Task}" );
    }

    private TodoState ChangeTodoState(TodoState state)
    {
        TodoState selected;
        switch (state)
        {
            case Completed:
                selected = NotStarted;
                break;
            case NotStarted:
                selected = InProgress;
                break;
            case InProgress:
                return Completed;
            default:
                return NotStarted;
        }
        return selected;
    }
    
    private void TodoListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int index = TodoListBox.SelectedIndex;
        
        if (index != -1)
        {
            string text = TodoListBox.Items[index].ToString()?.Split(",")[0];
            int id;
                if (!int.TryParse(text, out id))
                    throw new FormatException("id needs to be an integer");
                TodoDataSource.todos[id].State = ChangeTodoState(TodoDataSource.todos[id].State);
                TodoDataSource.SaveTodos(); 
                TodoListBox.ItemsSource = TodoDataSource.todos.Where(t => t.UserId == ActiveUserContext.User.Id)
                    .Select(t => $"{t.Id}, {t.State} \t|\t {t.Priority} \t|\t {t.Task}");
        }
    }
}