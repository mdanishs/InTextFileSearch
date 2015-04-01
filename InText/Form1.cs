using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InText
{
    public partial class frmMain : Form
    {

        List<String> directories;
        Thread parallel;
        bool isSearching;
        DateTime startTime;
        DateTime endTime;
        public frmMain()
        {
            InitializeComponent();
            directories = new List<string>();
            parallel = new Thread(searchParallel);
            isSearching = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                cbDirectory.Items.Add(drive.ToString());
            }
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            DialogResult folder = folderBrowserDialog.ShowDialog();
            if (folder == DialogResult.OK)
            {
                cbDirectory.Text = folderBrowserDialog.SelectedPath.ToString();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isSearching = false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            isSearching = true;
            
            directories.Clear();
            lbResults.Items.Clear();
            pbSearchProgress.Value = 0;
            
            if (cbDirectory.Text.Length != 0)
            {
                getAllDirectories(cbDirectory.Text);
                pbSearchProgress.Maximum = directories.Count;
                pbSearchProgress.Minimum = 0;
                searchNoParallel();
            }

        }

        private void searchNoParallel()
        {
            startTime = DateTime.Now;
                foreach (String dir in directories)
                {
                    //MessageBox.Show(dir.ToString());
                    String[] files = Directory.GetFiles(dir);

                    foreach (String file in files)
                    {
                        //MessageBox.Show(file.ToString());
                        
                        if (checkFilePermission(file))
                        {
                            StreamReader reader = new StreamReader(file);
                            //MessageBox.Show(file);
                            int lineCount = 0;
                            while (reader.Peek() != -1)
                            {
                                Application.DoEvents();
                                String line = reader.ReadLine();
                                lineCount++;
                                if (line.ToLower().Contains(txtSearch.Text.ToLower()))
                                {
                                    lbResults.Items.Add("Found in " + file + " at line: " + lineCount);
                                }
                                if (isSearching == false)
                                {
                                    pbSearchProgress.Value = 0;
                                    break;
                                }
                            }
                            reader.Close();
                        }
                        if (isSearching == false)
                        {
                            break;
                        }
                    }
                    pbSearchProgress.Value++;
                    if (isSearching == false)
                    {
                        break;
                    }
                }
            pbSearchProgress.Value = 0;
            endTime = DateTime.Now;
            MessageBox.Show("Time Taken: " + endTime.Subtract(startTime).TotalMilliseconds + " Miliseconds");

        }

        private void btnParallelSearch_Click(object sender, EventArgs e)
        {
            isSearching = true;
            directories.Clear();
            lbResults.Items.Clear();
            //searchParallel();
            
            if (cbDirectory.Text.Length != 0)
            {
                if (parallel.ThreadState == ThreadState.Stopped || parallel.ThreadState == ThreadState.Aborted) parallel.Abort();
                
                getAllDirectories(cbDirectory.Text);
                pbSearchProgress.Maximum = directories.Count;
                pbSearchProgress.Minimum = 0;
                pbSearchProgress.Value = 0;
                parallel.Start();
            }
            
        }

        private void searchParallel()
        {
                //foreach (String dir in directories)
            ParallelOptions opt = new ParallelOptions();
            opt.MaxDegreeOfParallelism = 14;
            startTime = DateTime.Now;
                Parallel.ForEach(directories,opt, (dir,loopState) =>
                {
                        //MessageBox.Show(dir.ToString());
                        String[] files = Directory.GetFiles(dir);

                        foreach (String file in files)
                        {
                            //MessageBox.Show(file.ToString());

                            if (checkFilePermission(file))
                            {
                                StreamReader reader = new StreamReader(file);
                                //MessageBox.Show(file);
                                int lineCount = 0;
                                while (reader.Peek() != -1)
                                {
                                    //Application.DoEvents();
                                    String line = reader.ReadLine();
                                    lineCount++;
                                    if (line.ToLower().Contains(txtSearch.Text.ToLower()))
                                    {
                                        updateList(file, lineCount);
                                    }
                                    if (isSearching == false)
                                    {
                                        parallel.Abort();

                                    }
                                }
                                reader.Close();
                            }
                            //if (isSearching == false)
                            //{
                            //    break;
                            //}
                        }
                        pbMakeProgress();
                        if (isSearching == false)
                        {
                            loopState.Stop();
                        }
                        
                });
                //MessageBox.Show("Search Completed.");
                endTime = DateTime.Now;
                MessageBox.Show("Time Taken: " + endTime.Subtract(startTime).TotalMilliseconds + " Miliseconds");
                isSearching = false;
                pbMakeProgress();

        }

        private void getAllDirectories(String driveRootDirectory)
        {
            String[] dirs = Directory.GetDirectories(driveRootDirectory);
            directories.Add(driveRootDirectory);
            foreach (String dir in dirs)
            {
                if (checkPermission(dir))
                {
                    directories.Add(dir);
                    if (Directory.GetDirectories(dir).Length != 0)
                    {
                        getAllDirectories(dir);
                    }
                }

            }
        }

        private bool checkPermission(String directory)
        {
            try
            {
                Directory.GetDirectories(directory);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool checkFilePermission(String file)
        {
            try
            {
                StreamReader reader = new StreamReader(file);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private delegate void listDelegate(String file, int lineCount);

        private void updateList(String file, int lineCount)
        {
            if (lbResults.InvokeRequired)
            {
                listDelegate lstDelegate = new listDelegate(updateList);
                lbResults.Invoke(lstDelegate, new object[] { file, lineCount });

            }
            else
            {
                lbResults.Items.Add("Found in " + file + " at line: " + lineCount);
            }
            
        }
        int i = 0;
        private void pbMakeProgress()
        {
            i++;
            try
            {

                if (pbSearchProgress.InvokeRequired)
                {
                    pbSearchProgress.Invoke(new MethodInvoker(pbMakeProgress));
                }
                else
                {
                    if (isSearching) pbSearchProgress.Value++;
                    else pbSearchProgress.Value = 0;

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
       
    }
}
