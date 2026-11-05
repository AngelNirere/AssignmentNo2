using System;
using System.Windows.Forms;

namespace Lab2
{
    public class ChooseForm : BaseForm
    {
        public ChooseForm()
        {
            Text = "Choose";
            ClientSize = new System.Drawing.Size(320, 150);

            var lbl = new Label { Text = "Choose an option:", Left = 20, Top = 20, AutoSize = true };
            var btnBicycle = new Button { Text = "Bicycle", Left = 30, Top = 60, Width = 110, Height = 40 };
            var btnMushroom = new Button { Text = "Mushroom", Left = 170, Top = 60, Width = 110, Height = 40 };

            btnBicycle.Click += (s, e) => GoTo(new BicycleForm());
            btnMushroom.Click += (s, e) => GoTo(new MushroomForm());

            Controls.AddRange(new Control[] { lbl, btnBicycle, btnMushroom });
        }
    }
}