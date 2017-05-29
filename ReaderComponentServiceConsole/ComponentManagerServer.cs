using ReaderComponentService.Factories;
using ReaderComponentService.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ReaderComponentService.Factories.ReaderHandlerFactory;

namespace ReaderComponentService
{
    /// <summary>
    /// Comment about the exercise: Develop a class to request and handle the data for both using sockets.
    /// </summary
    class ComponentManagerServer : IComponentManager
    {
        public IEnumerable<PersonalData> ReadData()
        {
            ReaderType type;

            // Comment about the exercise: Add a key to app.config to define which component to use.
            if (Enum.TryParse(ConfigurationUtil.GetSetting("DefaultReader"), out type))
            {
                // Comment about the exercise: Use Factory pattern to instantiate the component handler.
                return ReaderHandlerFactory.CreateReader(type).ReadData();
            }

            return null;
        }

        // Comment about the exercise: Use async/await if possible
        public async Task<IEnumerable<PersonalData>> ReadDataAsync()
        {
            return await Task.Run<IEnumerable<PersonalData>>(() => ReadData());
        }


    }
}
