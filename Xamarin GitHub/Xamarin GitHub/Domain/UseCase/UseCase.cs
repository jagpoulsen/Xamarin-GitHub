using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin_GitHub.Domain.UseCase
{
    public abstract class UseCase<T, P>
    {
        List<IDisposable> Disposables;

        public abstract IObservable<T> BuildUseCaseObservable(P param);

        public UseCase()
        {
            Disposables = new List<IDisposable>();
        }

        public void Execute(IObserver<T> observer, P param)
        {
            if (observer != null)
            {
                Task.Run(() => 
                {
                    IObservable<T> observable = BuildUseCaseObservable(param);
                    AddDisposable(observable.SubscribeSafe(observer));
                });
            }
        }

        //TODO use Dispose
        public void Dispose()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }

        void AddDisposable(IDisposable disposable)
        {
            if (Disposables != null && disposable != null)
            {
                Disposables.Add(disposable);
            }
        }
    }
}