using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
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
using Newtonsoft.Json.Linq;

namespace WpfApplication1
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

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var c = new HttpClient();
            c.BaseAddress = new Uri("https://localhost:44307/");
            //HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "Token");

            var keyValue = new List<KeyValuePair<string, string>>();
            keyValue.Add(new KeyValuePair<string, string>("grant_type", "password"));
            keyValue.Add(new KeyValuePair<string, string>("username", "admin@example.com"));
            keyValue.Add(new KeyValuePair<string, string>("password", "Admin@123456"));
            
            var content = new FormUrlEncodedContent(keyValue);
            var response = await c.PostAsync("https://localhost:44307/Token", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            ResultArea.Text = JObject.Parse(result).SelectToken("access_token").ToString();
            
        }

        private async void GetData_Click(object sender, RoutedEventArgs e)
        {
            var c = new HttpClient();
            c.BaseAddress = new Uri("https://localhost:44307/");
            
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ResultArea.Text);
            var response = await c.GetAsync("api/testplugwebapi");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            ResultArea.Text = result;
            
        }

    }

    static class GlobalToken
    {
        public static string Token { get; set; }
    }

}
