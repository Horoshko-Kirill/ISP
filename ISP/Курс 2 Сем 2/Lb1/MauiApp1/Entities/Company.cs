using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

[SQLite.Table("Company")]
public class Company
{

    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }

    public int Region { get; set; }

}
