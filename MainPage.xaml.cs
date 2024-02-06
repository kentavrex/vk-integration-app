using System.Net;

namespace Test
{

    
    public partial class MainPage : ContentPage
    {

        public static string TOKEN { set; get; } = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {


            string url = $"https://api.vk.com/method/account.getInfo?" +
                        $"fields=intro&" +
                        $"access_token={TokenEntry.Text}&v=5.199";


            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            string s = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Root r = new Root();
            r.Deserial(s);
            if (r.error == null) {
                TokenLabel.Text = "SUCCESS";
                TOKEN = TokenEntry.Text;
            }
            else
            {
                TokenLabel.Text = "ERROR";
            }
        }
    }
}