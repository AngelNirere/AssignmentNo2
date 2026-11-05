using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    // Shared behaviour: look & feel + navigation between forms.
    public class BaseForm : Form
    {
        protected bool Navigating = false;

        static readonly Color Pink = Color.FromArgb(236, 72, 153);
        static readonly Color Black = Color.FromArgb(17, 17, 17);
        static readonly Color Gray = Color.FromArgb(75, 85, 99);
        static readonly Color PageBack = Color.FromArgb(253, 242, 248);

        public BaseForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 10F);
            BackColor = PageBack;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            int headerHeight = 60;

            // push existing controls down to make room for the header
            foreach (Control c in Controls)
                c.Top += headerHeight;
            ClientSize = new Size(ClientSize.Width, ClientSize.Height + headerHeight);

            // black header bar with a pink title
            var header = new Panel { Dock = DockStyle.Top, Height = headerHeight, BackColor = Black };
            var title = new Label
            {
                Text = Text,
                ForeColor = Pink,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Left = 20,
                Top = 14
            };
            header.Controls.Add(title);
            Controls.Add(header);

            // pink accent line under the header
            var line = new Panel { Dock = DockStyle.Top, Height = 4, BackColor = Pink };
            Controls.Add(line);
            line.BringToFront();
            header.BringToFront();

            // style every control
            foreach (Control c in Controls)
            {
                if (c is Button b)
                {
                    Color color = Pink;
                    if (b.Text == "Logout" || b.Text == "No") color = Black;
                    else if (b.Text == "Back") color = Gray;

                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.BackColor = color;
                    b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color, 0.2f);
                    b.ForeColor = Color.White;
                    b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    b.Cursor = Cursors.Hand;
                }
                else if (c is TextBox t)
                {
                    t.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is Label l && l.Parent == this)
                {
                    l.ForeColor = Black;
                }
            }
        }

        // Open the next form and close this one.
        protected void GoTo(Form next)
        {
            Navigating = true;
            next.Show();
            Close();
        }

        // If the user closes the window with X, end the application.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!Navigating) Application.Exit();
        }
    }
}