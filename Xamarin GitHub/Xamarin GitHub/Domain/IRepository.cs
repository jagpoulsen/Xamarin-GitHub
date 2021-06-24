using System;
using System.Collections.Generic;
using Xamarin_GitHub.Data.Entity;

namespace Xamarin_GitHub.Domain
{
    public interface IRepository
    {
        IObservable<List<GitHubUserEntity>> GitHubUsers(string query);
    }
}