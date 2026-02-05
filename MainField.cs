using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence
{
    internal class MainField
    {
        public string name;
        public SubFieldTree subFieldTree;
        public MainField(string name, SubFieldTree subFieldTree)
        {
            this.name = name;
            this.subFieldTree = subFieldTree;
        }
    }
    class SubField
    {
        public string name;
        public string definition;
        public string applications;
        public SubField(string name, string definition, string applications)
        {
            this.name = name;
            this.definition = definition;
            this.applications = applications;
        }
    }
}
