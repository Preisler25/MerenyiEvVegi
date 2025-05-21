using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MerenyiEvVegi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        UserDataSource.LoadUsers();
        TodoDataSource.LoadTodos();
        
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        RegisterWindow registerWindow = new RegisterWindow();
        registerWindow.Show();
        Close();
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        string name = NevTextBox.Text;
        string password = JelszoTextBox.Password;
        
        if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password))
        {
            MessageBox.Show("Your name or password is empty!");
            return;
        }

        if (UserDataSource.users.Any(u => u.Name == name && u.Password == password))
        {
            User newUser = UserDataSource.users.Single(u => u.Name == name && u.Password == password);
            ActiveUserContext.User = newUser;
            
            TodoWindow todoWindow = new TodoWindow();
            todoWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Login failed!");
        }
    }
}