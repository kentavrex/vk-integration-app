using System.Net;

namespace Test;

public partial class MenuPage : ContentPage
{
    public List<string> Users { get; set; }
    public MenuPage()
	{
		InitializeComponent();

/*      Users = new List<string> { "Tom", "Bob", "Sam", "Alice" };
        BindingContext = this;*/


        string m = "friends.get";
        string f = "bdate,nickname";
        Root root = new Root();

        string url = $"https://api.vk.com/method/{m}?" +
                     $"fields={f}&" +
                     $"access_token={MainPage.TOKEN}&v=5.199";


        var request = (HttpWebRequest)WebRequest.Create(url);
        var response = (HttpWebResponse)request.GetResponse();
        string json_response = new StreamReader(response.GetResponseStream()).ReadToEnd();
        root.Deserial(json_response);


        List<PersonItem> personItems = root.response.items;

        listPersons.ItemsSource = personItems;
    }
}

/*    <StackLayout>
        <Label Text = "Список пользователей" />
        < ListView ItemsSource="{Binding Users}" />
    </StackLayout>*/