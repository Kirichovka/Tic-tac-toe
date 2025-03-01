namespace Tic_Tac_Toe.Menu.Play
{
    partial class PlayUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            checkedListBoxDifficulties = new CheckedListBox();
            labelDifficulties = new Label();
            labelGameMode = new Label();
            checkedListBoxGameMode = new CheckedListBox();
            btnConfirm = new Button();
            btnReturn = new Button();
            SuspendLayout();
            // 
            // checkedListBoxDifficulties
            // 
            checkedListBoxDifficulties.BorderStyle = BorderStyle.None;
            checkedListBoxDifficulties.CheckOnClick = true;
            checkedListBoxDifficulties.FormattingEnabled = true;
            checkedListBoxDifficulties.Items.AddRange(new object[] { "Normal", "Unreal" });
            checkedListBoxDifficulties.Location = new Point(261, 116);
            checkedListBoxDifficulties.Name = "checkedListBoxDifficulties";
            checkedListBoxDifficulties.Size = new Size(196, 72);
            checkedListBoxDifficulties.TabIndex = 0;
            checkedListBoxDifficulties.ItemCheck += checkedListBoxDifficulties_ItemCheck;
            // 
            // labelDifficulties
            // 
            labelDifficulties.AutoSize = true;
            labelDifficulties.Location = new Point(261, 81);
            labelDifficulties.Name = "labelDifficulties";
            labelDifficulties.Size = new Size(196, 32);
            labelDifficulties.TabIndex = 1;
            labelDifficulties.Text = "Game Difficulties";
            // 
            // labelGameMode
            // 
            labelGameMode.AutoSize = true;
            labelGameMode.Location = new Point(261, 195);
            labelGameMode.Name = "labelGameMode";
            labelGameMode.Size = new Size(145, 32);
            labelGameMode.TabIndex = 2;
            labelGameMode.Text = "Game mode";
            // 
            // checkedListBoxGameMode
            // 
            checkedListBoxGameMode.BorderStyle = BorderStyle.None;
            checkedListBoxGameMode.CheckOnClick = true;
            checkedListBoxGameMode.FormattingEnabled = true;
            checkedListBoxGameMode.Items.AddRange(new object[] { "3x3", "5x5" });
            checkedListBoxGameMode.Location = new Point(261, 230);
            checkedListBoxGameMode.Name = "checkedListBoxGameMode";
            checkedListBoxGameMode.Size = new Size(196, 72);
            checkedListBoxGameMode.TabIndex = 3;
            checkedListBoxGameMode.ItemCheck += checkedListBoxGameMode_ItemCheck;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.LightGreen;
            btnConfirm.Location = new Point(280, 334);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(150, 46);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.LightGray;
            btnReturn.Location = new Point(280, 386);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(150, 46);
            btnReturn.TabIndex = 5;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // PlayUserControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReturn);
            Controls.Add(btnConfirm);
            Controls.Add(checkedListBoxGameMode);
            Controls.Add(labelGameMode);
            Controls.Add(labelDifficulties);
            Controls.Add(checkedListBoxDifficulties);
            Name = "PlayUserControl";
            Size = new Size(800, 445);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxDifficulties;
        private Label labelDifficulties;
        private Label labelGameMode;
        private CheckedListBox checkedListBoxGameMode;
        private Button btnConfirm;
        private Button btnReturn;
    }
}
