namespace Check_Dublicate
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _openDialog= new OpenFileDialog() ;
            _showFileDialog= new Button() ;
            _filePath= new TextBox() ;
            panel1= new Panel() ;
            panel2= new Panel() ;
            panel7= new Panel() ;
            _log= new RichTextBox() ;
            _getUnicFile= new Button() ;
            panel4= new Panel() ;
            _countLinesFile= new Label() ;
            panel6= new Panel() ;
            _queryTextBox= new RichTextBox() ;
            _queryGetFile= new Button() ;
            _saveDialogQuery= new SaveFileDialog() ;
            _saveDialogUnic= new SaveFileDialog() ;
            tabControl1= new TabControl() ;
            tabPage1= new TabPage() ;
            tabPage2= new TabPage() ;
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // _openDialog
            // 
            _openDialog.Filter= "TXT files|*.txt|Все файлы|*.*" ;
            _openDialog.FileOk+= openDialogFileOk ;
            // 
            // _showFileDialog
            // 
            _showFileDialog.Dock= DockStyle.Right ;
            _showFileDialog.Location= new Point( 530, 0 ) ;
            _showFileDialog.Name= "_showFileDialog" ;
            _showFileDialog.Size= new Size( 39, 43 ) ;
            _showFileDialog.TabIndex= 0 ;
            _showFileDialog.Text= "..." ;
            _showFileDialog.UseVisualStyleBackColor= true ;
            _showFileDialog.Click+= showOpenDialogClick ;
            // 
            // _filePath
            // 
            _filePath.BorderStyle= BorderStyle.None ;
            _filePath.Dock= DockStyle.Fill ;
            _filePath.Location= new Point( 0, 0 ) ;
            _filePath.Multiline= true ;
            _filePath.Name= "_filePath" ;
            _filePath.PlaceholderText= "Путь к файлу" ;
            _filePath.ReadOnly= true ;
            _filePath.Size= new Size( 530, 43 ) ;
            _filePath.TabIndex= 1 ;
            _filePath.WordWrap= false ;
            _filePath.Click+= filePathClick ;
            // 
            // panel1
            // 
            panel1.Controls.Add( _filePath );
            panel1.Controls.Add( _showFileDialog );
            panel1.Dock= DockStyle.Top ;
            panel1.Location= new Point( 0, 0 ) ;
            panel1.Name= "panel1" ;
            panel1.Size= new Size( 569, 43 ) ;
            panel1.TabIndex= 2 ;
            // 
            // panel2
            // 
            panel2.Controls.Add( panel7 );
            panel2.Controls.Add( panel4 );
            panel2.Controls.Add( panel1 );
            panel2.Dock= DockStyle.Fill ;
            panel2.Location= new Point( 3, 3 ) ;
            panel2.Name= "panel2" ;
            panel2.Size= new Size( 569, 405 ) ;
            panel2.TabIndex= 3 ;
            // 
            // panel7
            // 
            panel7.Controls.Add( _log );
            panel7.Controls.Add( _getUnicFile );
            panel7.Dock= DockStyle.Fill ;
            panel7.Location= new Point( 0, 81 ) ;
            panel7.Name= "panel7" ;
            panel7.Size= new Size( 569, 324 ) ;
            panel7.TabIndex= 6 ;
            // 
            // _log
            // 
            _log.Dock= DockStyle.Fill ;
            _log.Location= new Point( 0, 0 ) ;
            _log.Name= "_log" ;
            _log.ReadOnly= true ;
            _log.Size= new Size( 569, 276 ) ;
            _log.TabIndex= 2 ;
            _log.Text= "" ;
            // 
            // _getUnicFile
            // 
            _getUnicFile.Dock= DockStyle.Bottom ;
            _getUnicFile.Enabled= false ;
            _getUnicFile.Location= new Point( 0, 276 ) ;
            _getUnicFile.Name= "_getUnicFile" ;
            _getUnicFile.Size= new Size( 569, 48 ) ;
            _getUnicFile.TabIndex= 1 ;
            _getUnicFile.Text= "Обработать и получить файл с уникальными" ;
            _getUnicFile.UseVisualStyleBackColor= true ;
            _getUnicFile.Click+= getUnicFileClick ;
            // 
            // panel4
            // 
            panel4.Controls.Add( _countLinesFile );
            panel4.Dock= DockStyle.Top ;
            panel4.Location= new Point( 0, 43 ) ;
            panel4.Name= "panel4" ;
            panel4.Size= new Size( 569, 38 ) ;
            panel4.TabIndex= 3 ;
            // 
            // _countLinesFile
            // 
            _countLinesFile.Dock= DockStyle.Top ;
            _countLinesFile.Location= new Point( 0, 0 ) ;
            _countLinesFile.Margin= new Padding( 3 ) ;
            _countLinesFile.Name= "_countLinesFile" ;
            _countLinesFile.Size= new Size( 569, 25 ) ;
            _countLinesFile.TabIndex= 0 ;
            _countLinesFile.Text= "Строк в файле: 0" ;
            // 
            // panel6
            // 
            panel6.Controls.Add( _queryTextBox );
            panel6.Controls.Add( _queryGetFile );
            panel6.Dock= DockStyle.Fill ;
            panel6.Location= new Point( 3, 3 ) ;
            panel6.Name= "panel6" ;
            panel6.Size= new Size( 569, 405 ) ;
            panel6.TabIndex= 5 ;
            // 
            // _queryTextBox
            // 
            _queryTextBox.Dock= DockStyle.Fill ;
            _queryTextBox.Location= new Point( 0, 0 ) ;
            _queryTextBox.Name= "_queryTextBox" ;
            _queryTextBox.Size= new Size( 569, 367 ) ;
            _queryTextBox.TabIndex= 1 ;
            _queryTextBox.Text= "SELECT line FROM data" ;
            // 
            // _queryGetFile
            // 
            _queryGetFile.Dock= DockStyle.Bottom ;
            _queryGetFile.Location= new Point( 0, 367 ) ;
            _queryGetFile.Name= "_queryGetFile" ;
            _queryGetFile.Size= new Size( 569, 38 ) ;
            _queryGetFile.TabIndex= 0 ;
            _queryGetFile.Text= "Файл по запросу" ;
            _queryGetFile.UseVisualStyleBackColor= true ;
            _queryGetFile.Click+= queryGetFileClick ;
            // 
            // _saveDialogQuery
            // 
            _saveDialogQuery.Filter= "TXT files|*.txt|Все файлы|*.*" ;
            _saveDialogQuery.FileOk+= saveQueryDialogFileOk ;
            // 
            // _saveDialogUnic
            // 
            _saveDialogUnic.Filter= "TXT files|*.txt|Все файлы|*.*" ;
            _saveDialogUnic.FileOk+= saveUnicDialogFileOk ;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add( tabPage1 );
            tabControl1.Controls.Add( tabPage2 );
            tabControl1.Dock= DockStyle.Fill ;
            tabControl1.Location= new Point( 0, 0 ) ;
            tabControl1.Name= "tabControl1" ;
            tabControl1.SelectedIndex= 0 ;
            tabControl1.Size= new Size( 583, 449 ) ;
            tabControl1.TabIndex= 4 ;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add( panel2 );
            tabPage1.Location= new Point( 4, 34 ) ;
            tabPage1.Name= "tabPage1" ;
            tabPage1.Padding= new Padding( 3 ) ;
            tabPage1.Size= new Size( 575, 411 ) ;
            tabPage1.TabIndex= 0 ;
            tabPage1.Text= "Файл" ;
            tabPage1.UseVisualStyleBackColor= true ;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add( panel6 );
            tabPage2.Location= new Point( 4, 34 ) ;
            tabPage2.Name= "tabPage2" ;
            tabPage2.Padding= new Padding( 3 ) ;
            tabPage2.Size= new Size( 575, 411 ) ;
            tabPage2.TabIndex= 1 ;
            tabPage2.Text= "Запрос" ;
            tabPage2.UseVisualStyleBackColor= true ;
            // 
            // Main
            // 
            AutoScaleDimensions= new SizeF( 10F, 25F ) ;
            AutoScaleMode= AutoScaleMode.Font ;
            ClientSize= new Size( 583, 449 ) ;
            Controls.Add( tabControl1 );
            Name= "Main" ;
            Text= "Поиск дубликатов" ;
            FormClosing+= Main_FormClosing ;
            panel1.ResumeLayout( false );
            panel1.PerformLayout();
            panel2.ResumeLayout( false );
            panel7.ResumeLayout( false );
            panel4.ResumeLayout( false );
            panel6.ResumeLayout( false );
            tabControl1.ResumeLayout( false );
            tabPage1.ResumeLayout( false );
            tabPage2.ResumeLayout( false );
            ResumeLayout( false );
        }

        #endregion

        private OpenFileDialog _openDialog;
        private Button _showFileDialog;
        private TextBox _filePath;
        private Panel panel1;
        private Panel panel2;
        private Button _getUnicFile;
        private Button _queryGetFile;
        private Panel panel4;
        private Label _countLinesFile;
        private Panel panel7;
        private Panel panel6;
        private RichTextBox _queryTextBox;
        private RichTextBox _log;
        private SaveFileDialog _saveDialogQuery;
        private SaveFileDialog _saveDialogUnic;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}