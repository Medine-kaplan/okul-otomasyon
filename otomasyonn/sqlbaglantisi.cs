using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace otomasyonn
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source = DESKTOP-1PHU0I3; Initial Catalog =dbo.OkulOtomasyon; Integrated Security = True");
            baglan.Open();
            return baglan;

        }

    }
}
