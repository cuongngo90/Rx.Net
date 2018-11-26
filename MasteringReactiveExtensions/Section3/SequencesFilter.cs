using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Rx.Net.MasteringReactiveExtensions.Section2;

namespace Rx.Net.MasteringReactiveExtensions.Section3
{
    public class SequencesFilter
    {
        public SequencesFilter()
        {
            WhereOperator();
            DistinctOperator();
            SkipTakeOperator();
            SkipTakeWhileOperator();
            SkipUntilOperator();      
        }     

        private void WhereOperator()
        {
            Observable.Range(0, 100)
                .Where(i => i % 9 == 0)
                .Inspect("where");
        }  

        private void DistinctOperator()
        {
            var values = new List<int>(new int[] {1,1,2,2,1,1,2,2});

            values.ToObservable()
                //.Select(x => x * x)
                .DistinctUntilChanged()
                .Inspect("Select distinct");
        }

        private void SkipTakeOperator()
        {
             Observable.Range(1,10)
                .Skip(3)
                .Take(4)
                .Inspect("skip/take");
        }

        private void SkipTakeWhileOperator()
        {
            Observable.Range(-5, 10)
                .SkipWhile(x => x < 0)
                .TakeWhile(x => x < 6)
                .Inspect("while");  
        }

        private void SkipUntilOperator()
        {
            var values = Observable.Range(-10, 21);

            var stockPrices = new Subject<float>();
            var optionPrices = new Subject<float>();

            stockPrices.SkipUntil(optionPrices)
                .Inspect("skipuntil");

            stockPrices.OnNext(4,5,6);

            optionPrices.OnNext(1);

            stockPrices.OnNext(1);
            stockPrices.OnNext(2);
            stockPrices.OnNext(3);

            //optionPrices.OnNext(55);           
        }
    }
}