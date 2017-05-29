using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderComponentService.Handlers
{
    /// <summary>
    /// Comment about the exercise: Use Factory pattern to instantiate the component handler.
    /// </summary
    class GenericReader : Reader
    {
        public override IEnumerable<PersonalData> ReadData()
        {
            var stream = ReadStream("READDATA");
            var list = stream.Substring(16).Split('|')
                        .Select(s => s.Split('/'))
                        .Select(a => new PersonalData { FirstName = a[0], LastName = a[1], Country = a[2], Age = Convert.ToInt32(a[3]) }).AsEnumerable<PersonalData>();


            return list;
        }

        // Comment about the exercise: Use async/await if possible
        public override async Task<IEnumerable<PersonalData>> ReadDataAsync()
        {
            return await Task.Run<IEnumerable<PersonalData>>(() => ReadData());
        }


    }
}
