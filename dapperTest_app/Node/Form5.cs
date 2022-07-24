using dapperTest_app.Node;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dapperTest_app
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        //Context that will be used for our nodes
        MainContext context = new MainContext();

        private void Form5_Load(object sender, EventArgs e)
        {
            nodesControl1.Context = context;
            context.CurrentProcessingNode
        }
    }
}
