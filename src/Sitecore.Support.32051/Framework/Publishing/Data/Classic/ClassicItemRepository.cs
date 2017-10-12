using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.Framework.Publishing.Item;
using Sitecore.Framework.Publishing.Data.AdoNet;
using Sitecore.Framework.Publishing.Data.Classic;
using Sitecore.Framework.Publishing.Data;
using Microsoft.Extensions.Logging;

namespace Sitecore.Support.Framework.Publishing.Data.Classic
{
    [StoreFeature]
    public class ClassicItemRepository : Sitecore.Framework.Publishing.Data.Classic.ClassicItemRepository
    {
        public ClassicItemRepository(IClassicItemDataProvider<IDatabaseConnection> dataProvider, ISingleConnectionStore store, ILogger<Sitecore.Framework.Publishing.Data.Classic.ClassicItemRepository> logger) : base(dataProvider, store, logger)
        {
        }

        public ClassicItemRepository(IClassicItemDataProvider<IDatabaseConnection> dataProvider, IDatabaseConnection connection, ILogger<Sitecore.Framework.Publishing.Data.Classic.ClassicItemRepository> logger) : base(dataProvider, connection, logger)
        {
        }

        public override async Task<IEnumerable<IItemNode>> GetItemNodes(IReadOnlyCollection<Guid> ids, NodeQueryContext queryContext)
        {
            // ensure the job data is initialised in the db for performance
            if (queryContext != _currentQueryContext)
            {
                await _dataProvider.InitialiseDataQueryParams(Connection, queryContext.LanguageFilter, queryContext.FieldFilter).ConfigureAwait(false);
                //assign the value to _currentQueryContext
                _currentQueryContext = queryContext;
            }
            return await base.GetItemNodes(ids, queryContext);
        }
    }
}
