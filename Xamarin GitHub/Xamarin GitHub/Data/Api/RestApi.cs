using System;
using System.Reactive.Linq;
using System.Collections.Generic;
using Xamarin_GitHub.Data.Entity;

namespace Xamarin_GitHub.Data.Api
{
    public class RestApi : IRestApi
    {
        public IObservable<List<GitHubUserEntity>> GitHubUsers(string query)
        {
            return Observable.Create<List<GitHubUserEntity>>((emitter) =>
            { 
                var jsonResult = ApiConnection.DoGet($"{ApiConnection.HostUrl}/search/users?q={query}").Result;

                if (jsonResult != null)
                {
                    var serializer = new Serializer<GitHubResultEntity>();
                    var gitHubResult = serializer.FromJson(jsonResult);

                    emitter.OnNext(gitHubResult?.Items ?? new List<GitHubUserEntity>());
                    emitter.OnCompleted();
                }
                else
                {
                    emitter.OnError(new Exception("There was an error fetching the users"));
                }

                return () => { };
            });
        }
    }
}