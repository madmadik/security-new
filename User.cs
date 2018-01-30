using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp8
{
    public class User
    {
        public String Id { get; set; }
        public String FullName { get; set; }
        public String Position { get; set; }
        public bool Check { get; set; }
        public override string ToString()
        {
            return String.Format("Id={0},FullName={1},Position={2},Check={3}", Id, FullName, Position,Check);
        }
    }
}
