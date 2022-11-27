namespace Palindromix {
    internal static class Program {

        public static string RemovePunctuation(string text) {
            const string characters = "a¹bcædeêfghijkl³mnñoópqrsœtuvwxyzŸ¿";
            string result = "";
            foreach (var ch in text) {
                if (characters.Contains(ch)) {
                    result += ch;
                }
            }
            return result;
        }

        public static bool IsPalindrome(string text) {
            var forwards = RemovePunctuation(text.ToLower());
            if (forwards.Length == 0) {
                return false;
            }
            var reversed = new string(forwards.ToCharArray().Reverse().ToArray());
            for (var i = 0; i < reversed.Length; i++) {
                if (forwards[i] != reversed[i]) {
                    return false;
                }
            }
            return true;
        }

        public static Dictionary<string, List<string>> pre = new();
        public static Dictionary<string, List<string>> suf = new();


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var form = new Form1();
            form.richTextBox1.SelectAll();
            form.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            form.richTextBox1.DeselectAll();

            Application.Run(form);

        }
    }
}