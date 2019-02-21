using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class FrmBarcodeTest : Form
    {
        public FrmBarcodeTest()
        {
            InitializeComponent();
        }

        private void frmBarcodeTest_Load(object sender, EventArgs e)
        {
            //服务器名称，数据库名称，登录名，密码
            string constr = "server = . ; database = BC1 ; uid = sa ; pwd = skq ";
            //连接数据库
            SqlConnection con = new SqlConnection(constr);
            //查询动静态数据
            string sql = "SELECT TESTDATA_ID, DT, SN, FUNC, JSON FROM C_GEELY_TESTDATA_T"; 
            SqlCommand com = new SqlCommand(sql, con);
            //打开连接
            con.Open();
            //读取数据
            SqlDataReader dateReader = com.ExecuteReader(); 
            try
            {
                while (dateReader.Read()) 
                {
                    //下拉框显示所有总成号
                    string sn = comboBox1.Items.Add(dateReader["SN"]).ToString();
                    //默认第一行
                    comboBox1.SelectedIndex = 0; 
                    comboBox2.SelectedIndex = 0;
                }
                //关闭数据读取
                dateReader.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }

            try
            {
                string kind;
                if (comboBox2.Text.Equals("静态测试数据"))
                {
                    kind = "Getstaticcheck";
                    //查询出静态的数据
                    string sql2 = string.Format("SELECT JSON FROM C_GEELY_TESTDATA_T where SN='{0}' and FUNC='{1}'", comboBox1.Text, kind);
                    SqlCommand comm = new SqlCommand(sql2, con);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    SqlDataReader dateReader2 = comm.ExecuteReader();
                    //查看结果是否为空
                    if (dateReader2.Read())
                    {
                        var json = dateReader2["JSON"].ToString();
                        //把静态的数据放在jArray中
                        JArray jArray = (JArray)JsonConvert.DeserializeObject(json); 
                        for (int i = 0; jArray.Count > i; i++)
                        {
                            //获取静态测试总项
                            string stepNo = jArray[i]["stepNo"].ToString();
                            //获取静态测试分项
                            string instructions = jArray[i]["instructions"].ToString();
                            //获取测试值
                            string testValue = jArray[i]["testValue"].ToString();
                            //获取测试单位
                            string unit = jArray[i]["unit"].ToString();
                            //获取测试结果
                            string isPass = jArray[i]["isPass"].ToString(); 
                            DataGridViewRow drRow1 = new DataGridViewRow();
                            drRow1.CreateCells(this.dataGridView1);
                            //设置单元格的值
                            drRow1.Cells[0].Value = stepNo;
                            drRow1.Cells[1].Value = instructions;
                            drRow1.Cells[3].Value = testValue;
                            drRow1.Cells[4].Value = isPass;
                            drRow1.Cells[6].Value = unit;
                            //将新创建的行添加到DataGridView中
                            this.dataGridView1.Rows.Add(drRow1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有此项数据，请重新选择测试状态！");
                    }
                }
                else
                {
                    //动态测试的数据
                    kind = "Getdynaminccheck";
                    //查询动态数据
                    string sql2 = string.Format("SELECT JSON FROM C_GEELY_TESTDATA_T where SN='{0}' and FUNC='{1}'", comboBox1.Text, kind); 
                    SqlCommand comm = new SqlCommand(sql2, con);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    SqlDataReader dateReader2 = comm.ExecuteReader();
                    bool b = dateReader2.Read();
                    if (b)
                    {
                        var json = dateReader2["JSON"].ToString();
                        JArray jArray = (JArray)JsonConvert.DeserializeObject(json);
                        for (int i = 0; i < jArray.Count; i++)
                        {
                            //获取动态测试各项的值
                            string testName = jArray[i]["testName"].ToString();
                            string testValue = jArray[i]["testValue"].ToString();
                            string Result = jArray[i]["Result"].ToString();
                            DataGridViewRow drRow1 = new DataGridViewRow();
                            drRow1.CreateCells(this.dataGridView1);
                            //设置单元格的值
                            drRow1.Cells[2].Value = testName;
                            drRow1.Cells[3].Value = testValue;
                            drRow1.Cells[5].Value = Result;
                            //将新创建的行添加到DataGridView中
                            this.dataGridView1.Rows.Add(drRow1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有此项数据，请重新选择测试状态！");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //查询测试的数据
            string constr = "server = . ; database = BC1 ; uid = sa ; pwd = skq ";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            try
            {
                string kind;
                //清除上一条查询的数据
                dataGridView1.Rows.Clear();
                if (comboBox2.Text.Equals("静态测试数据"))
                {
                    //查询静态数据
                    kind = "Getstaticcheck";
                    string sql2 = string.Format("SELECT JSON FROM C_GEELY_TESTDATA_T where SN='{0}' and FUNC='{1}'", comboBox1.Text, kind);
                    SqlCommand comm = new SqlCommand(sql2, con);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    SqlDataReader dateReader2 = comm.ExecuteReader();
                    //查看是否有记录
                    if (dateReader2.Read())
                    {
                        var json = dateReader2["JSON"].ToString();
                        JArray jArray = (JArray)JsonConvert.DeserializeObject(json);
                        for (int i = 0; jArray.Count > i; i++)
                        {
                            //获取静态需要的值
                            string stepNo = jArray[i]["stepNo"].ToString();
                            string instructions = jArray[i]["instructions"].ToString();
                            string testValue = jArray[i]["testValue"].ToString();
                            string unit = jArray[i]["unit"].ToString();
                            string isPass = jArray[i]["isPass"].ToString();
                            DataGridViewRow drRow1 = new DataGridViewRow();
                            drRow1.CreateCells(this.dataGridView1);
                            //设置单元格的值
                            drRow1.Cells[0].Value = stepNo;
                            drRow1.Cells[1].Value = instructions;
                            drRow1.Cells[3].Value = testValue;
                            drRow1.Cells[4].Value = isPass;
                            drRow1.Cells[6].Value = unit;
                            //将新创建的行添加到DataGridView中
                            this.dataGridView1.Rows.Add(drRow1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有此数据，请重新选择测试状态！");
                    }
                }
                else
                {
                    //查询动态数据
                    kind = "Getdynaminccheck";
                    string sql2 = string.Format("SELECT JSON FROM C_GEELY_TESTDATA_T where SN='{0}' and FUNC='{1}'", comboBox1.Text, kind);
                    SqlCommand comm = new SqlCommand(sql2, con);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    SqlDataReader dateReader2 = comm.ExecuteReader();
                    bool b = dateReader2.Read();
                    if (b)
                    {
                        var json = dateReader2["JSON"].ToString();
                        JArray jArray = (JArray)JsonConvert.DeserializeObject(json);
                        for (int i = 0; jArray.Count > i; i++)
                        {
                            //获取需要的动态数据
                            string testName = jArray[i]["testName"].ToString();
                            string testValue = jArray[i]["testValue"].ToString();
                            string Result = jArray[i]["Result"].ToString();
                            DataGridViewRow drRow1 = new DataGridViewRow();
                            drRow1.CreateCells(this.dataGridView1);
                            //设置单元格的值
                            drRow1.Cells[2].Value = testName;
                            drRow1.Cells[3].Value = testValue;
                            drRow1.Cells[5].Value = Result;
                            //将新创建的行添加到DataGridView中
                            this.dataGridView1.Rows.Add(drRow1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有此数据，请重新选择测试状态！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //获得各行的行号
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index+1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //申明保存对话框 
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀 
            dlg.DefaultExt = "xls";
            //文件后缀列表 
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径 
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框 
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径 
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效 
            if (fileNameString.Trim() == " ") 
            {

                return;
            }
            //定义表格内数据的行数和列数 
            int rowscount = dataGridView1.Rows.Count;
            int colscount = dataGridView1.Columns.Count;
            //行数必须大于0 
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0 
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536 
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255 
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它 
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象 
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见 
                objExcel.Visible = false;

                //向Excel中写入表格的表头 
                int displayColumnsCount = 1;
                for (int i = 0; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                    {
                        if (dataGridView1.Rows[0].Cells[i].Value != null)
                        {
                            objExcel.Cells[1, displayColumnsCount] = dataGridView1.Columns[i].HeaderText.Trim();
                            displayColumnsCount++;
                        }
                      
                    }
                }

                //设置进度条 
                //tempProgressBar.Refresh(); 
                //tempProgressBar.Visible   =   true; 
                //tempProgressBar.Minimum=1; 
                //tempProgressBar.Maximum=dgv.RowCount; 
                //tempProgressBar.Step=1; 

                //向Excel中逐行逐列写入表格中的数据 
                for (int row = 0; row <= dataGridView1.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep(); 

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dataGridView1.Rows[row].Cells[col].Value != null)
                        {
                            try
                            {
                              objExcel.Cells[row + 2, displayColumnsCount] = dataGridView1.Rows[row].Cells[col].Value.ToString().Trim();
                              displayColumnsCount++;
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }
                }
                //隐藏进度条 
                //tempProgressBar.Visible   =   false; 
                //保存文件 
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用 
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
