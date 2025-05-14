using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDbService
{

    IEnumerable<Company> GetAllCompany();
    IEnumerable<Transport> GetTransportsMembers(int id);

    void Init();

}
