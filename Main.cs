using System.Text.RegularExpressions;

namespace Check_Dublicate
{
    public partial class Main : Form
    {
        private List<string> _lines { get; set; } = new List<string>();
        public SqLite DataBase { get; set; }
        private Thread processThread { get; set; }

        public Main()
        {
            InitializeComponent();
            DataBase = new SqLite( "database.db" );
            processThread = new Thread( ProcessFile );
        }

        private void Main_FormClosing( object sender, FormClosingEventArgs e ) => processThread.Abort();

        private void showOpenDialogClick( object sender, EventArgs e ) => _openDialog.ShowDialog();

        private void filePathClick( object sender, EventArgs e ) => _openDialog.ShowDialog();

        private void queryGetFileClick( object sender, EventArgs e ) => _saveDialogQuery.ShowDialog();

        private void getUnicFileClick( object sender, EventArgs e ) => _saveDialogUnic.ShowDialog();

        private void openDialogFileOk( object sender, System.ComponentModel.CancelEventArgs e )
        {
            try
            {
                _lines.AddRange( File.ReadAllLines( _openDialog.FileName ) );
                _filePath.Text = _openDialog.FileName;
                _countLinesFile.Text = Regex.Replace( _countLinesFile.Text, @": [0-9]+", $": {_lines.Count}" );
                _getUnicFile.Enabled = true;
                _log.AppendText( $"���� ��������!{Environment.NewLine}" );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"��� ��������� ����� ��������� ������: {ex.Message}" );
            }
        }

        private void saveQueryDialogFileOk( object sender, System.ComponentModel.CancelEventArgs e )
        {
            try
            {
                List<string> result = DataBase.ExecuteQuery( _queryTextBox.Text );
                File.WriteAllLines( _saveDialogQuery.FileName, result );
                MessageBox.Show( "���� �������." );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"��� ���������� ����� � ��������� ������� ��������� ������: {ex.Message}" );
            }
        }

        private void saveUnicDialogFileOk( object sender, System.ComponentModel.CancelEventArgs e )
        {
            _getUnicFile.Enabled = false;
            _log.AppendText( $"������ ������ � �����...{Environment.NewLine}" );
            _log.AppendText( $"����������: 0 �� {_lines.Count}" );
            processThread.Start();
        }

        private void ProcessFile()
        {
            List<string> result = new List<string>();
            int counter = 0;

            Parallel.ForEach( _lines, line =>
            {
                bool hasDuplicates = DataBase.CheckDuplicate( line );

                if( !hasDuplicates )
                {
                    lock( result )
                    {
                        result.Add( line );
                    }

                    lock( DataBase )
                    {
                        DataBase.InsertDataWithoutDuplicates( line );
                    }
                }

                Invoke( () => { UpdateLastLineLog( $"����������: {Interlocked.Increment( ref counter )} �� {_lines.Count}" ); } );
            } );

            File.WriteAllLines( _saveDialogUnic.FileName, result );

            Invoke( () =>
            {
                _log.AppendText( Environment.NewLine );
                _log.AppendText( $"���� �������!{Environment.NewLine}" );
                _getUnicFile.Enabled = true;
            } );
        }

        private void UpdateLastLineLog( string text )
        {
            _log.SelectionStart = _log.GetFirstCharIndexFromLine( _log.Lines.Length - 1 );
            _log.SelectionLength = _log.Lines[_log.Lines.Length - 1].Length;
            _log.SelectedText = text;
        }
    }
}