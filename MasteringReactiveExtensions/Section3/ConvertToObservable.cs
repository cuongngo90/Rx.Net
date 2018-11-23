using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Rx.Net.MasteringReactiveExtensions.Section2;

namespace Rx.Net.MasteringReactiveExtensions.Section3
{
    public class Market
    {
        private float _price;
        public float Price
        {
            get => _price;
            set => _price = value;
        }
        public event EventHandler<float> priceChanged;

        public void ChangePrice(float price)
        {
            Price = price;
            priceChanged? .Invoke(this, price);
        }
    }

    public class ConvertToObservable
    {
        // static void Main()
        // {
        //     var market = new Market();
        //     var priceChanges = Observable.FromEventPattern<float>
        //     (
        //         h => market.priceChanged += h,
        //         h => market.priceChanged -= h
        //     ).Subscribe(
        //         x => Console.WriteLine($"{x.EventArgs}"),
        //         ex => Console.WriteLine(ex)
        //     );

        //     //priceChanges.Inspect("price change");

        //     market.ChangePrice(1f);
        //     market.ChangePrice(1.1f);
        //     market.ChangePrice(1.2f);
        // }
    }
}