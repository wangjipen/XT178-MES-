using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace SKTraceablity.Tool
{
    public partial class frmLog : Office2007Form
    {
        string fileName;
        public frmLog()
        {
            InitializeComponent();

        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "//log");
            FileInfo[] fis = di.GetFiles("*.log", SearchOption.AllDirectories);

            for (int i = 0; i < fis.Length - 1; i++)
            {
                for (int j = 0; j < fis.Length - 1 - i; j++)
                {
                    if (fis[j].LastWriteTime < fis[j + 1].LastWriteTime)
                    {
                        FileInfo f = fis[j];
                        fis[j] = fis[j + 1];
                        fis[j + 1] = f;

                    }
                }
            }

            for (int i = 0; i < fis.Length; i++)
            {
                TreeNode rootnode = new TreeNode();//创建根节点
                rootnode.Text = fis[i].Name;
                treeView1.Nodes[0].Nodes.Add(rootnode);
            }
        }
        private void directoryCopy(string sourceDirectory, string targetDirectory)
        {
            if (!Directory.Exists(sourceDirectory) )
            {
                return;
            }
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            DirectoryInfo sourceInfo = new DirectoryInfo(sourceDirectory);
            FileInfo[] fileInfo = sourceInfo.GetFiles();
            foreach (FileInfo fiTemp in fileInfo)
            {
                File.Copy(sourceDirectory + "\\" + fiTemp.Name, targetDirectory + "\\" + fiTemp.Name, true);
            }
            DirectoryInfo[] diInfo = sourceInfo.GetDirectories();
            foreach (DirectoryInfo diTemp in diInfo)
            {
                string sourcePath = diTemp.FullName;
                string targetPath = diTemp.FullName.Replace(sourceDirectory, targetDirectory);
                Directory.CreateDirectory(targetPath);
                directoryCopy(sourcePath, targetPath);
            }
        }
        private void analyzeLine3(string line)
        {
            string time, level, message, row;
            int timeLocation = line.IndexOf("时间：");
            int levelLocation = line.IndexOf("级别：");
            int messageLocation = line.IndexOf("描述：");
            int rowLocation = line.IndexOf("行号：");
            if (timeLocation == 0)
            {
                time = line.Substring(3, levelLocation - 8);
                level = line.Substring(levelLocation + 3, messageLocation - levelLocation - 3).Trim();
                TimeSpan nowTime = Convert.ToDateTime(time).TimeOfDay;
                TimeSpan beginTime = dateTimePicker2.Value.TimeOfDay;
                TimeSpan endTime = dateTimePicker4.Value.TimeOfDay;
                if (chkTime.Checked && (nowTime < beginTime || nowTime > endTime))
                {
                    return;
                }
                if (comboBoxEx1.SelectedIndex != 0)
                {
                    if (comboBoxEx1.SelectedIndex == 1 && level != "INFO")
                    {
                        return;
                    }
                    else if (comboBoxEx1.SelectedIndex == 2 && level != "ERROR")
                    {
                        return;
                    }
                }
                ListViewItem lvi = new ListViewItem();
                lvi.Text = time;
                lvi.SubItems.Add(level);
                if (rowLocation != -1)
                {
                    message = line.Substring(messageLocation + 3, rowLocation - messageLocation - 4);
                    row = line.Substring(rowLocation + 3);
                    lvi.SubItems.Add(message);
                    lvi.SubItems.Add(row);
                }
                else
                {
                    message = line.Substring(messageLocation + 3);
                    lvi.SubItems.Add(message);
                }
                this.listViewEx1.Items.Add(lvi);
            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Empty;
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(line);
                lvi.SubItems.Add(string.Empty);
                this.listViewEx1.Items.Add(lvi);
            }
        }

        private void analyzeLine2(string line)
        {
            string time, level, message, row;
            string[] lineArray = line.Split('：');

            if (lineArray.Length >= 4 && lineArray[0] == "时间")
            {
                time = lineArray[1].Substring(0, lineArray[1].Length - 7);
                level = lineArray[2].Substring(0, lineArray[2].Length - 4);

                TimeSpan nowTime = Convert.ToDateTime(time).TimeOfDay;
                TimeSpan beginTime = dateTimePicker2.Value.TimeOfDay;
                TimeSpan endTime = dateTimePicker4.Value.TimeOfDay;
                if (chkTime.Checked && (nowTime < beginTime && nowTime > endTime))
                {
                    return;
                }
                if (comboBoxEx1.SelectedIndex != 0)
                {
                    if (comboBoxEx1.SelectedIndex == 1 && level != "INFO")
                    {
                        return;
                    }
                    else if (comboBoxEx1.SelectedIndex == 2 && level != "ERROR")
                    {
                        return;
                    }
                }
                ListViewItem lvi = new ListViewItem();
                lvi.Text = time;
                lvi.SubItems.Add(level);

                if (lineArray.Length == 5)
                {
                    message = lineArray[3].Substring(0, lineArray[3].Length - 3);
                    row = lineArray[4].Substring(0, lineArray[4].Length);
                    lvi.SubItems.Add(message);
                    lvi.SubItems.Add(row);
                }
                else
                {
                    message = lineArray[3].Substring(0, lineArray[3].Length);
                    lvi.SubItems.Add(message);
                }

                this.listViewEx1.Items.Add(lvi);
            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Empty;
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(line);
                lvi.SubItems.Add(string.Empty);
                this.listViewEx1.Items.Add(lvi);
            }
        }

        private void analyzeLine(string line)
        {
            if (line.Length > 19)
            {
                try
                {
                    TimeSpan nowTime = Convert.ToDateTime(line.Substring(0, 19)).TimeOfDay;
                    if (chkTime.Checked)
                    {
                        TimeSpan beginTime = dateTimePicker2.Value.TimeOfDay;
                        TimeSpan endTime = dateTimePicker4.Value.TimeOfDay;
                        if (nowTime > beginTime && nowTime < endTime)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = line.Substring(0, 19);
                            lvi.SubItems.Add(line.Substring(27, line.Length - 27));
                            this.listViewEx1.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = line.Substring(0, 19);
                        lvi.SubItems.Add(line.Substring(27, line.Length - 27));
                        this.listViewEx1.Items.Add(lvi);
                    }
                }
                catch
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = string.Empty;
                    lvi.SubItems.Add(line);
                    this.listViewEx1.Items.Add(lvi);
                }

            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Empty;
                lvi.SubItems.Add(line);
                this.listViewEx1.Items.Add(lvi);
            }
        }
        private void BT_ImportLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                directoryCopy(Application.StartupPath + "//log", fbd.SelectedPath + "//LogBackup" + DateTime.Now.ToString("yyMMddHHmmss"));
                MessageBox.Show("导出成功");
            }
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action != TreeViewAction.Unknown && e.Node.Level == 1)
                {
                    listViewEx1.Items.Clear();
                    fileName = e.Node.Text;
                    FileStream fs = new FileStream(Application.StartupPath + "//log//" + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        analyzeLine3(line);
                    }
                }
            }
            catch
            {
                MessageBoxEx.Show("显示错误");
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                listViewEx1.Items.Clear();
                FileStream fs = new FileStream(Application.StartupPath + "//log//" + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    analyzeLine3(line);
                }
            }
        }
    }
}
