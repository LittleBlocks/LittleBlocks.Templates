using System.Collections.Generic;
using System.Threading.Tasks;
using LittleBlocks.RestEase.Client;
using LittleBlocks.Template.Common;
using RestEase;

namespace LittleBlocks.Template.Client
{
    public interface ISampleClient : IRestClient
    {
        [Get("api/samples")]
        Task<IEnumerable<SampleDto>> GetSampleListAsync();
    }
}