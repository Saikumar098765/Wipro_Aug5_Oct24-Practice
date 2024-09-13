using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace User_Form_Details
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text.Trim();
            string middleName = MiddleNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string gender = MaleRadioButton.IsChecked == true ? "Male" : "Female";
            string country = ((ComboBoxItem)CountryComboBox.SelectedItem).Content.ToString();
            string dateOfBirth = DateOfBirthPicker.SelectedDate.HasValue ? DateOfBirthPicker.SelectedDate.Value.ToShortDateString() : "Not Selected";

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Your name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Display the collected data
            MessageBox.Show($"Name: {firstName} {middleName} {lastName}\nGender: {gender}\nCountry: {country}\nDate of Birth: {dateOfBirth}",
                            "Submitted Data", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MiddleNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
