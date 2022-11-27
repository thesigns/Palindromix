using System.IO;
using System.Text;

namespace Palindromix {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            this.Text = "Palindromix 1.0";
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            if (Program.IsPalindrome(richTextBox1.Text)) {
                ((RichTextBox)sender).BackColor = Color.FromArgb(155, 255, 155);
            } else {
                ((RichTextBox)sender).BackColor = Color.FromArgb(255, 255, 255);
            }

            var words = richTextBox1.Text.ToString().Trim().Split(' ');
            var wordLeft= words[0];
            var wordRight = words[words.Count() - 1];

            if (wordLeft.Length < 2) {
                label1.Text = "S³owa koñcz¹ce siê na ...";
                textBox2.Text = "Potrzebne co najmiej dwie litery...";
            } else {
                label1.Text = "S³owa koñcz¹ce siê na \"" + wordLeft + "\"";
                var suffix = wordLeft.Substring(wordLeft.Length - 2);
                if (!Program.suf.ContainsKey(suffix)) {
                    List<string> fileWords = new();
                    string path = AppDomain.CurrentDomain.BaseDirectory + "suf\\_" + suffix + ".txt";
                    if (File.Exists(path)) {
                        string content = File.ReadAllText(path);
                        var contentWords = content.Split(',');
                        fileWords = new List<string>(contentWords);
                    }
                    Program.suf.Add(suffix, fileWords);
                }
                StringBuilder sb = new StringBuilder();
                foreach(var word in Program.suf[suffix]) {
                    if (word.Length < 10 && wordLeft.Length <= word.Length) {
                        var substr = word.Substring(word.Length - wordLeft.Length);
                        if (substr == wordLeft) {
                            sb.Append(word);
                            sb.Append(' ');
                        }
                    }
                }
                textBox2.Text = sb.ToString();
            }

            if (wordRight.Length < 2) {
                label2.Text = "S³owa rozpoczynaj¹ce siê na ...";
                textBox3.Text = "Potrzebne co najmiej dwie litery...";
            } else {
                label2.Text = "S³owa rozpoczynaj¹ce siê na \"" + wordRight + "\"";
                var prefix = wordRight.Substring(0, 2);
                if (!Program.pre.ContainsKey(prefix)) {
                    List<string> fileWords = new();
                    string path = AppDomain.CurrentDomain.BaseDirectory + "pre\\" + prefix + "_.txt";
                    if (File.Exists(path)) {
                        string content = File.ReadAllText(path);
                        var contentWords = content.Split(',');
                        fileWords = new List<string>(contentWords);
                    }
                    Program.pre.Add(prefix, fileWords);
                }
                StringBuilder sb = new StringBuilder();
                foreach (var word in Program.pre[prefix]) {
                    if (word.Length < 10 && wordRight.Length <= word.Length) {
                        var substr = word.Substring(0, wordRight.Length);
                        if (substr == wordRight) {
                            sb.Append(word);
                            sb.Append(' ');
                        }
                    }
                }
                textBox3.Text = sb.ToString();
            }

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.C) {
                var text = ((RichTextBox)sender).SelectedText;
                var reversed = new string(text.ToCharArray().Reverse().ToArray());
                Clipboard.SetText(reversed);
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }
    }
}