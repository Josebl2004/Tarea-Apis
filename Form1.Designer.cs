namespace Tarea_Apis
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar; 
        private System.Windows.Forms.Button btnInfoPais; 
        private System.Windows.Forms.PictureBox pictureBoxCiudad;
        private System.Windows.Forms.DataGridView dataGridViewCiudades; 
        private System.Windows.Forms.Label lblCiudad; 
        private System.Windows.Forms.TextBox txtCiudad; 
        private System.Windows.Forms.DataGridView dataGridViewPais;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnInfoPais = new Button();
            pictureBoxCiudad = new PictureBox();
            dataGridViewCiudades = new DataGridView();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            dataGridViewPais = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCiudad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCiudades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPais).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaption;
            btnBuscar.Location = new Point(371, 15);
            btnBuscar.Margin = new Padding(4, 5, 4, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 35);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveCaption;
            btnLimpiar.Location = new Point(371, 62);
            btnLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 35);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnInfoPais
            // 
            btnInfoPais.BackColor = SystemColors.ActiveCaption;
            btnInfoPais.Location = new Point(371, 110);
            btnInfoPais.Name = "btnInfoPais";
            btnInfoPais.Size = new Size(100, 35);
            btnInfoPais.TabIndex = 4;
            btnInfoPais.Text = "Info País";
            btnInfoPais.UseVisualStyleBackColor = false;
            btnInfoPais.Click += btnInfoPais_Click;
            // 
            // pictureBoxCiudad
            // 
            pictureBoxCiudad.Location = new Point(16, 154);
            pictureBoxCiudad.Margin = new Padding(4, 5, 4, 5);
            pictureBoxCiudad.Name = "pictureBoxCiudad";
            pictureBoxCiudad.Size = new Size(455, 308);
            pictureBoxCiudad.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCiudad.TabIndex = 5;
            pictureBoxCiudad.TabStop = false;
            // 
            // dataGridViewCiudades
            // 
            dataGridViewCiudades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCiudades.Location = new Point(519, 285);
            dataGridViewCiudades.Margin = new Padding(4, 5, 4, 5);
            dataGridViewCiudades.Name = "dataGridViewCiudades";
            dataGridViewCiudades.RowHeadersWidth = 51;
            dataGridViewCiudades.Size = new Size(1111, 231);
            dataGridViewCiudades.TabIndex = 6;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.BackColor = SystemColors.ActiveCaption;
            lblCiudad.Location = new Point(94, 30);
            lblCiudad.Margin = new Padding(4, 0, 4, 0);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(153, 20);
            lblCiudad.TabIndex = 0;
            lblCiudad.Text = "Nombre de la ciudad:";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(73, 51);
            txtCiudad.Margin = new Padding(4, 5, 4, 5);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(199, 27);
            txtCiudad.TabIndex = 1;
            // 
            // dataGridViewPais
            // 
            dataGridViewPais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPais.Location = new Point(519, 44);
            dataGridViewPais.Name = "dataGridViewPais";
            dataGridViewPais.RowHeadersWidth = 51;
            dataGridViewPais.Size = new Size(1111, 217);
            dataGridViewPais.TabIndex = 7;
            dataGridViewPais.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1688, 738);
            Controls.Add(dataGridViewPais);
            Controls.Add(lblCiudad);
            Controls.Add(txtCiudad);
            Controls.Add(btnLimpiar);
            Controls.Add(btnInfoPais);
            Controls.Add(dataGridViewCiudades);
            Controls.Add(pictureBoxCiudad);
            Controls.Add(btnBuscar);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Clima e informacion de paises";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCiudad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCiudades).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPais).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
