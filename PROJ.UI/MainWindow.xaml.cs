using PROJECT.UI.providers;
using PROJECT.UI.viewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PROJECT.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICustomProvider _mecaluxProvider;
        public MainWindow(ICustomProvider mecaluxProvider)
        {
            _mecaluxProvider = mecaluxProvider;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await FillDataContext();
        }

        private async Task FillDataContext()
        {
            var options = await _mecaluxProvider.GetOrderOptions();
            var data = ComboboxViewModel.Build(options);
            DataContext = data;
        }

        private async void OrderTextBtn_Click(object sender, RoutedEventArgs e)
        {
            var text = getRichTextBoxText(textToProcessRtb);
            if (!string.IsNullOrWhiteSpace(text))
            {
                var result = await _mecaluxProvider.GetOrderedText(new models.TextOrder { Option = optionsCb.Text, Text = text });
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Empty text");
            }
        }

        private async void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            var text = getRichTextBoxText(textToProcessRtb);
            if (!string.IsNullOrWhiteSpace(text))
            {
                var result = await _mecaluxProvider.GetTextStatistics(text);
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Empty text");
            }
        }

        private string getRichTextBoxText(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }
    }
}
