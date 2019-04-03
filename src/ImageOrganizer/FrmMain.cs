using Business.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOrganizer
{
    public partial class FrmMain : Form
    {
        IConfigurationRepository _configurationRepository;
        public FrmMain(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var allData = _configurationRepository.GetAll();
                _configurationRepository.Add(new Business.DB.Dbo.Configuration() {
                    Id = Business.DB.Dbo.EConfigurationKey.rootPath,
                    Name = "rootPath"
                });

                _configurationRepository.SaveChanges();


            }
            catch(Exception ex)
            {
                var x = ex.ToString();
            }
        }
    }
}
