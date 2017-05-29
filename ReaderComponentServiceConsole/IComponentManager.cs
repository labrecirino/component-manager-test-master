using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ReaderComponentService
{
    /// <summary>
    /// Comment about the exercise: Service interface should be called IComponentManager and declare a method IEnumerable<PersonalData> ReadData().
    /// </summary
    [ServiceContract]
    public interface IComponentManager
    {
        [OperationContract]
        IEnumerable<PersonalData> ReadData();

        [OperationContract(Name = "ReadDataAsync")]
        Task<IEnumerable<PersonalData>> ReadDataAsync();
    }
}
