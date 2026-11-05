using System;
using System.Windows.Forms;

namespace Lab2
{
    public class MushroomForm : BaseForm
    {
        Label lblQuestion;
        Button btnYes, btnNo, btnStart;
        int state = -1;

        // 0 ring | 1 forest | 2 convex (after ring, no forest) | 3 gills | 4 convex (after no ring, gills)
        string[] questions =
        {
            "Does your mushroom have a ring?",
            "Does your mushroom grow in a forest?",
            "Does your mushroom have a convex cup?",
            "Does your mushroom have gills?",
            "Does your mushroom have a convex cup?"
        };

        public MushroomForm()
        {
            Text = "Mushroom Finder";
            ClientSize = new System.Drawing.Size(380, 250);

            var lblInfo = new Label
            {
                Text = "Think of one of the six mushrooms,\nthen answer truthfully.",
                Left = 20,
                Top = 15,
                AutoSize = true
            };
            lblQuestion = new Label { Text = "", Left = 20, Top = 70, Width = 340, Height = 30 };

            btnStart = new Button { Text = "Start", Left = 130, Top = 110, Width = 110, Height = 34 };
            btnYes = new Button { Text = "Yes", Left = 70, Top = 110, Width = 100, Height = 34, Visible = false };
            btnNo = new Button { Text = "No", Left = 210, Top = 110, Width = 100, Height = 34, Visible = false };
            btnStart.Click += (s, e) => StartQuiz();
            btnYes.Click += (s, e) => Answer(true);
            btnNo.Click += (s, e) => Answer(false);

            var btnBack = new Button { Text = "Back", Left = 70, Top = 195, Width = 100, Height = 34 };
            var btnLogout = new Button { Text = "Logout", Left = 210, Top = 195, Width = 100, Height = 34 };
            btnBack.Click += (s, e) => GoTo(new ChooseForm());
            btnLogout.Click += (s, e) => GoTo(new LoginForm());

            Controls.AddRange(new Control[] { lblInfo, lblQuestion, btnStart, btnYes, btnNo, btnBack, btnLogout });
        }

        private void StartQuiz()
        {
            btnStart.Visible = false;
            btnYes.Visible = true;
            btnNo.Visible = true;
            state = 0;
            lblQuestion.Text = questions[state];
        }

        private void Answer(bool yes)
        {
            switch (state)
            {
                case 0: state = yes ? 1 : 3; break;
                case 1:
                    if (yes) { Finish("Amanite tue-mouche"); return; }
                    state = 2; break;
                case 2: Finish(yes ? "Agaric jaunissant" : "Coprin chevelu"); return;
                case 3:
                    if (!yes) { Finish("Cepe de Bordeaux"); return; }
                    state = 4; break;
                case 4: Finish(yes ? "Pied bleu" : "Girolle"); return;
            }
            lblQuestion.Text = questions[state];
        }

        private void Finish(string mushroom)
        {
            MessageBox.Show("Your mushroom is: " + mushroom, "Result",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            state = -1;
            lblQuestion.Text = "";
            btnYes.Visible = false;
            btnNo.Visible = false;
            btnStart.Visible = true;
        }
    }
}