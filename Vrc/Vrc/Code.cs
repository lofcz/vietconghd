using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vrc
{
    public class Radhash
    {
        /// <summary>
        /// 3.cbf
        /// </summary>
        public long Disso { get; set; } = 103;
        /// <summary>
        /// 4.cbf
        /// </summary>
        public long Distra { get; set; } = 130060386;
        /// <summary>
        /// 3.cbf
        /// </summary>
        public long Enso { get; set; } = 10080368;
        /// <summary>
        /// 4.cbf
        /// </summary>
        public long Entra { get; set; } = 134767500;
        /// <summary>
        /// 4.cbf
        /// </summary>
        public long Ranked { get; set; } = 344468;
    }

    public class ActiveRadhash
    {
        public long Cbf3 { get; set; }
        public long Cbf4 { get; set; }
    }

    public class QualityItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public QualityItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
    }
}
