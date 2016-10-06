namespace correctorTextGrid_01
{
    partial class corrector
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(corrector));
            this.txt_textGrid = new System.Windows.Forms.TextBox();
            this.btn_fileTextGrid = new System.Windows.Forms.Button();
            this.btn_convert = new System.Windows.Forms.Button();
            this.btn_fileDict = new System.Windows.Forms.Button();
            this.txt_dict = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileTextGrid = new System.Windows.Forms.OpenFileDialog();
            this.openFileDict = new System.Windows.Forms.OpenFileDialog();
            this.saveTextGrid = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_wordRow = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_openHandCorrectedTextGrid = new System.Windows.Forms.Button();
            this.btn_openUncorrectedTextGrid = new System.Windows.Forms.Button();
            this.btn_RMSCalc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TextGridUncorrected = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_textGridHandCorrected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_add_sylls = new System.Windows.Forms.Button();
            this.btn_file_sylls_dict = new System.Windows.Forms.Button();
            this.btn_file_syll_textgrid = new System.Windows.Forms.Button();
            this.txt_syll_dict = new System.Windows.Forms.TextBox();
            this.txt_syll_textgrid = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_generarNasalidad = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_input_nasalidad = new System.Windows.Forms.TextBox();
            this.btn_abrirNasalidad = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_limpiar_nasal_palabras = new System.Windows.Forms.Button();
            this.btn_copiar_nasal_palabras = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_abrir_textgrid_nasal_palabras = new System.Windows.Forms.Button();
            this.txt_input_textGrid_nasal_palabra = new System.Windows.Forms.TextBox();
            this.btn_procesar_nasal_palabras = new System.Windows.Forms.Button();
            this.txt_output_nasal_palabra = new System.Windows.Forms.TextBox();
            this.txt_input_nasal_palabra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_textGrid
            // 
            this.txt_textGrid.Location = new System.Drawing.Point(9, 102);
            this.txt_textGrid.Name = "txt_textGrid";
            this.txt_textGrid.Size = new System.Drawing.Size(578, 20);
            this.txt_textGrid.TabIndex = 0;
            this.txt_textGrid.TextChanged += new System.EventHandler(this.txt_textGrid_TextChanged);
            // 
            // btn_fileTextGrid
            // 
            this.btn_fileTextGrid.Location = new System.Drawing.Point(600, 96);
            this.btn_fileTextGrid.Name = "btn_fileTextGrid";
            this.btn_fileTextGrid.Size = new System.Drawing.Size(100, 30);
            this.btn_fileTextGrid.TabIndex = 1;
            this.btn_fileTextGrid.Text = "Abrir";
            this.btn_fileTextGrid.UseVisualStyleBackColor = true;
            this.btn_fileTextGrid.Click += new System.EventHandler(this.btn_fileTextGrid_Click);
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(9, 187);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(105, 39);
            this.btn_convert.TabIndex = 2;
            this.btn_convert.Text = "Convertir";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // btn_fileDict
            // 
            this.btn_fileDict.Location = new System.Drawing.Point(600, 146);
            this.btn_fileDict.Name = "btn_fileDict";
            this.btn_fileDict.Size = new System.Drawing.Size(100, 30);
            this.btn_fileDict.TabIndex = 4;
            this.btn_fileDict.Text = "Abrir";
            this.btn_fileDict.UseVisualStyleBackColor = true;
            this.btn_fileDict.Click += new System.EventHandler(this.btn_fileDict_Click);
            // 
            // txt_dict
            // 
            this.txt_dict.Location = new System.Drawing.Point(9, 152);
            this.txt_dict.Name = "txt_dict";
            this.txt_dict.Size = new System.Drawing.Size(578, 20);
            this.txt_dict.TabIndex = 3;
            this.txt_dict.TextChanged += new System.EventHandler(this.txt_dict_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TextGrid";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Diccionario de tres columnas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // openFileTextGrid
            // 
            this.openFileTextGrid.FileName = "openFileDialog1";
            // 
            // openFileDict
            // 
            this.openFileDict.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(15, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(714, 271);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_textGrid);
            this.tabPage1.Controls.Add(this.btn_fileTextGrid);
            this.tabPage1.Controls.Add(this.btn_convert);
            this.tabPage1.Controls.Add(this.btn_fileDict);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_dict);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(706, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cambiar Arpabet en un TextGrid";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.MaximumSize = new System.Drawing.Size(578, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(569, 52);
            this.label4.TabIndex = 9;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txt_wordRow);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btn_openHandCorrectedTextGrid);
            this.tabPage2.Controls.Add(this.btn_openUncorrectedTextGrid);
            this.tabPage2.Controls.Add(this.btn_RMSCalc);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txt_TextGridUncorrected);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txt_textGridHandCorrected);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(706, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Calcular RMS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "(FaveAlign=2, EasyAlign=3)";
            // 
            // txt_wordRow
            // 
            this.txt_wordRow.Location = new System.Drawing.Point(540, 182);
            this.txt_wordRow.Name = "txt_wordRow";
            this.txt_wordRow.Size = new System.Drawing.Size(43, 20);
            this.txt_wordRow.TabIndex = 19;
            this.txt_wordRow.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(387, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Fila donde están las palabras:";
            // 
            // btn_openHandCorrectedTextGrid
            // 
            this.btn_openHandCorrectedTextGrid.Location = new System.Drawing.Point(600, 140);
            this.btn_openHandCorrectedTextGrid.Name = "btn_openHandCorrectedTextGrid";
            this.btn_openHandCorrectedTextGrid.Size = new System.Drawing.Size(100, 30);
            this.btn_openHandCorrectedTextGrid.TabIndex = 17;
            this.btn_openHandCorrectedTextGrid.Text = "Abrir";
            this.btn_openHandCorrectedTextGrid.UseVisualStyleBackColor = true;
            this.btn_openHandCorrectedTextGrid.Click += new System.EventHandler(this.btn_openHandCorrectedTextGrid_Click);
            // 
            // btn_openUncorrectedTextGrid
            // 
            this.btn_openUncorrectedTextGrid.Location = new System.Drawing.Point(600, 90);
            this.btn_openUncorrectedTextGrid.Name = "btn_openUncorrectedTextGrid";
            this.btn_openUncorrectedTextGrid.Size = new System.Drawing.Size(100, 30);
            this.btn_openUncorrectedTextGrid.TabIndex = 16;
            this.btn_openUncorrectedTextGrid.Text = "Abrir";
            this.btn_openUncorrectedTextGrid.UseVisualStyleBackColor = true;
            this.btn_openUncorrectedTextGrid.Click += new System.EventHandler(this.btn_openUncorrectedTextGrid_Click);
            // 
            // btn_RMSCalc
            // 
            this.btn_RMSCalc.Location = new System.Drawing.Point(9, 189);
            this.btn_RMSCalc.Name = "btn_RMSCalc";
            this.btn_RMSCalc.Size = new System.Drawing.Size(207, 35);
            this.btn_RMSCalc.TabIndex = 15;
            this.btn_RMSCalc.Text = "Calcular diferencias entre los datagrids";
            this.btn_RMSCalc.UseVisualStyleBackColor = true;
            this.btn_RMSCalc.Click += new System.EventHandler(this.btn_RMSCalc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "TextGrid generado automáticamente, sin corregir";
            // 
            // txt_TextGridUncorrected
            // 
            this.txt_TextGridUncorrected.Location = new System.Drawing.Point(9, 96);
            this.txt_TextGridUncorrected.Name = "txt_TextGridUncorrected";
            this.txt_TextGridUncorrected.Size = new System.Drawing.Size(574, 20);
            this.txt_TextGridUncorrected.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "TextGrid corregido a mano";
            // 
            // txt_textGridHandCorrected
            // 
            this.txt_textGridHandCorrected.Location = new System.Drawing.Point(9, 146);
            this.txt_textGridHandCorrected.Name = "txt_textGridHandCorrected";
            this.txt_textGridHandCorrected.Size = new System.Drawing.Size(574, 20);
            this.txt_textGridHandCorrected.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.MaximumSize = new System.Drawing.Size(578, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(575, 52);
            this.label3.TabIndex = 10;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.btn_add_sylls);
            this.tabPage3.Controls.Add(this.btn_file_sylls_dict);
            this.tabPage3.Controls.Add(this.btn_file_syll_textgrid);
            this.tabPage3.Controls.Add(this.txt_syll_dict);
            this.tabPage3.Controls.Add(this.txt_syll_textgrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(706, 245);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generar tier de sílabas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Diccionario de tres columnas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "TextGrid";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 13);
            this.label10.MaximumSize = new System.Drawing.Size(578, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(576, 65);
            this.label10.TabIndex = 10;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // btn_add_sylls
            // 
            this.btn_add_sylls.Location = new System.Drawing.Point(18, 197);
            this.btn_add_sylls.Name = "btn_add_sylls";
            this.btn_add_sylls.Size = new System.Drawing.Size(80, 39);
            this.btn_add_sylls.TabIndex = 4;
            this.btn_add_sylls.Text = "Convertir";
            this.btn_add_sylls.UseVisualStyleBackColor = true;
            this.btn_add_sylls.Click += new System.EventHandler(this.btn_add_sylls_Click);
            // 
            // btn_file_sylls_dict
            // 
            this.btn_file_sylls_dict.Location = new System.Drawing.Point(514, 160);
            this.btn_file_sylls_dict.Name = "btn_file_sylls_dict";
            this.btn_file_sylls_dict.Size = new System.Drawing.Size(75, 23);
            this.btn_file_sylls_dict.TabIndex = 3;
            this.btn_file_sylls_dict.Text = "Abrir";
            this.btn_file_sylls_dict.UseVisualStyleBackColor = true;
            this.btn_file_sylls_dict.Click += new System.EventHandler(this.btn_file_sylls_dict_Click);
            // 
            // btn_file_syll_textgrid
            // 
            this.btn_file_syll_textgrid.Location = new System.Drawing.Point(517, 107);
            this.btn_file_syll_textgrid.Name = "btn_file_syll_textgrid";
            this.btn_file_syll_textgrid.Size = new System.Drawing.Size(75, 23);
            this.btn_file_syll_textgrid.TabIndex = 2;
            this.btn_file_syll_textgrid.Text = "Abrir";
            this.btn_file_syll_textgrid.UseVisualStyleBackColor = true;
            this.btn_file_syll_textgrid.Click += new System.EventHandler(this.btn_file_syll_textgrid_Click);
            // 
            // txt_syll_dict
            // 
            this.txt_syll_dict.Location = new System.Drawing.Point(16, 160);
            this.txt_syll_dict.Name = "txt_syll_dict";
            this.txt_syll_dict.Size = new System.Drawing.Size(492, 20);
            this.txt_syll_dict.TabIndex = 1;
            // 
            // txt_syll_textgrid
            // 
            this.txt_syll_textgrid.Location = new System.Drawing.Point(19, 107);
            this.txt_syll_textgrid.Name = "txt_syll_textgrid";
            this.txt_syll_textgrid.Size = new System.Drawing.Size(492, 20);
            this.txt_syll_textgrid.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btn_generarNasalidad);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.txt_input_nasalidad);
            this.tabPage4.Controls.Add(this.btn_abrirNasalidad);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(706, 245);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Generar TextGrid Nasalidad";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_generarNasalidad
            // 
            this.btn_generarNasalidad.Location = new System.Drawing.Point(9, 187);
            this.btn_generarNasalidad.Name = "btn_generarNasalidad";
            this.btn_generarNasalidad.Size = new System.Drawing.Size(80, 39);
            this.btn_generarNasalidad.TabIndex = 12;
            this.btn_generarNasalidad.Text = "Convertir";
            this.btn_generarNasalidad.UseVisualStyleBackColor = true;
            this.btn_generarNasalidad.Click += new System.EventHandler(this.btn_generarNasalidad_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 17);
            this.label14.MaximumSize = new System.Drawing.Size(578, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(298, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "(BETA: EXTRAER VOCALES NASALES DE UN DATAGRID)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "TextGrid";
            // 
            // txt_input_nasalidad
            // 
            this.txt_input_nasalidad.Location = new System.Drawing.Point(9, 118);
            this.txt_input_nasalidad.Name = "txt_input_nasalidad";
            this.txt_input_nasalidad.Size = new System.Drawing.Size(578, 20);
            this.txt_input_nasalidad.TabIndex = 6;
            // 
            // btn_abrirNasalidad
            // 
            this.btn_abrirNasalidad.Location = new System.Drawing.Point(600, 112);
            this.btn_abrirNasalidad.Name = "btn_abrirNasalidad";
            this.btn_abrirNasalidad.Size = new System.Drawing.Size(100, 30);
            this.btn_abrirNasalidad.TabIndex = 7;
            this.btn_abrirNasalidad.Text = "Abrir";
            this.btn_abrirNasalidad.UseVisualStyleBackColor = true;
            this.btn_abrirNasalidad.Click += new System.EventHandler(this.btn_abrirArchivoNasalidad_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.btn_limpiar_nasal_palabras);
            this.tabPage5.Controls.Add(this.btn_copiar_nasal_palabras);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.btn_abrir_textgrid_nasal_palabras);
            this.tabPage5.Controls.Add(this.txt_input_textGrid_nasal_palabra);
            this.tabPage5.Controls.Add(this.btn_procesar_nasal_palabras);
            this.tabPage5.Controls.Add(this.txt_output_nasal_palabra);
            this.tabPage5.Controls.Add(this.txt_input_nasal_palabra);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(706, 245);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Enlazar nasalidad con palabras";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_limpiar_nasal_palabras
            // 
            this.btn_limpiar_nasal_palabras.Location = new System.Drawing.Point(259, 202);
            this.btn_limpiar_nasal_palabras.Name = "btn_limpiar_nasal_palabras";
            this.btn_limpiar_nasal_palabras.Size = new System.Drawing.Size(93, 27);
            this.btn_limpiar_nasal_palabras.TabIndex = 13;
            this.btn_limpiar_nasal_palabras.Text = "Limpiar";
            this.btn_limpiar_nasal_palabras.UseVisualStyleBackColor = true;
            this.btn_limpiar_nasal_palabras.Click += new System.EventHandler(this.btn_limpiar_nasal_palabras_Click);
            // 
            // btn_copiar_nasal_palabras
            // 
            this.btn_copiar_nasal_palabras.Location = new System.Drawing.Point(124, 202);
            this.btn_copiar_nasal_palabras.Name = "btn_copiar_nasal_palabras";
            this.btn_copiar_nasal_palabras.Size = new System.Drawing.Size(113, 27);
            this.btn_copiar_nasal_palabras.TabIndex = 12;
            this.btn_copiar_nasal_palabras.Text = "Copiar resultados";
            this.btn_copiar_nasal_palabras.UseVisualStyleBackColor = true;
            this.btn_copiar_nasal_palabras.Click += new System.EventHandler(this.btn_copiar_nasal_palabras_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(256, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Salida: vocal / palabra";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Entrada: vocal / tiempo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "TextGrid con vocales nasales";
            // 
            // btn_abrir_textgrid_nasal_palabras
            // 
            this.btn_abrir_textgrid_nasal_palabras.Location = new System.Drawing.Point(483, 25);
            this.btn_abrir_textgrid_nasal_palabras.Name = "btn_abrir_textgrid_nasal_palabras";
            this.btn_abrir_textgrid_nasal_palabras.Size = new System.Drawing.Size(100, 30);
            this.btn_abrir_textgrid_nasal_palabras.TabIndex = 8;
            this.btn_abrir_textgrid_nasal_palabras.Text = "Abrir";
            this.btn_abrir_textgrid_nasal_palabras.UseVisualStyleBackColor = true;
            this.btn_abrir_textgrid_nasal_palabras.Click += new System.EventHandler(this.btn_abrir_textgrid_nasal_palabras_Click);
            // 
            // txt_input_textGrid_nasal_palabra
            // 
            this.txt_input_textGrid_nasal_palabra.Location = new System.Drawing.Point(24, 31);
            this.txt_input_textGrid_nasal_palabra.Name = "txt_input_textGrid_nasal_palabra";
            this.txt_input_textGrid_nasal_palabra.Size = new System.Drawing.Size(435, 20);
            this.txt_input_textGrid_nasal_palabra.TabIndex = 3;
            // 
            // btn_procesar_nasal_palabras
            // 
            this.btn_procesar_nasal_palabras.Location = new System.Drawing.Point(24, 202);
            this.btn_procesar_nasal_palabras.Name = "btn_procesar_nasal_palabras";
            this.btn_procesar_nasal_palabras.Size = new System.Drawing.Size(75, 27);
            this.btn_procesar_nasal_palabras.TabIndex = 2;
            this.btn_procesar_nasal_palabras.Text = "Procesar";
            this.btn_procesar_nasal_palabras.UseVisualStyleBackColor = true;
            this.btn_procesar_nasal_palabras.Click += new System.EventHandler(this.btn_procesar_nasal_palabras_Click);
            // 
            // txt_output_nasal_palabra
            // 
            this.txt_output_nasal_palabra.Location = new System.Drawing.Point(259, 94);
            this.txt_output_nasal_palabra.Multiline = true;
            this.txt_output_nasal_palabra.Name = "txt_output_nasal_palabra";
            this.txt_output_nasal_palabra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output_nasal_palabra.Size = new System.Drawing.Size(200, 93);
            this.txt_output_nasal_palabra.TabIndex = 1;
            // 
            // txt_input_nasal_palabra
            // 
            this.txt_input_nasal_palabra.Location = new System.Drawing.Point(24, 94);
            this.txt_input_nasal_palabra.Multiline = true;
            this.txt_input_nasal_palabra.Name = "txt_input_nasal_palabra";
            this.txt_input_nasal_palabra.Size = new System.Drawing.Size(213, 93);
            this.txt_input_nasal_palabra.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "rcoto@email.arizona.edu. Versión: β07 20160617";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(483, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 37);
            this.label18.TabIndex = 14;
            this.label18.Text = "(BETA: Incorporar palabras a un TextGrid de vocales nasales)";
            // 
            // corrector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 304);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Name = "corrector";
            this.Text = "Manipular TextGrids";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_textGrid;
        private System.Windows.Forms.Button btn_fileTextGrid;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Button btn_fileDict;
        private System.Windows.Forms.TextBox txt_dict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileTextGrid;
        private System.Windows.Forms.OpenFileDialog openFileDict;
        private System.Windows.Forms.SaveFileDialog saveTextGrid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_openHandCorrectedTextGrid;
        private System.Windows.Forms.Button btn_openUncorrectedTextGrid;
        private System.Windows.Forms.Button btn_RMSCalc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TextGridUncorrected;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_textGridHandCorrected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_wordRow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_file_sylls_dict;
        private System.Windows.Forms.Button btn_file_syll_textgrid;
        private System.Windows.Forms.TextBox txt_syll_dict;
        private System.Windows.Forms.TextBox txt_syll_textgrid;
        private System.Windows.Forms.Button btn_add_sylls;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btn_generarNasalidad;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_input_nasalidad;
        private System.Windows.Forms.Button btn_abrirNasalidad;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_abrir_textgrid_nasal_palabras;
        private System.Windows.Forms.TextBox txt_input_textGrid_nasal_palabra;
        private System.Windows.Forms.Button btn_procesar_nasal_palabras;
        private System.Windows.Forms.TextBox txt_output_nasal_palabra;
        private System.Windows.Forms.TextBox txt_input_nasal_palabra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_copiar_nasal_palabras;
        private System.Windows.Forms.Button btn_limpiar_nasal_palabras;
        private System.Windows.Forms.Label label18;
    }
}

