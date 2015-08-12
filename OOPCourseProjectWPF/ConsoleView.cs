using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class ConsoleView
    {
        private ContractModel contractModel;

        public ConsoleView(ContractModel contractModel) { this.contractModel = contractModel; }

        private string Indent(int level)
        {
            string indentString = " ";
            string result = String.Empty;
            for (int i = 0; i < level; i++)
                result += indentString;
            return result;
        }

        private void ShowDisplayItem(DisplayItem displayItem, int indentLevel = 0)
        {
            Console.WriteLine("{0}{1}", Indent(0), displayItem.Title);
            Console.WriteLine("{0}{1}", Indent(0), displayItem.Subtitle);
            Console.WriteLine("{0}{1}", Indent(0), displayItem.Description);
            foreach (DisplayItem item in displayItem.Items)
                ShowDisplayItem(item, indentLevel + 1);
        }

        public void Display()
        {
            foreach (Contract contract in contractModel)
                ShowDisplayItem(new DisplayItem(contract));
        }
    }
}
