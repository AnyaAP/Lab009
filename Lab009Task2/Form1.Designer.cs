namespace Lab009Task2
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListOfCities = new System.Windows.Forms.ComboBox();
            this.ShowWeather = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListOfCities
            // 
            this.ListOfCities.FormattingEnabled = true;
            this.ListOfCities.Location = new System.Drawing.Point(0, 0);
            this.ListOfCities.Name = "ListOfCities";
            this.ListOfCities.Size = new System.Drawing.Size(201, 24);
            this.ListOfCities.TabIndex = 0;
            this.ListOfCities.SelectedIndexChanged += new System.EventHandler(this.ListOfCities_SelectedIndexChanged);
            // 
            // ShowWeather
            // 
            this.ShowWeather.Location = new System.Drawing.Point(216, 1);
            this.ShowWeather.Name = "ShowWeather";
            this.ShowWeather.Size = new System.Drawing.Size(278, 23);
            this.ShowWeather.TabIndex = 1;
            this.ShowWeather.Text = "Вывести погоду в выбранном городе";
            this.ShowWeather.UseVisualStyleBackColor = true;
            this.ShowWeather.Click += new System.EventHandler(this.ShowWeather_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowWeather);
            this.Controls.Add(this.ListOfCities);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ListOfCities;
        private System.Windows.Forms.Button ShowWeather;
    }
}

