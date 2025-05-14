using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IRateService
{
    public Task<IEnumerable<Rate>> GetRatesAsync(DateTime date);
}

