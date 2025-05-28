using System.Text.RegularExpressions;

namespace Fatec.Store.User.Application.Shared.Extensions
{
    public static partial class StringExtensions
    {
        public static string UnformatCpf(this string cpf) => UnformatCpf().Replace(cpf, "");

        [GeneratedRegex(@"[^\d]")]
        private static partial Regex UnformatCpf();
    }
}
