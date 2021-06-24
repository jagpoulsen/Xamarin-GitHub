using System;
using System.Collections.Generic;
using Xamarin_GitHub.Data.Api;
using Xamarin_GitHub.Data.Entity;
using Xamarin_GitHub.Domain;

namespace Xamarin_GitHub.Data.Repository
{
    public class GitHubUserRepository: IRepository
    {
        private readonly IRestApi _restApi = new RestApi();		
        
        public IObservable<List<GitHubUserEntity>> GitHubUsers(string query)
        {
            return _restApi.GitHubUsers(query);
        }
    }
}