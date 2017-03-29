namespace WindowsFormsApplication1
{
    partial class Combat_Flow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region DataLand

    

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CharsBinding = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CharsBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // CharsBinding
            // 
            this.CharsBinding.DataSource = typeof(Scion.MainHard.CharacterSet);
            this.CharsBinding.CurrentChanged += new System.EventHandler(this.CBinding_CurrentChanged);
            // 
            // Combat_Flow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 616);
            this.Name = "Combat_Flow";
            this.Text = "Combat_Flow";
            ((System.ComponentModel.ISupportInitialize)(this.CharsBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource CharsBinding;
    }
}