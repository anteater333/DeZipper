using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeZipper
{
    public partial class DeZipperProgressForm : Form
    {
        private bool imFine;

        public int ProgressMax
        {
            get
            {
                return this.deleteProgress.Maximum;
            }
            set
            {
                this.deleteProgress.Maximum = value;
            }
        }
        
        public DeZipperProgressForm()
        {
            InitializeComponent();
            imFine = true;
        }
        
        public bool ProgressPerform(string log)
        {
            this.logBox.AppendText(log + Environment.NewLine);
            this.deleteProgress.Value += 1;

            return imFine;
        }

        public void FinishDelete(int count)
        {
            this.okButton.Enabled = true;

            this.logBox.AppendText("총 " + count + "개 파일을 삭제했습니다.");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
