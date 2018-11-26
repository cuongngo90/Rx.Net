using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Rx.Net.MasteringReactiveExtensions.Section2;

namespace Rx.Net.MasteringReactiveExtensions.Section4
{
    public class SequenceAggregation
    {
        public SequenceAggregation()
        {
            //CountOperator();
            MinMaxAverageOperator();
        }

        private void CountOperator()
        {
            var values = Observable.Range(1, 6);
            values.Inspect("values");
            values.Count().Inspect("count");
        }

        private void MinMaxAverageOperator()
        {
            var values = new List<int> (new int[] {1,2,4});
            var obs =  values.ToObservable();
            obs.Min().Inspect("min");
            obs.Max().Inspect("max");
            obs.Average().Inspect("avg");
        }
    }
}