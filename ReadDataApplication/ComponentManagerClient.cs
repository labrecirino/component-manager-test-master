using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ReadDataApplication.Proxies
{
    /// <summary>
    /// Comments about the exercise: The proxy class to the WCF service is provided. Don't forget to match Data Contract namespaces.
    /// </summary>
    public class ComponentManagerClient : ClientBase<IComponentManager>, IComponentManager
    {
        public IEnumerable<PersonalData> ReadData()
        {
            return Channel.ReadData();
        }

        public async Task<IEnumerable<PersonalData>> ReadDataAsync()
        {
            return await Task.Run<IEnumerable<PersonalData>>(() => ReadData());
        }
    }

    [ServiceContract]
    public interface IComponentManager
    {
        [OperationContract]
        IEnumerable<PersonalData> ReadData();

        [OperationContract(Name = "ReadDataAsync")]
        Task<IEnumerable<PersonalData>> ReadDataAsync();
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/ReaderComponentService")]
    public class PersonalData
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
