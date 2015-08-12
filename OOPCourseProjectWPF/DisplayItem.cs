using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace OOPCourseProjectWPF
{
    class DisplayItem
    {
        public Storable StorableItem { get; private set; }

        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }

        public BitmapImage Image { get; private set; }

        public ObservableCollection<DisplayItem> Items { get; private set; }

        public DisplayItem(Storable storable)
        {
            StorableItem = storable;
            if (storable is Contract)
                DisplayContract(storable as Contract);
            else if (storable is Cheese)
                DisplayCheese(storable as Cheese);
            else if (storable is Wheat)
                DisplayWheat(storable as Wheat);
        }

        private void DisplayContract(Contract contract)
        {
            this.Title = String.Format("{0} ({1}) на сумму {2:C}",
                contract.Name, contract.Date.ToShortDateString(), contract.Cost);
            this.Subtitle
                = String.Format("Поставщик: {0}, получатель: {1}",
                contract.Supplier, contract.Purchaser);
            this.Description = String.Empty;
            this.Image = CreateImageFromAssets("contract.png");
            this.Items = new ObservableCollection<DisplayItem>();
            foreach (Storable item in contract)
                this.Items.Add(new DisplayItem(item));
        }

        private void DisplayCheese(Cheese cheese)
        {
            this.Title = String.Format("Сыр на сумму {0:C}", cheese.Cost);
            this.Subtitle = String.Format("Сыр: {0}, {1}, {2}",
                    cheese.Kind.Name, cheese.Fatness.Value, cheese.Cover.Name); ;
            this.Description = String.Format("Выполнено {0}/{1}, испорченность: {2:P2}",
                cheese.PlannedNumber, cheese.RealNumber, cheese.Staleness);
            this.Image = CreateImageFromAssets("cheese.png");
            this.Items = new ObservableCollection<DisplayItem>();
        }

        private void DisplayWheat(Wheat wheat)
        {
            this.Title = String.Format("Пшеница на сумму {0:C}", wheat.Cost);
            this.Subtitle = String.Format("Пшеница: {0}, {1}",
                    wheat.Grade.Name, wheat.Hardness.Name); ;
            this.Description = String.Format("Выполнено {0}/{1}, испорченность: {2:P2}",
                wheat.PlannedNumber, wheat.RealNumber, wheat.Staleness);
            this.Image = CreateImageFromAssets("wheat.png");
            this.Items = new ObservableCollection<DisplayItem>();
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            try
            {
                Uri uri = new Uri(imageFilename, UriKind.RelativeOrAbsolute);
                return new BitmapImage(uri);
            }
            catch (System.IO.IOException)
            {
                return new BitmapImage();
            }
        }
    }
}
