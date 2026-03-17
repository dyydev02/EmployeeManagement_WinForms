using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppTesting
{
    public class DetailForm : Form
    {
        private TextBox textBoxDetails;

        public DetailForm(string title, IEnumerable<KeyValuePair<string, string>> items)
        {
            Text = title;
            Width = 600;
            Height = 400;
            StartPosition = FormStartPosition.CenterParent;

            textBoxDetails = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Both,
                Font = new Font("Consolas", 10),
                BackColor = SystemColors.Window,
                BorderStyle = BorderStyle.FixedSingle
            };

            var sb = new StringBuilder();
            foreach (var kv in items)
            {
                sb.AppendLine($"{kv.Key}: {kv.Value}");
            }

            textBoxDetails.Text = sb.ToString();

            Controls.Add(textBoxDetails);
        }
    }
}
