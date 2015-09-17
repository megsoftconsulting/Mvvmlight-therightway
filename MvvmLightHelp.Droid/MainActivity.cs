
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightHelp.Core.ViewModel;
using MvvmLightHelp.Core;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace MvvmLightHelp.Droid
{
    [Activity(Label = "MvvmLightHelp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {

        public ObservableAdapter<Product> Adapter { get; set; }

        MainViewModel _vm;
        public MainViewModel VM { get { return _vm;} }

        Button _getItemButton;
        ListView _itemListView;
        TextView _itemsCountTextView;
        TextView _noItemsTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            new Bootstrapper().Run();

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Initialize();

            SetBindings();
        }

        void Initialize()
        {
            _getItemButton = FindViewById<Button>(Resource.Id.getItemButton);
            _itemListView = FindViewById<ListView>(Resource.Id.itemList);
            _itemsCountTextView = FindViewById<TextView>(Resource.Id.itemsCountTextView);
            _noItemsTextView = FindViewById<TextView>(Resource.Id.noItemTextView);

            _vm = ServiceLocator.Current.GetInstance<MainViewModel>();

        }


        void SetBindings()
        {
            _getItemButton.SetCommand("Click", VM.GetItemsCommand);

            this.SetBinding( () => VM.CanGetItems, _getItemButton, () => _getItemButton.Enabled, BindingMode.OneWay);
            this.SetBinding( () => VM.ButtonText, _getItemButton, () => _getItemButton.Text, BindingMode.OneWay);


            this.SetBinding(() => VM.Items.Count, _noItemsTextView, () => _noItemsTextView.Visibility, BindingMode.OneWay)
                .ConvertSourceToTarget(CountToVisibilityConverter.Convert);

            this.SetBinding(() => VM.Items.Count, _itemsCountTextView, () => _itemsCountTextView.Visibility, BindingMode.OneWay)
                .ConvertSourceToTarget(CountToInvisibilityConverter.Convert);

            this.SetBinding(() => VM.Items.Count, _itemsCountTextView, () => _itemsCountTextView.Text, BindingMode.OneWay)
                .ConvertSourceToTarget(m => string.Format("{0} Records found",m));

            Adapter = VM.Items.GetAdapter<Product>(ItemsTemplate);
            Adapter.DataSource = VM.Items;
            _itemListView.Adapter = Adapter;

            _itemListView.ItemClick += OnItemListViewClicked;
        }


        void OnItemListViewClicked (object sender, AdapterView.ItemClickEventArgs e)
        {
            VM.SelectedItem = Adapter[e.Position];
            VM.ItemClickedCommand.Execute(null);
//            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
//
//            nav.NavigateTo(NavigationKey.DetailsPage, "Hello");
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


