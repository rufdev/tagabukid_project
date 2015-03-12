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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WpfApplication1.ViewModels;

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
            GlobalToken.Token = JObject.Parse(result).SelectToken("access_token").ToString();
            
        }

        //private async void GetData_Click(object sender, RoutedEventArgs e)
        //{
        //    var c = new HttpClient();
        //    c.BaseAddress = new Uri("https://localhost:44307/");
            
        //    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ResultArea.Text);
        //    var response = await c.GetAsync("api/testplugwebapi");
        //    response.EnsureSuccessStatusCode();

        //    var result = await response.Content.ReadAsStringAsync();
        //    ResultArea.Text = result;
            
        //}

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var c = new HttpClient();
            c.BaseAddress = new Uri("https://localhost:44307/");

            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalToken.Token);
            PersonViewModel person = new PersonViewModel();
            person.Name = Person_Name.Text;
            string jperson = JsonConvert.SerializeObject(person);
            HttpContent content = new StringContent(jperson, Encoding.UTF8, "application/json");
            var response = await c.PostAsync("api/personservice", content);
            response.EnsureSuccessStatusCode();
            
            //var result = await response.Content.ReadAsStringAsync();
            MessageBox.Show(response.StatusCode.ToString());
        }


    }

    static class GlobalToken
    {
        public static string Token { get; set; }
    }

}
