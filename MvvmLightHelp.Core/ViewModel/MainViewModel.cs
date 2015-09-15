using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;

namespace MvvmLightHelp.Core.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly IProductRepository _productRepository;

        public RelayCommand GetItemsCommand { get; private set; }

        public ObservableCollection<Product> Items { get; private set;}

        public MainViewModel(IProductRepository productRepository)
        {
            Items = new ObservableCollection<Product>();
            GetItemsCommand = new RelayCommand(async () => await GetItems());
            _productRepository = productRepository;
        }


        async Task GetItems()
        {
            var list = await _productRepository.GetProductsAsync();

            if (list == null)
                return;

            Items.Clear();
            foreach (var item in list)
            {
                Items.Add(item);
            }
        }
    }
}