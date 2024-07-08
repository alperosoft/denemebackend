using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using System.Data.Odbc;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class DinamikRaporRepository : GenericRepository<RaporDizayn>, IDinamikRaporRepository
    {
        DataTable _dataTable = new();
        private readonly IDbConnection _conn;
        DinamikRaporColumns? _dinamikRaporColumns = new();
        public DinamikRaporRepository(IDbConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public async Task<DinamikRaporColumns?> QueryGetData(string whereValues, int raporId)
        {
            _dinamikRaporColumns = new DinamikRaporColumns();
            string sql = $@"SELECT  sorgu,rapor_ad,group_summary,summary,sayihane,sayicolumn,tarihformat,tarihcolumn,summary_header  FROM dba.rapor_dizayn 
                            WHERE  raporid='{raporId}'";

            RaporDizayn tableValues = await _conn.QueryFirstOrDefaultAsync<RaporDizayn>(sql);

            _dataTable = new();

            string ayrısorgu = "";

            if (tableValues != null)
            { 
                if (tableValues.sorgu.Contains("UNION"))
                {
                    if (tableValues.sorgu.Contains("GROUP BY"))
                    {
                        string[] arg = new string[1000];
                        arg = tableValues.sorgu.Split(new string[] { "GROUP BY" }, StringSplitOptions.None);
                        for (int i = 0; i < arg.Length; i++)
                        {
                            if (ayrısorgu == "")
                            {
                                ayrısorgu += arg[i] + whereValues;
                            }
                            else
                            {
                                ayrısorgu += whereValues + " GROUP BY " + arg[i];
                            }
                        }
                        tableValues.sorgu = ayrısorgu;


                    }
                    else if (tableValues.sorgu.Contains("ORDER BY"))
                    {
                        string[] arg = new string[1000];
                        arg = tableValues.sorgu.Split(new string[] { "ORDER BY" }, StringSplitOptions.None);
                        for (int i = 0; i < arg.Length; i++)
                        {
                            if (ayrısorgu == "")
                                ayrısorgu += arg[i] + whereValues;
                            else
                                ayrısorgu += whereValues + " ORDER BY " + arg[i];
                        }
                        tableValues.sorgu = ayrısorgu;
                    }
                    else
                    {
                        string[] arg = new string[1000];
                        arg = tableValues.sorgu.Split(new string[] { "UNION" }, StringSplitOptions.None);
                        for (int i = 0; i < arg.Length; i++)
                        {
                            if (ayrısorgu == "")
                                ayrısorgu += arg[i] + whereValues;
                            else
                                ayrısorgu += " UNION " + arg[i] + whereValues;
                        }
                        tableValues.sorgu = ayrısorgu;
                    }
                }
                else
                {
                    if (tableValues.sorgu.Contains("GROUP BY"))
                    {
                        string[] arg = new string[1000];
                        arg = tableValues.sorgu.Split(new string[] { "GROUP BY" }, StringSplitOptions.None);
                        for (int i = 0; i < arg.Length; i++)
                        {
                            if (ayrısorgu == "")
                                ayrısorgu += arg[i] + whereValues;
                            else
                                ayrısorgu += " GROUP BY " + arg[i];
                        }
                        tableValues.sorgu = ayrısorgu;
                    }
                    else if (tableValues.sorgu.Contains("ORDER BY"))
                    {
                        string[] arg = new string[1000];
                        arg = tableValues.sorgu.Split(new string[] { "ORDER BY" }, StringSplitOptions.None);
                        for (int i = 0; i < arg.Length; i++)
                        {
                            if (ayrısorgu == "")
                                ayrısorgu += arg[i] + whereValues;
                            else
                                ayrısorgu += " ORDER BY " + arg[i];
                        }
                        tableValues.sorgu = ayrısorgu;
                    }
                    else
                    {
                        tableValues.sorgu += " " + whereValues;
                        // anasorgu = tableValues.sorgu;
                    }
                }

                if (!tableValues.sorgu.Contains("UNION") && !tableValues.sorgu.Contains("GROUP BY") && !tableValues.sorgu.Contains("ORDER BY"))
                {
                    tableValues.sorgu += " " + whereValues;
                }


                if (tableValues.sorgu.Contains(":srk_no"))
                    tableValues.sorgu = tableValues.sorgu.Replace(":srk_no", "1");

                if (tableValues.sorgu.Contains(":an_yil"))
                    tableValues.sorgu = tableValues.sorgu.Replace(":an_yil", DateTime.Now.Year.ToString());

                tableValues.sorgu = tableValues.sorgu.Replace(";", "");

                await using OdbcConnection con = (OdbcConnection)_conn;
                await using OdbcCommand cmd = new OdbcCommand(tableValues.sorgu);
                cmd.Connection = con;
                using OdbcDataAdapter oda = new OdbcDataAdapter(cmd);
                oda.Fill(_dataTable);
                if (_dataTable.Rows.Count > 0)
                {
                    return await ModelDataBind(tableValues);
                }
            }

            return _dinamikRaporColumns;
        }

        public async Task<DinamikRaporColumns?> ModelDataBind(RaporDizayn raporProperty)
        {
            _dinamikRaporColumns = new DinamikRaporColumns();
            if (_dataTable.Rows.Count > 0)
            {
                List<string> columns = (from DataColumn dc in _dataTable.Columns select dc.ColumnName).ToList();

                _dinamikRaporColumns.summary = raporProperty.summary;
                _dinamikRaporColumns.groupSummary = raporProperty.group_summary;


                int i = 0;
                foreach (DataColumn column in _dataTable.Columns)
                {
                    if (i >= _dinamikRaporColumns.propertyColumn.Length) break;

                    _dinamikRaporColumns.propertyColumn[i] = column.ColumnName;
                    i++;
                }

                foreach (DataRow row in _dataTable.Rows)
                {
                    var values = row.ItemArray;
                    DinamikRaporRows dinamikRaporRows = new DinamikRaporRows();

                    int columnIndex = 0;
                    foreach (var column in columns)
                    {
                        string columnName = "property" + columnIndex;
                        string value = values[columnIndex].ToString();
                        string formattedValue = FormatColumnValue(raporProperty, value, columnName, raporProperty.sayihane);
                        dinamikRaporRows.SetPropertyValue(columnName, formattedValue);

                        _dinamikRaporColumns.DinamikRaporRows.Add(dinamikRaporRows);

                        columnIndex++;
                    }
                }
            }

            return _dinamikRaporColumns;
        }

        string FormatColumnValue(RaporDizayn raporProperty, string value, string columnName, int sayihane)
        {
            if (raporProperty.sayicolumn.Contains(columnName))
            {
                return !string.IsNullOrEmpty(value)
                    ? Convert.ToDecimal(value).ToString("N" + sayihane + "")
                    : "";
            }

            return value.Contains("00:00:00")
                ? Convert.ToDateTime(value).ToString("yyyy-MM-dd")
                : value;
        }
    }
}
