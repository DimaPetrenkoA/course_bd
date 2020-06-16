using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Npgsql;

namespace BDcource2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connection_string;
        string login;
        public MainWindow(string connection_string, string login)
        {
            InitializeComponent();
            this.connection_string = connection_string;
            this.login = login;
            set_TextBox(tb_search, "Поиск");

            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);

            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            btn_plants_Click(btn_plants, null);
            new Generator();
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void set_TextBox(TextBox tb, string text = "")
        {
            var converter = new System.Windows.Media.BrushConverter();
            tb.Text = text;
            tb.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
            tb.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_LostKeyboardFocus);
        }
        bool enabletxb = false;
        private void tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                //If nothing has been entered yet.
                var converter = new System.Windows.Media.BrushConverter();

                if (enabletxb == false)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = System.Windows.Media.Brushes.White;
                }
            }
        }


        private void tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                enabletxb = false;
                //If nothing was entered, reset default text.
                if (((TextBox)sender).Text.Trim().Equals(""))
                {
                    var converter = new System.Windows.Media.BrushConverter();
                    ((TextBox)sender).Foreground = (System.Windows.Media.Brush)converter.ConvertFromString("#FFAAAAAA");//K
                    if (((TextBox)sender).Name == "tb_search")
                        ((TextBox)sender).Text = "Поиск";
                    else
                        ((TextBox)sender).Text = "DefaultText";
                }
            }
        }

        void FillGridFromDataSet(DataSet dataSet)
        {
            try
            {
                dataGridView1.Columns.Clear();
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    var col = dataSet.Tables[0].Columns[i];
                    dataGridView1.Columns.Add(col.ColumnName, col.Caption);
                    if(i==0) dataGridView1.Columns[col.ColumnName].ReadOnly = true;

                }
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    dataGridView1.Rows.Add(dataSet.Tables[0].Rows[i].ItemArray);

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    if (i == dataGridView1.Columns.Count - 1)
                        dataGridView1.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch (Exception e)
            {

            }

        }

        DataSet FillDataSetFromDB(string sql)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connection_string);
                var select = sql;
                var dataAdapter = new NpgsqlDataAdapter(select, connection);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                last_click(last_sender, null);
                return null;
            }
        }

        void execSql(string sql)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connection_string);
                connection.Open();
                NpgsqlCommand com = new NpgsqlCommand(sql, connection);
                com.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                last_click(last_sender, null);
            }
        }

        public DataTable fillComboBox(string fields, string table, string display_member)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connection_string);
            var select = "SELECT " + fields + " FROM \"" + table + "\" ORDER BY " + display_member;

            var dataAdapter = new NpgsqlDataAdapter(select, connection);
            var dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        /// <summary>
        /// добавить ComboBox в таблицу
        /// </summary>
        /// <param name="name_cmbCol">имя колонки в таблице</param>
        /// <param name="headerText">отображение колонки</param>
        /// <param name="table">из какой таблицы брать данные</param>
        /// <param name="ValueMember">какой член table брать за индекс</param>
        /// <param name="DisplayMember">какой член table показывать</param>
        /// <param name="Xindex">каким по порядку разместить</param>
        void addComboBoxColumn(string name_cmbCol, string headerText, string table,
            string ValueMember, string DisplayMember, int Xindex)
        {
            System.Windows.Forms.DataGridViewComboBoxColumn cmbCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            cmbCol.HeaderText = headerText;
            cmbCol.Name = name_cmbCol;

            string fields = $"*";
            cmbCol.DataSource = fillComboBox(fields, table, DisplayMember);
            cmbCol.ValueMember = ValueMember;

            cmbCol.DisplayMember = DisplayMember;
            cmbCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            dataGridView1.Columns.Add(cmbCol);
            dataGridView1.Columns[name_cmbCol].DisplayIndex = Xindex;
            dataGridView1.Columns[Xindex].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        }

        void setComboBoxColumn(string column, string column_with_id)
        {
            foreach (System.Windows.Forms.DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[column].Value = row.Cells[column_with_id].Value;
            }
        }

        public void StretchLastColumn()
        {
            var lastColIndex = dataGridView1.Columns.Count - 1;
            var lastCol = dataGridView1.Columns[lastColIndex];
            lastCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }

        void fix_cmb_width()
        {
            if (dataGridView1.Columns.Count != 0)
            {
                dataGridView1.Columns[0].ReadOnly = true;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    var sub = dataGridView1.Columns[i].Name.Substring(0, 3);
                    if (sub == "cmb")
                    {
                        dataGridView1.Columns[i].Width = 160;
                    }
                    else if (sub == "chk")
                    {

                    }
                    else if (dataGridView1.Columns[i].Name == "дата")
                    {
                        dataGridView1.Columns[i].Width = 130;
                    }

                    else
                    {
                        dataGridView1.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
        }

        string generate_where()
        {
            string where = "";
            List<string> likes = new List<string>();
            for (int i = 0; i < fields.Length; i++)
                if (fields_types[i] == "string")
                    likes.Add($"{fields[i]} LIKE '%{search}%'");

            if (likes.Count == 0 || search == "Search" || search == "")
                where = "1=1";
            else
            {
                bool first = true;
                for (int i = 0; i < likes.Count; i++)
                {
                    if (first)
                    {
                        where += likes[i];
                        first = false;
                    }
                    else
                        where += " OR " + likes[i];
                }
            }
            return where;
        }

        string generate_select(string[] fields, string table)
        {
            string where = generate_where();
            string result = "SELECT  ";
            
            foreach(string field in fields){
                result += "\"" +field + "\",";
            }
            result = result.Remove(result.Length - 1);
            result += $"FROM \"{table}\" ";
            result += $"WHERE {where} ";
            result += $"ORDER BY {fields[0]} ";
            result += $"LIMIT {(page + 1) * 50} ";
            result += $"OFFSET {page * 50} ";
            int count = getCountRowsTable(table, where);
            status_text.Text = " " + ((page + 1) * 50).ToString();
            status_text.Text += "/" + count + " ";

            return result;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void move_rect(object sender)
        {
            rect.Margin = new Thickness((sender as Button).Margin.Left, (sender as Button).Margin.Top, 0, 0);
            rect.Height = (sender as Button).Height;
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        string[] fields;
        string[] fields_types;
        string table;
        delegate void btn_click(object sender, RoutedEventArgs e);
        btn_click last_click;
        object last_sender;

        private void btn_plants_Click(object sender, RoutedEventArgs e)
        {
            last_click = btn_plants_Click;
            last_sender = sender;
            move_rect(sender);

            table = "Заводы";
            fields = new string[]
            {
                "id_plants", "название", "город", "id_type", "год", "телефон", "id_country", "id_fuel", "объём", "цена"
            };

            fields_types = new string[]
            {
                "int", "string", "string", "int", "int", "string", "int", "int", "int", "int"
            };

            FillGridFromDataSet(FillDataSetFromDB(generate_select(fields, table)));

            dataGridView1.Columns["id_type"].Visible = false;
            dataGridView1.Columns["id_country"].Visible = false;
            dataGridView1.Columns["id_fuel"].Visible = false;
            addComboBoxColumn("cmb_type", "тип", "тип собственности", "id_type", "тип", 2);
            addComboBoxColumn("cmb_country", "страна", "страны", "id_country", "страна", 4);
            addComboBoxColumn("cmb_fuel", "топливо", "вид топлива", "id_fuel", "топливо", 5);
            setComboBoxColumn("cmb_type", "id_type");
            setComboBoxColumn("cmb_country", "id_country");
            setComboBoxColumn("cmb_fuel", "id_fuel");
            fix_cmb_width();
        }

        private void btn_orders_Click(object sender, RoutedEventArgs e)
        {
            last_click = btn_orders_Click;
            last_sender = sender;
            move_rect(sender);

            table = "Заказы";
            fields = new string[]
            {
                "id_order", "id_client", "id_fuel", "объём", "дата", "id_plants"
            };

            fields_types = new string[]
            {
                "int", "int", "int", "int", "string", "int"
            };

            FillGridFromDataSet(FillDataSetFromDB(generate_select(fields, table)));

            dataGridView1.Columns["id_client"].Visible = false;
            dataGridView1.Columns["id_fuel"].Visible = false;
            dataGridView1.Columns["id_plants"].Visible = false;

            addComboBoxColumn("cmb_client", "Заказчики", "Заказчики", "id_client", "название", 2);
            addComboBoxColumn("cmb_fuel", "вид топлива", "вид топлива", "id_fuel", "топливо", 3);
            addComboBoxColumn("cmb_plants", "Заводы", "Заводы", "id_plants", "название", 8);

            setComboBoxColumn("cmb_client", "id_client");
            setComboBoxColumn("cmb_fuel", "id_fuel");
            setComboBoxColumn("cmb_plants", "id_plants");

            dataGridView1.Columns["дата"].ReadOnly = true;

            foreach (System.Windows.Forms.DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["дата"].Value != null && row.Cells["дата"].Value.ToString() != "")
                    row.Cells["дата"].Value = row.Cells["дата"].Value.ToString().Substring(0, 10);
            }

            fix_cmb_width();

        }

        private void btn_firms_Click(object sender, RoutedEventArgs e)
        {
            last_click = btn_firms_Click;
            last_sender = sender;
            move_rect(sender);

            table = "Заказчики";
            fields = new string[]
            {
                "id_client", "название", "город", "телефон"
            };

            fields_types = new string[]
            {
                "int", "string", "string", "string"
            };

            FillGridFromDataSet(FillDataSetFromDB(generate_select(fields, table)));

            fix_cmb_width();
            StretchLastColumn();
        }

        private void btn_country_Click(object sender, RoutedEventArgs e)
        {
            last_click = btn_country_Click;
            last_sender = sender;
            move_rect(sender);

            table = "страны";
            fields = new string[]
            {
                "id_country", "страна"
            };

            fields_types = new string[]
            {
                "int", "string"
            };

            FillGridFromDataSet(FillDataSetFromDB(generate_select(fields, table)));

            fix_cmb_width();
            StretchLastColumn();
        }

        private void btn_fuel_Click(object sender, RoutedEventArgs e)
        {
            last_click = btn_fuel_Click;
            last_sender = sender;
            move_rect(sender);

            table = "вид топлива";
            fields = new string[]
            {
                "id_fuel", "топливо"
            };

            fields_types = new string[]
            {
                "int", "string"
            };

            FillGridFromDataSet(FillDataSetFromDB(generate_select(fields, table)));

            //dataGridView1.Columns["id_hospital"].Visible = false;
            //dataGridView1.Columns["id_depart"].Visible = false;
            //addComboBoxColumn("cmb_hospital", "Больница", "Больницы", "id_hospital", "номер", 1);
            //addComboBoxColumn("cmb_depart", "Отделение", "Отделения", "id_depart", "отделение", 2);
            //setComboBoxColumn("cmb_hospital", "id_hospital");
            //setComboBoxColumn("cmb_depart", "id_depart");
            fix_cmb_width();
            StretchLastColumn();
        }

        private void btn_type_Click(object sender, RoutedEventArgs e)
        {
            last_click = btn_type_Click;
            last_sender = sender;
            move_rect(sender);

            table = "тип собственности";
            fields = new string[]
            {
                "id_type", "тип"
            };

            fields_types = new string[]
            {
                "int", "string"
            };

            FillGridFromDataSet(FillDataSetFromDB(generate_select(fields, table)));

            fix_cmb_width();
            StretchLastColumn();
        }

        

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            move_rect(sender);
            QueryWindow window = new QueryWindow(connection_string);
            window.Show();
            move_rect(last_sender);
        }

        bool readStrFromCell(System.Windows.Forms.DataGridViewCell cell, out string r)
        {
            bool result = true;

            if (cell.Value != null)
            {
                r = cell.Value.ToString();
            }
            else
            {
                r = "";
                result = false;
            }

            return result;
        }
        bool readIntFromCell(System.Windows.Forms.DataGridViewCell cell, out string i)
        {
            int temp = 0;
            i = "null";
            if (cell.Value != null)
            {
                if (int.TryParse(cell.Value.ToString(), out temp))
                {
                    i = cell.Value.ToString();
                }
                else if (cell.Value.ToString() != "")
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private void dataGridView1_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            string name = dataGridView1.Columns[e.ColumnIndex].Name;

            if (name.Length > 3 && name.Substring(0, 3) == "cmb")
            {
                row.Cells["id" + name.Substring(3)].Value = row.Cells[name].Value;
                return;
            }

            string sql = "";
            if (row.Cells[fields[0]].Value == null)//insert
            {
                string values_string = "";
                for(int i=1;i<fields.Length; i++)
                {
                    string temp= "";
                    if (fields_types[i] == "int")
                    {
                        bool result = readIntFromCell(row.Cells[fields[i]], out temp);
                        if (result == false && !fields[i].StartsWith("id"))
                        {
                            //MessageBox.Show("вы ввели не число!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        values_string += $"{temp}";
                    }
                    else if (fields_types[i] == "string")
                    {
                        readStrFromCell(row.Cells[fields[i]], out temp);
                        values_string += $"'{temp}'";
                    }
                    if (temp.Equals("null") || temp.Trim(' ').Equals(""))
                        return;

                    if (i != fields.Length-1)
                        values_string += ", ";
                }

                

                sql = $"insert into \"{table}\"(";
                for (int i = 1; i< fields.Length; i++){
                    if (i != fields.Length - 1)
                    {
                        sql += $"\"{fields[i]}\", ";
                    }
                    else
                    {
                        sql += $"\"{fields[i]}\"";
                        sql += ") VALUES (";
                    }
                }
                sql += values_string;
                sql += ")";

                execSql(sql);
                last_click(last_sender, null);
            }
            else//update
            {
                sql = $" update \"{table}\" set ";
                for (int i = 1; i < fields.Length; i++)
                {
                    string temp = "";
                    if (fields_types[i] == "int")
                    {
                        bool result = readIntFromCell(row.Cells[fields[i]], out temp);
                        if (result == false && !fields[i].StartsWith("id"))
                        {
                           MessageBox.Show("вы ввели не число!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    else if (fields_types[i] == "string")
                    {
                        readStrFromCell(row.Cells[fields[i]], out temp);
                        temp = $"'{temp}'";
                    }
                    if (i != fields.Length - 1)
                        sql += $"\"{fields[i]}\" = {temp}, ";
                    else
                        sql += $"\"{fields[i]}\" = {temp} ";
                }
                sql += $" where \"{fields[0]}\" = {row.Cells[fields[0]].Value.ToString()}";
                execSql(sql);
                //last_click(last_sender, null);
            }
        }


        System.Windows.Forms.DateTimePicker dtp = new System.Windows.Forms.DateTimePicker();
        Rectangle rectangle;

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text.ToString();
            dtp.Visible = false;
        }

        private void dataGridView1_ColumnWidthChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (table == "Заказы")
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "дата")
                    {
                        rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtp.Size = new System.Drawing.Size(rectangle.Width, rectangle.Height);
                        dtp.Location = new System.Drawing.Point(rectangle.X, rectangle.Y);
                        dtp.Visible = true;
                    }
                }
            }
        }


        private void dataGridView1_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {

            string sql = $"delete from \"{table}\" where \"{fields[0]}\" = {e.Row.Cells[fields[0]].Value.ToString()}";
            if (MessageBox.Show("вы уверены что хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            execSql(sql);
        }

        private int getCountRowsTable(string table, string where="1=1")
        {
            NpgsqlConnection connection = new NpgsqlConnection(connection_string);
            connection.Open();

            var dataAdapter = new NpgsqlDataAdapter(
                string.Format("SELECT COUNT(*) FROM \"{0}\" WHERE {1}", table, where),
                connection);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return int.Parse(dataTable.Rows[0][0].ToString());
        }

        string search = "";
        int page = 0;

        private void tb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                search = tb_search.Text;
                last_click(last_sender, null);
            }
        }

        private void btn_left_Click(object sender, RoutedEventArgs e)
        {
            page = Math.Max(0, --page);
            last_click(last_sender, null);
        }

        private void btn_right_Click(object sender, RoutedEventArgs e)
        {
            page++;
            last_click(last_sender, null);
        }

        private void btn_right_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int c = getCountRowsTable(table);
            page = c / 50 - 1;
        }

        private void btn_left_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            page = 0;
            last_click(last_sender, null);
        }
    }
}
