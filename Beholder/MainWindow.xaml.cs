using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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

namespace Beholder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Category selectedCategory;
        private Problem selectedProblem;

        public Category[] category { get; set; } = new Category[3];

        public Category SelectedCategory
        {
            get => selectedCategory; set
            {
                selectedCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCategory)));
            }
        }
        public Problem SelectedProblem
        {
            get => selectedProblem;
            set
            {
                selectedProblem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProblem)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            category[0] = new Category { Title = "Качество коммунальных услуг" };
            category[1] = new Category { Title = "Планы по обустройству дома" };
            category[2] = new Category { Title = "Иные проблемы жителей" };

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCategory != null) SelectedCategory.Problems.Add(new Problem());
        }
    }
    public class Category
    {
        public string Title { get; set; }
        public ObservableCollection<Problem> Problems { get; set; } = new();
    }
    public class Problem
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Applicant { get; set; }
        public string Solve { get; set; }
    }
}