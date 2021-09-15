using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class FormStudents : Form
    {
        public FormStudents()
        {
            InitializeComponent();
        }

        private async void FormStudents_Load(object sender, EventArgs e)
        {
            string response = await GetHttp();
            List<Domain.Models.StudentsModel> lst = JsonConvert.DeserializeObject<List<Domain.Models.StudentsModel>>(response);
            dataGridView1.DataSource = lst;
        }
        private async Task<string> GetHttp()
        {
            WebRequest request = WebRequest.Create("https://localhost:44380/api/students");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            return await stream.ReadToEndAsync();
        }
    }
}
