using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Rx.Net.MasteringReactiveExtensions.Section2;

namespace Rx.Net.MasteringReactiveExtensions.Section3
{
    public class ObservableCreator
    {
        private static IObservable<string> Blocking()
        {
            var subj = new ReplaySubject<string>();
            subj.OnNext("foo", "bar");
            subj.OnCompleted();
            Thread.Sleep(3000);

            return subj;
        }

        private static IObservable<string> NonBlocking()
        {
            return Observable.Create<string>
            (
                observer => 
                {
                    observer.OnNext("foo", "bar");
                    observer.OnCompleted();
                    Thread.Sleep(3000);
                    
                    return Disposable.Empty;
                }
            );
        }
        
        // static void Main(string[] args)
        // {
        //     // Blocking().Inspect("blocking");
        //     // NonBlocking().Inspect("nonblocking");

        //     var tenToTwenty = Observable.Range(10, 11);
        //     tenToTwenty.Inspect("range");

        //     var generated = Observable.Generate(
        //         1,
        //         value => value < 100,
        //         value => value * value + 1,
        //         value => $"[{value}]" // Select()
        //     );

        //     generated.Inspect("generate");

        //     var interval = Observable.Interval(TimeSpan.FromMilliseconds(500));
        //     using (interval.Inspect("interval"))
        //     {
        //         Console.Read();
        //     }
        // }
    }
}