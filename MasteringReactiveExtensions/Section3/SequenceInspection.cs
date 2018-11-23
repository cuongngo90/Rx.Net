using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Rx.Net.MasteringReactiveExtensions.Section2;

namespace Rx.Net.MasteringReactiveExtensions.Section3
{
    public class SequenceInspection
    {
        public SequenceInspection()
        {
            //AnyOperator();
            //AllOperator();
            //ContainOperator();
            DefaultIfEmptyOperator();
            ElementAtOperator();
        }

        private void AnyOperator()
        {
            // var subject = new Subject<int>();
            // subject.Any(x => x > 1).Inspect("any");            
            // subject.OnNext(0);

            //var subject = Observable.Range(-10, 5);

            var values =  Observable.Create<int> 
            (
                obs =>
                {
                    obs.OnNext(1);
                    obs.OnCompleted();

                    return Disposable.Empty;
                }
            );

            values.Any(x => x > 1).Inspect("any");
        }

        private void AllOperator()
        {
            var values = new List<int> {1,2,3,4,5};
            values.ToObservable()
                .All(x => x > 0)
                .Inspect("all");
        }

        private void ContainOperator()
        {
            var values = new List<string>(new string[] {"Foo", "Abc"});

            values.ToObservable()
                .Contains("foo")
                .Inspect("contains");
        }

        private void DefaultIfEmptyOperator()
        {
            var values = Observable.Create<float>
            (   
                obs => 
                {
                    obs.OnNext(1.23f);
                    obs.OnCompleted();

                    return Disposable.Empty;
                }
            );

            values.DefaultIfEmpty(0.99f)
                .Inspect("default if empty");
        }

        private void ElementAtOperator()
        {
            var numbers = Observable.Range(1, 10);
            numbers.ElementAt(5)
                .Inspect("elementAt");
        }

        
    }
}