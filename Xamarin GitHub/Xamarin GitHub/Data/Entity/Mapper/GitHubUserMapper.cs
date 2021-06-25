using Xamarin_GitHub.Domain;

namespace Xamarin_GitHub.Data.Entity.Mapper
{
    public class GitHubUserMapper : BaseMapper<GitHubUserModel, GitHubUserEntity>
    {
        protected override GitHubUserModel Transform(GitHubUserEntity entity)
        {
            var githubUser = new GitHubUserModel
            {
                Image = entity.AvatarUrl,
                Name = entity.Login
            };

            return githubUser;
        }
    }
}