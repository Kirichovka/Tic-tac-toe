namespace Tic_Tac_Toe.Menu
{
    partial class MenuUserControl
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
            btnPlay = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(272, 155);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(205, 63);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(272, 234);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(205, 63);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MenuUserControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnExit);
            Controls.Add(btnPlay);
            Name = "MenuUserControl";
            Size = new Size(800, 451);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlay;
        private Button btnExit;
    }
}
