using Sitecore.Framework.Publishing.Data.AdoNet;
using Sitecore.Framework.Publishing.Data.Repository;
using Sitecore.Framework.Publishing.Item;
using System;

namespace Sitecore.Support.Framework.Publishing.Data.Classic
{
  public class DatabaseItemReadRepositoryBuilder : DefaultRepositoryBuilder<IIndexableItemReadRepository, Sitecore.Support.Framework.Publishing.Data.Classic.ClassicItemRepository, IDatabaseConnection>
  {
    public DatabaseItemReadRepositoryBuilder(IServiceProvider services) : base(services)
    {

    }
  }
}