﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Orleans.Runtime;

namespace Orleans.Providers.EntityFramework
{
    public abstract class GrainStorageOptions
    {
        internal string KeyPropertyName { get; set; }

        internal string KeyExtPropertyName { get; set; }

        internal string ETagPropertyName { get; set; }

        internal string PersistenceCheckPropertyName { get; set; }

        internal IProperty ETagProperty { get; set; }

        internal bool CheckForETag { get; set; }

        internal Func<object, string> ConvertETagObjectToStringFunc { get; set; }

        internal Type ETagType { get; set; }

        public bool ShouldUseETag { get; set; }

        internal bool IsConfigured { get; set; }

    }

    public class GrainStorageOptions<TContext, TGrain, TGrainState> : GrainStorageOptions
        where TContext : DbContext
    {
        internal Func<TContext, IQueryable<TGrainState>> ReadQuery { get; set; }

        internal Func<IAddressable, Expression<Func<TGrainState, bool>>> QueryExpressionGeneratorFunc { get; set; }

        internal Func<TGrainState, bool> IsPersistedFunc { get; set; }

        internal Func<TGrainState, string> GetETagFunc { get; set; }
    }
}