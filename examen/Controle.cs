using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    public partial class Controle : Component
    {
        public Controle()
        {
            InitializeComponent();
        }

        public Controle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
