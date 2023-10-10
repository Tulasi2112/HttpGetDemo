using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GETDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            string url = "https://randomuser.me/api/?nat=gb";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if(response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsondata);

                var myresponse = JsonConvert.DeserializeObject<MyResponse>(jsondata);
                mynamelabel.Text = myresponse.results.FirstOrDefault().name.first;
            }

        }
    }
}

