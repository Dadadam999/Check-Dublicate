using System.Data.SQLite;
using System.Text;

namespace Check_Dublicate
{
    public class SqLite
    {
        private string _connectionString;
        private string _dbPath;
        public SqLite( string dbPath )
        {
            _dbPath = dbPath;
            _connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                if( !File.Exists( _dbPath ) )
                    SQLiteConnection.CreateFile( _dbPath );
                
                using( var connection = new SQLiteConnection( _connectionString ) )
                {
                    connection.Open();
                    var checkTableCommand = connection.CreateCommand();
                    checkTableCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='data'";
                    var tableName = checkTableCommand.ExecuteScalar();

                    if( tableName == null )
                    {
                        var createTableCommand = connection.CreateCommand();
                        createTableCommand.CommandText = "CREATE TABLE data (id INTEGER PRIMARY KEY, line TEXT)";
                        createTableCommand.ExecuteNonQuery();
                    }
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Ошибка при создании базы данных:{ex.Message}" );
            }
        }

        public void CreateTable( string tableName, string[] columnNames, string[] columnTypes )
        {
            if( columnNames.Length != columnTypes.Length )
                throw new ArgumentException( "The number of column names must match the number of column types." );

            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({GetCreateTableColumns( columnNames, columnTypes )})";
                command.ExecuteNonQuery();
            }
        }

        public void Insert( string tableName, string[] columnNames, object[] values )
        {
            if( columnNames.Length != values.Length )
                throw new ArgumentException( "The number of column names must match the number of values." );

            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {tableName} ({string.Join( ", ", columnNames )}) VALUES ({GetInsertValues( values )})";
                command.ExecuteNonQuery();
            }
        }

        public List<string> ExecuteQuery( string query )
        {
            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;

                using( var reader = command.ExecuteReader() )
                {
                    List<string> resultList = new List<string>();

                    while( reader.Read() )
                    {
                        StringBuilder result = new StringBuilder();

                        for( int i = 0; i < reader.FieldCount; i++ )
                        {
                            string value = reader.IsDBNull( i ) ? "NULL" : reader.GetString( i );
                            result.Append( value );

                            if( i < reader.FieldCount - 1 )
                                result.Append( ";" );
                        }

                        resultList.Add( result.ToString() );
                    }

                    return resultList;
                }
            }
        }

        private string GetCreateTableColumns( string[] columnNames, string[] columnTypes )
        {
            var columns = new string[columnNames.Length];

            for( int i = 0; i < columnNames.Length; i++ )
                columns[i] = $"{columnNames[i]} {columnTypes[i]}";

            return string.Join( ", ", columns );
        }

        private string GetInsertValues( object[] values )
        {
            var formattedValues = new string[values.Length];

            for( int i = 0; i < values.Length; i++ )
            {
                if( values[i] == null )
                    formattedValues[i] = "NULL";

                if( values[i] is string || values[i] is char )
                    formattedValues[i] = $"'{values[i]}'";

                formattedValues[i] = values[i].ToString();
            }

            return string.Join( ", ", formattedValues );
        }

        public void InsertDataWithoutDuplicates( string data )
        {
            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                connection.Open();
                var checkDuplicateCommand = connection.CreateCommand();
                checkDuplicateCommand.CommandText = "SELECT COUNT(*) FROM data WHERE line = @data";
                checkDuplicateCommand.Parameters.AddWithValue( "@data", data );
                int duplicateCount = Convert.ToInt32( checkDuplicateCommand.ExecuteScalar() );

                if( duplicateCount == 0 )
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT OR IGNORE INTO data (line) VALUES (@data)";
                    insertCommand.Parameters.AddWithValue( "@data", data );
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
        public async Task<bool> CheckDuplicateAsync( string lineValue )
        {
            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM data WHERE line = @lineValue";
                command.Parameters.AddWithValue( "@lineValue", lineValue );
                var result = await command.ExecuteScalarAsync();
                int count = Convert.ToInt32( result );
                return count > 0;
            }
        }

        public bool CheckDuplicate( string lineValue )
        {
            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM data WHERE line = @lineValue";
                command.Parameters.AddWithValue( "@lineValue", lineValue );
                var result = command.ExecuteScalar();
                int count = Convert.ToInt32( result );
                return count > 0;
            }
        }

        public async Task InsertDataWithoutDuplicatesAsync( string data )
        {
            using( var connection = new SQLiteConnection( _connectionString ) )
            {
                await connection.OpenAsync();
                var checkDuplicateCommand = connection.CreateCommand();
                checkDuplicateCommand.CommandText = "SELECT COUNT(*) FROM data WHERE line = @data";
                checkDuplicateCommand.Parameters.AddWithValue( "@data", data );
                int duplicateCount = Convert.ToInt32( await checkDuplicateCommand.ExecuteScalarAsync() );

                if( duplicateCount == 0 )
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT OR IGNORE INTO data (line) VALUES (@data)";
                    insertCommand.Parameters.AddWithValue( "@data", data );
                    await insertCommand.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
