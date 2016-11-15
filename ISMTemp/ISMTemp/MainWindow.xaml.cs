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
using System.Net;
using System.Text.RegularExpressions;

namespace ISMTemp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            string s = client.DownloadString("https://www.gismeteo.ua/weather-zhytomyr-4943/");
            string temp = @"<dd class=.value m_temp c.>((.*)(\d+))";
            Regex reg_temp = new Regex(temp);
            Match temp1 = reg_temp.Match(s);
            if (temp1.Groups[2].Value.ToString() == "+" || temp1.Groups[2].Value.ToString() == "")
            {
                Label_temp.Content = "Температура :" + temp1.Groups[1].Value + "°C";
            }
            else 
            {
                Label_temp.Content = "Температура :" +"-"+ temp1.Groups[3].Value + "°C";
            }
            string mm=@"<span class='value m_press torr'>(\d+)";
            Regex reg_mm = new Regex(mm);
            Match mm1=reg_mm.Match(s);
            Label_mm.Content="Тиск :"+mm1.Groups[1].Value+" мм. рт. ст.";
            string vol = @"<div class=.+ title=.+>(\d+)";
            Regex reg_vol = new Regex(vol);
            Match vol1 = reg_vol.Match(s);
            Label_vol.Content = "Вологість :" + vol1.Groups[1].Value + "%";
            string speed = @"<dd class='value m_wind ms' style='display:inline'>(\d+)";
            Regex reg_speed = new Regex(speed , RegexOptions.Multiline);
            Match speed1 = reg_speed.Match(s);
            Label_speed.Content = "Швидкість вітру : " + speed1.Groups[1].Value + " м/с";
            string vater = @"class=.wicon water..+>\s+<dd .+>.?(\d+)";
            Regex reg_vater = new Regex(vater);
            Match vater1 = reg_vater.Match(s);
            Label_vater.Content = "Температура води : " + vater1.Groups[1].Value + "°C";
        }

        private void Money_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            string s = client.DownloadString("http://finance.i.ua/nbu/");
            string doll = @"<td .+>Доллар США<\/td>\s+<td>(\d+.\d+)";
            Regex doll_reg = new Regex(doll);
            Match doll1 = doll_reg.Match(s);
            Label_dol.Content = "Долар : " + doll1.Groups[1].Value;
            string rub = @"<td .+>Российский рубль<\/td>\s+<td>(\d+.\d+)";
            Regex rub_reg = new Regex(rub);
            Match rub1 = rub_reg.Match(s);
            Label_rub.Content = "Рубль :" + rub1.Groups[1].Value;
            string euro = @"<td .+>Евро<\/td>\s+<td>(\d+.\d+)";
            Regex euro_reg = new Regex(euro);
            Match euro1 = euro_reg.Match(s);
            Label_euro.Content = "Євро :" + euro1.Groups[1].Value;

        }
    }
}
