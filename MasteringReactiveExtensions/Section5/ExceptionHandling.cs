using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Rx.Net.MasteringReactiveExtensions.Section2;

namespace Rx.Net.MasteringReactiveExtensions.Section5
{
    public class ExceptionHandling
    {
        public ExceptionHandling()
        {
            CatchExeption();
        }

        private void CatchExeption()
        {
            var subj = new Subject<int>();
            var fallback = Observable.Range(1, 3);

            subj.Catch(fallback)
                .Inspect("subj");

            subj.OnNext(32);
            subj.OnError(new Exception("oops"));

        }
    }
}