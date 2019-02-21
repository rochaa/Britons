using System.Text.RegularExpressions;

namespace System {
    public static class StringExtension {
        public static bool TelefoneValido (this string value) {
            Regex telefoneRegex = new Regex (@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$");

            return !string.IsNullOrEmpty (value) && telefoneRegex.Match (value).Success;
        }

        public static bool CepValido (this string value) {
            Regex cepRegex = new Regex (@"[0-9]{5}-[0-9]{3}");

            return !string.IsNullOrEmpty (value) && cepRegex.Match (value).Success;
        }
    }
}