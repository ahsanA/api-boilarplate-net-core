using ErrorOr;
namespace APIBoilerplate.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalideCredentials =>
                Error.Validation(
                    code: "Auth.InvemailCredentials",
                    description: "Username or password is incorrect");
        }
    }
}