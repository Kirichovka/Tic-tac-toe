using System;
using System.Windows.Forms;

namespace Tic_Tac_Toe.Menu.Play
{
    public partial class PlayUserControl : UserControl
    {
        public event Action ReturnClicked;
        public event Action<int, int> ConfirmClicked;
        //public event Action<int> DifficultySelected;
        //public event Action<int> GameModeSelected;

        public PlayUserControl()
        {
            InitializeComponent();
            checkedListBoxDifficulties.SetItemChecked(0, true);
            checkedListBoxGameMode.SetItemChecked(0, true);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnClicked?.Invoke();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int difficulty = GetSelectedDifficulty();
            int gameMode = GetSelectedGameMode();

            ConfirmClicked?.Invoke(gameMode, difficulty);
        }

        private void checkedListBoxDifficulties_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBoxDifficulties.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    checkedListBoxDifficulties.SetItemChecked(i, false);
                }
            }

            //if (e.NewValue == CheckState.Checked)
            //{
            //    DifficultySelected?.Invoke(e.Index);
            //}
        }

        private void checkedListBoxGameMode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBoxGameMode.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    checkedListBoxGameMode.SetItemChecked(i, false);
                }
            }

            //if (e.NewValue == CheckState.Checked)
            //{
            //    GameModeSelected?.Invoke(e.Index);
            //}
        }



        private int GetSelectedDifficulty()
        {
            for (int i = 0; i < checkedListBoxDifficulties.Items.Count; i++)
            {
                if (checkedListBoxDifficulties.GetItemChecked(i))
                {
                    return i;
                }
            }
            return 0;
        }

        private int GetSelectedGameMode()
        {
            for (int i = 0; i < checkedListBoxGameMode.Items.Count; i++)
            {
                if (checkedListBoxGameMode.GetItemChecked(i))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
