using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin_GitHub.Domain.UseCase
{
    public abstract class UseCase<T, TP>
    {
        private readonly List<IDisposable> _disposables;

        protected abstract IObservable<T> BuildUseCaseObservable(TP param);

        protected UseCase()
        {
            _disposables = new List<IDisposable>();
        }

        public void Execute(IObserver<T> observer, TP param)
        {
            if (observer != null)
            {
                Task.Run(() => 
                {
                    var observable = BuildUseCaseObservable(param);
                    AddDisposable(observable.SubscribeSafe(observer));
                });
            }
        }

        //TODO use Dispose
        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }

        private void AddDisposable(IDisposable disposable)
        {
            if (_disposables != null && disposable != null)
            {
                _disposables.Add(disposable);
            }
        }
    }
}