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

namespace TextReplacer
{
    public partial class Splash : Window
    {
        // Define a durção da tela de Splash utilizando um timer
        public Splash()
        {
            InitializeComponent();

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.5);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                new Main().Show();
                this.Close();
            };
            timer.Start();
        }
    }
}