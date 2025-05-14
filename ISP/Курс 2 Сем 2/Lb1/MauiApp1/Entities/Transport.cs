using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


[SQLite.Table("Transport")]
public class Transport
{

    [PrimaryKey, AutoIncrement, Indexed]
    public int TransportId { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }

    public int CompanyId { get; set; }

}
