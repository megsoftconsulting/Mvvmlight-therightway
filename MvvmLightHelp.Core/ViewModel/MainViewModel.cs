using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Views;

namespace MvvmLightHelp.Core.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        readonly IProductRepository _productRepository;
        readonly INavigationService _navigationService;
        readonly ILoggingService _logger;

        const string buttonDefaulText = "Get Item";


        public MainViewModel(IProductRepository productRepository, INavigationService navigationService, ILoggingService logger)
        {
            _productRepository = productRepository;
            _navigationService = navigationService;
            _logger = logger;

            Items = new ObservableCollection<Product>();
            ButtonText = buttonDefaulText;
            CanGetItems = true;

            GetItemsCommand = new RelayCommand(async () => await GetItems());
            ItemClickedCommand = new RelayCommand(ItemClick);
        }


        #region "Commands"
        public RelayCommand GetItemsCommand { get; private set; }

        public RelayCommand ItemClickedCommand { get; private set; }
        #endregion

        #region "Properties"
        public ObservableCollection<Product> Items { get; private set;}

        public Product SelectedItem { get; set; }

        public bool CanGetItems { get; private set;}

        public string ButtonText { get; set; }
        #endregion

        async Task GetItems()
        {
            try
            {
                CanGetItems = false;
                ButtonText = "Loading....";

                var list = await _productRepository.GetProductsAsync();

                if (list == null)
                    return;

                Items.Clear();
                foreach (var item in list)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
            }
            finally
            {
                CanGetItems = true;
                ButtonText = buttonDefaulText;
            }

        }

        void ItemClick()
        {
            _navigationService.NavigateTo(NavigationKey.DetailsPage, "Helo");
        }
    }
}