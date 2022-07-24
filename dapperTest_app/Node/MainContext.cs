using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeEditor;
using System.Windows;
using System.Windows.Forms;

namespace dapperTest_app.Node
{
    public partial class MainContext : INodesContext
    {
        public NodeVisual CurrentProcessingNode { get; set; }
        public event Action<string, NodeVisual, FeedbackType, object, bool> FeedbackInfo;

        [Node("Value", "Input", "Basic", "Allows to output a simple value.", false, true, typeof(TextBox), "", Width = 500, Height = 500)]
        public void InputValue(float inValue, out float outValue)
        {
            outValue = inValue;
        }

        [Node("aaaa", "Input", "Basic", "Allows to output a simple value.", false, false, typeof(Button), "")]
        public void bbbb(float inValue, out float outValue)
        {
            outValue = inValue;
        }
    }
}
