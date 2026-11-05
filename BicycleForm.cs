using System;
using System.Windows.Forms;

namespace Lab2
{
    public class BicycleForm : BaseForm
    {
        TextBox txtStart, txtEnd, txtTotal;

        public BicycleForm()
        {
            Text = "Bicycle Rental";
            ClientSize = new System.Drawing.Size(340, 280);

            var lblStart = new Label { Text = "Start hour (0-23):", Left = 20, Top = 25, AutoSize = true };
            txtStart = new TextBox { Left = 180, Top = 22, Width = 120 };
            var lblEnd = new Label { Text = "End hour (1-24):", Left = 20, Top = 65, AutoSize = true };
            txtEnd = new TextBox { Left = 180, Top = 62, Width = 120 };

            var btnCalc = new Button { Text = "Calculate", Left = 180, Top = 105, Width = 120, Height = 32 };
            btnCalc.Click += BtnCalc_Click;

            var lblTotal = new Label { Text = "Total:", Left = 20, Top = 160, AutoSize = true };
            txtTotal = new TextBox { Left = 180, Top = 157, Width = 120, ReadOnly = true };

            var btnBack = new Button { Text = "Back", Left = 40, Top = 215, Width = 110, Height = 34 };
            var btnLogout = new Button { Text = "Logout", Left = 190, Top = 215, Width = 110, Height = 34 };
            btnBack.Click += (s, e) => GoTo(new ChooseForm());
            btnLogout.Click += (s, e) => GoTo(new LoginForm());

            Controls.AddRange(new Control[] { lblStart, txtStart, lblEnd, txtEnd, btnCalc,
                                              lblTotal, txtTotal, btnBack, btnLogout });
            AcceptButton = btnCalc;
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            int start, end;
            if (!int.TryParse(txtStart.Text.Trim(), out start) || !int.TryParse(txtEnd.Text.Trim(), out end))
            {
                MessageBox.Show("Enter whole numbers only (no decimals or text).", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (start < 0 || start > 23)
            {
                MessageBox.Show("Start hour must be between 0 and 23.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (end < 1 || end > 24)
            {
                MessageBox.Show("End hour must be between 1 and 24.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (start >= end)
            {
                MessageBox.Show("Start time must be less than end time.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total = Logic.Total(start, end);
            txtTotal.Text = total + " RWF";
            MessageBox.Show("Hours rented: " + (end - start) + "\nTotal to pay: " + total + " RWF",
                "Rental result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}