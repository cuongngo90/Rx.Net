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
    public class SequenceTransformation
    {
        public SequenceTransformation()
        {
            //OfTypeCastOperator();
            //SelectOperator();
            //TimeIntervalOperator();
            //MaterializeOperator();
            SelectManyOperator();
        }

        private void OfTypeCastOperator()
        {
            var subj = new Subject<object>();
            subj.OfType<float>().Inspect("OfType");
            subj.Cast<float>().Inspect("Cast");

            subj.OnNext(1.0f, 2, 3.0);
        }

        private void SelectOperator()
        {
            var values = Observable.Range(1, 10);
            values.Select(x => x * x).Inspect("select");
        }

        private void TimeIntervalOperator()
        {
            var seq = Observable.Interval(TimeSpan.FromSeconds(2));

            seq.TimeInterval().Inspect("timeInterval");
            Console.Read();
        }

        private void MaterializeOperator()
        {
            var seq = Observable.Range(0, 4)            
                .Materialize()
                .Dematerialize()
                .Inspect("materialize");
        }

        private void SelectManyOperator()
        {
            Observable.Range(1, 4, Scheduler.Immediate)
                .SelectMany(x => Observable.Range(1, x, Scheduler.Immediate))           
                .Inspect("selectmany");
        }
    }
}