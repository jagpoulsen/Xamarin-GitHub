using System;
using System.Collections.Generic;
using Xamarin_GitHub.Data.Entity;

namespace Xamarin_GitHub.Data.Api
{
    public interface IRestApi
    {
        IObservable<List<GitHubUserEntity>> GitHubUsers(string query);
    }
}