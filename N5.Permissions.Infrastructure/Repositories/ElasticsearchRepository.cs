using N5.Permissions.Domain.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Infrastructure.Repositories
{

    public class ElasticsearchRepository: IElasticsearchRepository
    {
        private readonly IElasticClient _elasticClient;
        public ElasticsearchRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexDocumentAsync(Permission permission) 
        {
            await _elasticClient.IndexDocumentAsync(permission);
        }
    }
}
