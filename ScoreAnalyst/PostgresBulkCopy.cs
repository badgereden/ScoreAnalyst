using System;
using System.Data;
using Npgsql;
using System.Threading;

namespace ScoreAnalyst
{

    public sealed class PostgresBulkCopy:IDisposable
    {
        public int NotifyAfter { get; set; }
        public string DestinationTableName { get; set; }
        public event NpgsqlRowsCopiedEventHandler RowsCopied;
        private bool disposed = false;
        private NpgsqlConnection connection;
        public PostgresBulkCopy(string cnString)
        {
            connection = new NpgsqlConnection(cnString);
        }

        public int WriteToServer(DataTable dt)
        {
            string[] sql = dt.ToSQLStringArray(this.DestinationTableName);
            return batchExecuteSQL(sql);

        }

        public int WriteToServer(string fileName, string strFields,string destTableName)
        {
            ExcelReader ner = new ExcelReader(fileName);
            string[] sql = ner.GetFirstSheetData(strFields, destTableName);

            return batchExecuteSQL(sql);
        }

        private int batchExecuteSQL(string[] sql)
        {
            int buffer = 0;
            connection.Open();
            NpgsqlTransaction trans = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = trans;
            try
            {
                for (int i = 0; i < sql.Length; i++)
                {
                    cmd.CommandText = sql[i];
                    cmd.ExecuteNonQuery();
                    buffer++;
                    //触发事件
                    if (buffer == NotifyAfter)
                    {
                        if (RowsCopied != null)
                        {
                            RowsCopied(this, new NpgsqlRowsCopiedEventArgs(buffer,sql.Length));
                        }

                        buffer = 0;
                    }
                }

                if (buffer != 0)
                {
                    if (RowsCopied != null)
                    {
                        RowsCopied(this, new NpgsqlRowsCopiedEventArgs(buffer,sql.Length));
                    }
                    buffer = 0;
                }

                //提交事务,只有所有的数据都没有问题才提交事务.
                trans.Commit();
                //异步压缩,分析数据库,确保所得的分析是最佳的.
                ThreadPool.QueueUserWorkItem(new WaitCallback((object o)=>{
                    StaticQueryHelper.ExecuteNonQuery("VACUUM ANALYZE");
                }));


            }
            catch (NpgsqlException)
            {
                trans.Rollback();
                return 0;
            }
            finally
            {
                trans.Dispose();
                cmd.Dispose();
            }

            return sql.Length;
        
        }



        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                RowsCopied = null;
                connection.Dispose();
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~PostgresBulkCopy()
        {
            Dispose(false);
        }
    
    }
    
    public delegate void NpgsqlRowsCopiedEventHandler(object sender, NpgsqlRowsCopiedEventArgs args);
    
    public sealed class NpgsqlRowsCopiedEventArgs : EventArgs
    {
        private int _rowsCopied;
        private int _total;
        public NpgsqlRowsCopiedEventArgs(int rowsCopied,int total)
        {
            _rowsCopied = rowsCopied;
            _total = total;
        }

        public bool Abort { get; set; }

        public int RowsCopied { get { return _rowsCopied; } }
        public int Total { get { return _total; } }
    }



}
