using System;
using System.Collections.Generic;
using Xamarin_GitHub.Data.Entity;
using Xamarin_GitHub.Data.Repository;

namespace Xamarin_GitHub.Domain.UseCase
{
    public class GetAllGitHubUsersUseCase: UseCase<List<GitHubUserEntity>, Params>
    {
        private readonly IRepository _repository = new GitHubUserRepository();

        public override IObservable<List<GitHubUserEntity>> BuildUseCaseObservable(Params param)
        {
            return _repository.GitHubUsers(param.Query);
        }
    }
    public class Params
    {
        public string Query { get; set; }
    }
    
}