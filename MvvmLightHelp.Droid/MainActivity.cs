
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightHelp.Core.ViewModel;
using MvvmLightHelp.Core;

namespace MvvmLightHelp.Droid
{
    [Activity(Label = "MvvmLightHelp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        public ObservableAdapter<Product> Adapter { get; set; }

        MainViewModel _vm;
        public MainViewModel VM { get { return _vm;} }

        Button _getItemButton;
        ListView _itemListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Initialize();

            SetBindings();
        }

        void Initialize()
        {
            _getItemButton = FindViewById<Button>(Resource.Id.getItemButton);
            _itemListView = FindViewById<ListView>(Resource.Id.itemList);

            // Only for mocking 
            _vm = new MainViewModel(new MockProductRepository());
        }

        void SetBindings()
        {
            _getItemButton.SetCommand("Click", VM.GetItemsCommand);

            Adapter = VM.Items.GetAdapter<Product>(ItemsTemplate);
            Adapter.DataSource = VM.Items;

            _itemListView.Adapter = Adapter;

        }


        public View ItemsTemplate(int position, Product vm, View convertView)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            var text = convertView.FindViewById<TextView>(Android.Resource.Id.Text1);

            text.Text = string.Format("{0} (Price:{1:C2})", vm.Name, vm.Price);

            return convertView;
        }
    }
}


