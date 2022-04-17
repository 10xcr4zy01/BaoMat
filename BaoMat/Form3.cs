using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Xml;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Diagnostics;


namespace BaoMat
{
    public partial class Form3 : Form
    {

        private delegate void btnEncryptDecrypt();

        private RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        private string pathKeysXML = "";
        private bool isEncryptFile = true;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AddItemToKeyLengComboBox();
            this.keyLengCbx.Text = "1024 bits";
        }

        private void AddItemToKeyLengComboBox()
        {
            this.keyLengCbx.Items.Add("512 bits");
            this.keyLengCbx.Items.Add("1024 bits");
            this.keyLengCbx.Items.Add("2048 bits");
            this.keyLengCbx.Items.Add("4096 bits");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = "Xml File|*.xml|All File|*.*";
            saveFileDialog1.Title = "Chọn tên file";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            int lengthKey = 0;
            if (this.keyLengCbx.Text == "1024 bits") lengthKey = 1024;
            else if (this.keyLengCbx.Text == "512 bits") lengthKey = 512;
            else if (this.keyLengCbx.Text == "2048 bits") lengthKey = 2048;
            else if (this.keyLengCbx.Text == "4096 bits") lengthKey = 4096;
            saveFileDialog1.RestoreDirectory = true;
            String pathPrivateKey = saveFileDialog1.FileName;
            //tạo key có độ dài lengthKey
            RSA = new RSACryptoServiceProvider(lengthKey); //tạo key có độ dài lengtheKey


            File.WriteAllText(pathPrivateKey, RSA.ToXmlString(true));  // Private Key

            pathKeysXML = pathPrivateKey;
            pathKeyTb.Text = pathPrivateKey; //Hiển thị đường dẫn key

            if (File.Exists(pathKeysXML))
            {
                if (Path.GetExtension(pathKeysXML) == ".xml") //kiểm tra định dạng
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(File.ReadAllText(pathKeysXML)); //đọc RSA Key
                    try
                    {
                        XmlNode xnList = xml.SelectSingleNode("/RSAKeyValue/Modulus");
                        moduleTb.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/Exponent");
                        mmhTb.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/D");
                        mgmTb.Text = xnList.InnerText;
                        moduleTb.Enabled = true;
                        mmhTb.Enabled = true;
                        mgmTb.Enabled = true;
                    }
                    catch (Exception ix)
                    {
                        MessageBox.Show(ix.Message);
                    }
                }
            }
            MessageBox.Show("Tạo key có độ dài " + lengthKey.ToString() + " bits thành công.");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.moduleTb.Clear(); 
            this.mmhTb.Clear(); 
            this.mmhTb.Clear();
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Xml files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pathKeysXML = op.FileName;
                pathKeyTb.Text = op.FileName;
            }

            if (File.Exists(pathKeysXML))
            {

                if (Path.GetExtension(pathKeysXML) == ".xml")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(File.ReadAllText(pathKeysXML));
                    try
                    {
                        XmlNode xnList = xml.SelectSingleNode("/RSAKeyValue/Modulus");
                        moduleTb.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/Exponent");
                        mmhTb.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/D");
                        mgmTb.Text = xnList.InnerText;
                        moduleTb.Enabled = true;
                        mmhTb.Enabled = true;
                        mgmTb.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed: " + ex.Message);
                    }
                }
            }
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            isEncryptFile = true;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                inputTb.Text = op.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f1 = new FolderBrowserDialog();
            if (f1.ShowDialog() == DialogResult.OK)
            {
                this.locationTb.Text = f1.SelectedPath;
            }

        }
        private void RSA_Algorithm(string inputFile, string outputFile, RSAParameters RSAKeyInfo, bool isEncrypt)
        {
            try
            {
                FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read); //Đọc file input
                FileStream fsCiperText = new FileStream(outputFile, FileMode.Create, FileAccess.Write); //Tạo file output
                fsCiperText.SetLength(0);
                byte[] bin, encryptedData;
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 100;

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportParameters(RSAKeyInfo); //Nhập thông tin khoá RSA (bao gồm khoá riêng)

                int maxBytesCanEncrypted;
                //RSA chỉ có thể mã hóa các khối dữ liệu ngắn hơn độ dài khóa, chia dữ liệu cho một số khối và sau đó mã hóa từng khối và sau đó hợp nhất chúng
                if (isEncrypt)
                    maxBytesCanEncrypted = ((RSA.KeySize - 384) / 8) + 37;// + 7: OAEP - Đệm mã hóa bất đối xứng tối ưu

                else
                    maxBytesCanEncrypted = (RSA.KeySize / 8);
                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    if (totlen - rdlen < maxBytesCanEncrypted) maxBytesCanEncrypted = (int)(totlen - rdlen);
                    bin = new byte[maxBytesCanEncrypted];
                    len = fsInput.Read(bin, 0, maxBytesCanEncrypted);

                    if (isEncrypt) encryptedData = RSA.Encrypt(bin, false); //Mã Hoá
                    else encryptedData = RSA.Decrypt(bin, false); //Giải mã

                    fsCiperText.Write(encryptedData, 0, encryptedData.Length);
                    rdlen = rdlen + len;

                    /*this.label1f.Text = "Tên tệp xử lý : " + Path.GetFileName(inputFile) + "\t Thành công: " + ((long)(rdlen * 100) / totlen).ToString() + " %";
                    this.label1f.Update();
                    this.label1f.Refresh();*/

                    this.progressBar1.Value = (int)((rdlen * 100) / totlen);//thanh tiến trình
                }

                fsCiperText.Close(); //save file
                fsInput.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
        }
        private void enabledOrDisableButtons(bool isEnable)
        {
            this.giaimaBtn.Enabled = isEnable;
            this.mahoaBtn.Enabled = isEnable;
            this.button1.Enabled = isEnable;
            this.button2.Enabled = isEnable;
        }
        private void btnEncryptClick()
        {
            enabledOrDisableButtons(false);
            if (this.pathKeyTb.Text.Length == 0 || this.moduleTb.Text.Length == 0 || this.mgmTb.Text.Length == 0 || this.mmhTb.Text.Length == 0)
            {
                MessageBox.Show("Key không hợp lệ!");
                enabledOrDisableButtons(true);
                return;
            }

            try
            {
                if (inputTb.Text.Length != 0 &&
                pathKeyTb.Text.Length != 0 &&
                moduleTb.Text.Length != 0)
                {

                    //Calculator time ex...
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();
                    string inputFileName = inputTb.Text, outputFileName = "";

                    if (isEncryptFile)
                    {
                        outputFileName = locationTb.Text + "\\" + Path.GetFileName(inputTb.Text) + ".lhde";
                    }
                    //get Keys.
                    RSA = new RSACryptoServiceProvider();
                    RSA.FromXmlString(File.ReadAllText(this.pathKeysXML));
                    if (isEncryptFile)
                        RSA_Algorithm(inputFileName, outputFileName, RSA.ExportParameters(true), true);
                    else
                    {
                        string[] filePaths = Directory.GetFiles(inputFileName, "*");

                        if (filePaths.Length == 0 || (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db")))
                        {
                            MessageBox.Show("Thư mục rỗng!");
                            enabledOrDisableButtons(true);
                            return;
                        }



                        // tbt.Text = Path.GetDirectoryName(outputFileName);
                        for (int i = 0; i < filePaths.Length; i++)
                        {
                            outputFileName = locationTb.Text + "\\" + Path.GetFileName(filePaths[i]);
                            if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                                RSA_Algorithm(filePaths[i], outputFileName + ".lhde", RSA.ExportParameters(true), true);
                        }
                    }
                    enabledOrDisableButtons(true);
                    sw.Stop();
                    double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                    MessageBox.Show("Thời gian thực thi " + elapsedMs.ToString() + "s");
                }
                else
                {
                    enabledOrDisableButtons(true);
                    MessageBox.Show("Dữ liệu không đủ để mã hóa!");
                }
            }
            catch (Exception ex)
            {
                enabledOrDisableButtons(true);
                MessageBox.Show("Failed: " + ex.Message);
            }
            enabledOrDisableButtons(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (locationTb.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đường dẫn đến thư mục Output");
                return;
            }
            if (pathKeyTb.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đường dẫn đến Key!");
                return;
            }
            /*btnEncryptDecrypt s = new btnEncryptDecrypt(btnEncryptClick);
            s.BeginInvoke(null, null);*/
            btnEncryptClick();
        }

        private void giaimaBtn_Click(object sender, EventArgs e)
        {
            if (locationTb.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đường dẫn đến thư mục Output");
                return;
            }
            /*btnEncryptDecrypt s = new btnEncryptDecrypt(btnDecryptClick);
            s.BeginInvoke(null, null);*/
            btnDecryptClick();
        }

        private void btnDecryptClick()
        {
            enabledOrDisableButtons(false);

            try
            {
                if (inputTb.Text.Length != 0 &&
                   pathKeyTb.Text.Length != 0 &&
                   moduleTb.Text.Length != 0)
                {
                    //Calculator time ex...
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();

                    string inputFileName = inputTb.Text, outputFileName = "";

                    if (isEncryptFile && Path.GetExtension(inputFileName) != ".lhde")
                    {
                        MessageBox.Show("Tệp tin này không được hỗ trợ đển giải mã!");
                        enabledOrDisableButtons(true);
                        return;
                    }

                    if (isEncryptFile)
                    {

                        outputFileName = locationTb.Text + "\\" + Path.GetFileName(inputFileName.Substring(0, inputFileName.Length - 5));


                    }

                    RSA = new RSACryptoServiceProvider();
                    RSA.FromXmlString(File.ReadAllText(this.pathKeysXML));

                    if (isEncryptFile)
                        RSA_Algorithm(inputFileName, outputFileName, RSA.ExportParameters(true), false);
                    else
                    {
                        string[] filePaths = Directory.GetFiles(inputFileName, "*.lhde", SearchOption.AllDirectories);
                        if (filePaths.Length == 0 || (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db")))
                        {
                            MessageBox.Show("Thư mục rỗng!");
                            enabledOrDisableButtons(true);
                            return;
                        }

                        for (int i = 0; i < filePaths.Length; i++)
                            if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                            {
                                outputFileName = locationTb.Text + "\\" + Path.GetFileName(filePaths[i].Substring(0, filePaths[i].Length - 5));
                                RSA_Algorithm(filePaths[i], outputFileName, RSA.ExportParameters(true), false);

                            }

                    }
                    enabledOrDisableButtons(true);
                    sw.Stop();
                    double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                    MessageBox.Show("Tổng thời gian thực thi: " + elapsedMs.ToString() + "s");
                }
                else
                {
                    MessageBox.Show("Không đủ điều kiện để giải mã !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
            enabledOrDisableButtons(true);
        }
    }
}
