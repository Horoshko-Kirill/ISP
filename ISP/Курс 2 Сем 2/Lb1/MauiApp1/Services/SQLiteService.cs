using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

public class SQLiteService : IDbService
{

    private SQLiteConnection _connection;
    private string _dbPath;

    public SQLiteService()
    {
        _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TransportDB.db");
        _connection = new SQLiteConnection(_dbPath);
    }

    public void Init()
    {
        _connection.CreateTable<Company>();
        _connection.CreateTable<Transport>();


        if (!_connection.Table<Company>().Any())
        {
            var companies = new List<Company>
            {
                new Company { Name = "Number1", StartDate = DateTime.Now, Region = 3},
                new Company { Name = "Number2", StartDate = DateTime.Now, Region = 4},
                
            };
            _connection.InsertAll(companies);

            var transports = new List<Transport>
            {
                new Transport {Name = "Tesla", Photo = "png1", CompanyId = 1},
                new Transport {Name = "Renault", Photo = "png2", CompanyId = 1},
                new Transport {Name = "Geele", Photo = "png3", CompanyId = 2},
                new Transport {Name = "Lada", Photo = "png4", CompanyId = 1},
                new Transport {Name = "Seat", Photo = "png5", CompanyId = 2},
                new Transport {Name = "Subaru", Photo = "png6", CompanyId = 1},
            };
            _connection.InsertAll(transports);
        }
    }


    public IEnumerable<Company> GetAllCompany()
    {
        return _connection.Table<Company>().ToList();
    }


    public IEnumerable<Transport> GetTransportsMembers(int companyId)
    {
        return _connection.Table<Transport>().Where(t => t.CompanyId == companyId).ToList();
    }


}
