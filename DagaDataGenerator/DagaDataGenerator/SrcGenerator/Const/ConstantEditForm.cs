using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagaDataGenerator
{
    public partial class ConstantEditForm : Panel
    {
        public ConstantEditForm()
        {
            InitializeComponent();
        }

        public ConstantEditForm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
