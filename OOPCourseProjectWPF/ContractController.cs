using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace OOPCourseProjectWPF
{
    class ContractController : IObserver
    {
        private MainWindow contractView;
        private ContractModel contractModel = new ContractModel();

        private static Random random = new Random();
        private IContractFactory contractFactory = RandomContractFactory.CreateFactory(random);

        private DispatcherTimer generationTimer = new DispatcherTimer();

        private ItemCollection DisplayItems;
        public DisplayItem SelectedItem { get; set; }

        public void StartStorage() { generationTimer.Start(); }

        public void StopStorage() { generationTimer.Stop(); }

        public void AddContract() { contractModel.Add(contractFactory.Create()); }

        public void RemoveSelectedContract()
        {
            if (SelectedItem != null && SelectedItem.StorableItem is Contract)
            {
                Contract selectedContract = SelectedItem.StorableItem as Contract;
                contractModel.Remove(selectedContract);
                SelectedItem = null;
            }
        }

        private void generationTimer_Tick(object sender, EventArgs e)
        {
            foreach (Contract contract in contractModel)
                contract.Store();
            UpdateDisplayItems();
        }

        public void Notify() { UpdateDisplayItems(); }

        private void UpdateDisplayItems()
        {
            DisplayItems.Clear();
            foreach (Contract contract in contractModel)
                DisplayItems.Add(new DisplayItem(contract));
        }

        public void Undo() { contractModel.Revert(); }

        public ContractController(MainWindow contractView)
        {
            this.contractView = contractView;
            DisplayItems = contractView.contracts.Items;
            generationTimer.Tick += generationTimer_Tick;
            generationTimer.Interval = TimeSpan.FromSeconds(1);
            contractModel.Subscribe(this);
        }

        public void Load(string filename)
        {
            contractModel = ContractModel.LoadState(filename);
            contractModel.Subscribe(this);
        }

        public void Save(string filename) { contractModel.SaveState(filename); }
    }
}
