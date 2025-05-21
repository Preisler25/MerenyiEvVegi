using System.Windows;

namespace MerenyiEvVegi;

public partial class RegisterWindow : Window
{
    public RegisterWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow main = new MainWindow();
        main.Show();
        Close();
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        string name = NevTextBox.Text;
        string password = JelszoTextBox.Password;
        string password2 = Jelszo2TextBox.Password;
        string email = EmailTextBox.Text;
        
        if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password2) || String.IsNullOrEmpty(email))
        {
            MessageBox.Show("Field can not be empty");
            return;
        }
        if (name.Contains(",") || password.Contains(",") || email.Contains(","))
        {
            MessageBox.Show("Your name or password is containing a comma!");
            return;
        }
        if (name.Length < 3 || password.Length < 8)
        {
            MessageBox.Show("Username must be at least 3 and at least 8 characters!");
            return;
        }
        if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
        {
            MessageBox.Show("Your password must contain one UpperCased one LowerCase and one Digit!");
            return;
        }
        if (password != password2)
        {
            MessageBox.Show("Passwords do not match!");
            return;
        }
        if (UserDataSource.users.Any(u => u.Name == name))
        {
            MessageBox.Show("The username is already taken!");
            return;
        }
        if (UserDataSource.users.Any(u => u.Email == email))
        {
            MessageBox.Show("Your email is already taken!");
            return;
        }
        if (!email.Contains("@") || !email.Contains("."))
        {
            MessageBox.Show("The formating of the email address is invalid!");
            return;
        }
        User newUser = new User(UserDataSource.users.Count, name, email, password);
        UserDataSource.AddUser(newUser);
        UserDataSource.SaveUsers();
        ActiveUserContext.User = newUser;
        
        TodoWindow todoWindow = new TodoWindow();
        todoWindow.Show();
        Close();
    }
}