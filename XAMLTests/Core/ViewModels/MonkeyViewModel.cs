using System;
using System.Collections.ObjectModel;
using Core.Models;

namespace Core.ViewModels
{
    public class MonkeyViewModel
    {
        public ObservableCollection<MonkeyModel> Monkeys { get; private set; }

        public MonkeyViewModel()
        {
            Monkeys = new ObservableCollection<MonkeyModel>();
            Monkeys.Add(new MonkeyModel()
            {
                Name = "Macaco Prego",
                Image = "monkey1.jpg"
            });

            Monkeys.Add(new MonkeyModel()
            {
                Name = "Bugio",
                Image = "monkey2.jpg"
            });

            Monkeys.Add(new MonkeyModel()
            {
                Name = "Sagui",
                Image = "monkey3.jpg"
            });
        }
    }
}
