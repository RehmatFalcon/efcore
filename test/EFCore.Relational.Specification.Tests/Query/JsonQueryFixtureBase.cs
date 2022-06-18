﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.TestModels.JsonQuery;

namespace Microsoft.EntityFrameworkCore.Query;

public abstract class JsonQueryFixtureBase : SharedStoreFixtureBase<JsonQueryContext>, IQueryFixtureBase
{
    public Func<DbContext> GetContextCreator()
        => () => CreateContext();

    public virtual ISetSource GetExpectedData()
        => new JsonQueryData();

    public IReadOnlyDictionary<Type, object> GetEntitySorters()
        => new Dictionary<Type, Func<object, object>>
        {
            { typeof(JsonBasicEntity), e => ((JsonBasicEntity)e)?.Id },
        }.ToDictionary(e => e.Key, e => (object)e.Value);

    public IReadOnlyDictionary<Type, object> GetEntityAsserters()
        => new Dictionary<Type, Action<object, object>>
        {
            {
                typeof(JsonBasicEntity), (e, a) =>
                {
                    Assert.Equal(e == null, a == null);
                    if (a != null)
                    {
                        var ee = (JsonBasicEntity)e;
                        var aa = (JsonBasicEntity)a;

                        Assert.Equal(ee.Id, aa.Id);
                        Assert.Equal(ee.Name, aa.Name);

                        AssertOwnedRoot(ee.OwnedReferenceSharedRoot, aa.OwnedReferenceSharedRoot);

                        Assert.Equal(ee.OwnedCollectionSharedRoot.Count, aa.OwnedCollectionSharedRoot.Count);
                        for (var i = 0; i < ee.OwnedCollectionSharedRoot.Count; i++)
                        {
                            AssertOwnedRoot(ee.OwnedCollectionSharedRoot[i], aa.OwnedCollectionSharedRoot[i]);
                        }
                    }
                }
            },
            {
                typeof(MyOwnedRootShared), (e, a) =>
                {
                    if (a != null)
                    {
                        var ee = (MyOwnedRootShared)e;
                        var aa = (MyOwnedRootShared)a;

                        AssertOwnedRoot(ee, aa);
                    }
                }
            },
            {
                typeof(MyOwnedBranchShared), (e, a) =>
                {
                    if (a != null)
                    {
                        var ee = (MyOwnedBranchShared)e;
                        var aa = (MyOwnedBranchShared)a;

                        AssertOwnedBranch(ee, aa);
                    }
                }
            },
            {
                typeof(MyOwnedLeafShared), (e, a) =>
                {
                    if (a != null)
                    {
                        var ee = (MyOwnedLeafShared)e;
                        var aa = (MyOwnedLeafShared)a;

                        AssertOwnedLeaf(ee, aa);
                    }
                }
            },
        }.ToDictionary(e => e.Key, e => (object)e.Value);

    private static void AssertOwnedRoot(MyOwnedRootShared expected, MyOwnedRootShared actual)
    {
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Number, actual.Number);

        AssertOwnedBranch(expected.OwnedReferenceSharedBranch, actual.OwnedReferenceSharedBranch);
        Assert.Equal(expected.OwnedCollectionSharedBranch.Count, actual.OwnedCollectionSharedBranch.Count);
        for (var i = 0; i < expected.OwnedCollectionSharedBranch.Count; i++)
        {
            AssertOwnedBranch(expected.OwnedCollectionSharedBranch[i], actual.OwnedCollectionSharedBranch[i]);
        }
    }

    private static void AssertOwnedBranch(MyOwnedBranchShared expected, MyOwnedBranchShared actual)
    {
        Assert.Equal(expected.Date, actual.Date);
        Assert.Equal(expected.Fraction, actual.Fraction);

        AssertOwnedLeaf(expected.OwnedReferenceSharedLeaf, actual.OwnedReferenceSharedLeaf);
        Assert.Equal(expected.OwnedCollectionSharedLeaf.Count, actual.OwnedCollectionSharedLeaf.Count);
        for (var i = 0; i < expected.OwnedCollectionSharedLeaf.Count; i++)
        {
            AssertOwnedLeaf(expected.OwnedCollectionSharedLeaf[i], actual.OwnedCollectionSharedLeaf[i]);
        }
    }

    private static void AssertOwnedLeaf(MyOwnedLeafShared expected, MyOwnedLeafShared actual)
    {
        Assert.Equal(expected.SomethingSomething, actual.SomethingSomething);
    }

    protected override string StoreName { get; } = "JsonQueryTest";

    public new RelationalTestStore TestStore
        => (RelationalTestStore)base.TestStore;

    public TestSqlLoggerFactory TestSqlLoggerFactory
        => (TestSqlLoggerFactory)ListLoggerFactory;

    public override JsonQueryContext CreateContext()
    {
        var context = base.CreateContext();
        //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        return context;
    }

    protected override void Seed(JsonQueryContext context)
        => JsonQueryContext.Seed(context);

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        modelBuilder.Entity<JsonBasicEntity>().OwnsOne(x => x.OwnedReferenceSharedRoot, b =>
        {
            b.OwnsOne(x => x.OwnedReferenceSharedBranch, bb =>
            {
                bb.Property(x => x.Fraction).HasPrecision(18, 2);
                bb.OwnsOne(x => x.OwnedReferenceSharedLeaf);
                bb.OwnsMany(x => x.OwnedCollectionSharedLeaf);
            });

            b.OwnsMany(x => x.OwnedCollectionSharedBranch, bb =>
            {
                bb.Property(x => x.Fraction).HasPrecision(18, 2);
                bb.OwnsOne(x => x.OwnedReferenceSharedLeaf);
                bb.OwnsMany(x => x.OwnedCollectionSharedLeaf);
            });
        });

        //modelBuilder.Entity<MyEntity>().Navigation(x => x.OwnedReferenceSharedRoot).IsRequired();

        modelBuilder.Entity<JsonBasicEntity>().OwnsMany(x => x.OwnedCollectionSharedRoot, b =>
        {
            b.OwnsOne(x => x.OwnedReferenceSharedBranch, bb =>
            {
                bb.Property(x => x.Fraction).HasPrecision(18, 2);
                bb.OwnsOne(x => x.OwnedReferenceSharedLeaf);
                bb.OwnsMany(x => x.OwnedCollectionSharedLeaf);
            });

            b.OwnsMany(x => x.OwnedCollectionSharedBranch, bb =>
            {
                bb.Property(x => x.Fraction).HasPrecision(18, 2);
                bb.OwnsOne(x => x.OwnedReferenceSharedLeaf);
                bb.OwnsMany(x => x.OwnedCollectionSharedLeaf);
            });
        });

        modelBuilder.Entity<JsonBasicEntity>().MapReferenceToJson(x => x.OwnedReferenceSharedRoot, "json_reference_shared");
        modelBuilder.Entity<JsonBasicEntity>().MapCollectionToJson(x => x.OwnedCollectionSharedRoot, "json_collection_shared");
    }
}