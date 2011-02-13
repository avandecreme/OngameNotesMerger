using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IrfParserNs;

namespace OngameNotesMerger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseMaster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
                if (ofd.ShowDialog(this) == DialogResult.OK)
                    tbMasterFile.Text = ofd.FileName;
        }

        private void btnBrowseSlave_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
                if (ofd.ShowDialog(this) == DialogResult.OK)
                    tbSlaveFile.Text = ofd.FileName;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbSlaveFile.Text))
            {
                MessageBox.Show(this, "Specify a valid slave file", "Slave file not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IrfObject irfMaster;
            try { irfMaster = IrfObject.LoadFromFile(tbMasterFile.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Cannot read master file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IrfObject irfSlave;
            try { irfSlave = IrfObject.LoadFromFile(tbSlaveFile.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Cannot read slave file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try { irfMaster.UsersData.First().Merge(irfSlave.UsersData.First()); }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Cannot merge datas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                    irfMaster.WriteToFile(sfd.FileName);
            }
        }
    }
}
