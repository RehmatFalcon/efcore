﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.TestModels.JsonQuery;

public class JsonQueryData : ISetSource
{
    public JsonQueryData()
    {
        JsonBasicEntities = CreateJsonBasicEntities();
    }

    public IReadOnlyList<JsonBasicEntity> JsonBasicEntities { get; }

    public static IReadOnlyList<JsonBasicEntity> CreateJsonBasicEntities()
    {
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_r_r_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_r_r_shared" };
        var e1_r_r_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_r_c1_shared" };
        var e1_r_r_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_r_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_r_r_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2100, 1, 1),
            Fraction = 10.0M,
            OwnedReferenceSharedLeaf = e1_r_r_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_r_r_c1_shared, e1_r_r_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_r_c1_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_c1_r_shared" };
        var e1_r_c1_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_c1_c1_shared" };
        var e1_r_c1_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_c1_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_r_c1_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2101, 1, 1),
            Fraction = 10.1M,
            OwnedReferenceSharedLeaf = e1_r_c1_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_r_c1_c1_shared, e1_r_c1_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_r_c2_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_c2_r_shared" };
        var e1_r_c2_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_c2_c1_shared" };
        var e1_r_c2_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_r_c2_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_r_c2_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2102, 1, 1),
            Fraction = 10.2M,
            OwnedReferenceSharedLeaf = e1_r_c2_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_r_c2_c1_shared, e1_r_c2_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        var e1_r_shared = new MyOwnedRootShared
        {
            Name = "e1_r_shared",
            Number = 10,
            OwnedReferenceSharedBranch = e1_r_r_shared,
            OwnedCollectionSharedBranch = new List<MyOwnedBranchShared> { e1_r_c1_shared, e1_r_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        var e1_c1_r_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_r_r_shared" };
        var e1_c1_r_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_r_c1_shared" };
        var e1_c1_r_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_r_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_c1_r_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2110, 1, 1),
            Fraction = 11.0M,
            OwnedReferenceSharedLeaf = e1_c1_r_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_c1_r_c1_shared, e1_c1_r_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_c1_c1_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_c1_r_shared" };
        var e1_c1_c1_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_c1_c1_shared" };
        var e1_c1_c1_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_c1_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_c1_c1_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2111, 1, 1),
            Fraction = 11.1M,
            OwnedReferenceSharedLeaf = e1_c1_c1_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_c1_c1_c1_shared, e1_c1_c1_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_c1_c2_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_c2_r_shared" };
        var e1_c1_c2_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_c2_c1_shared" };
        var e1_c1_c2_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c1_c2_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_c1_c2_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2112, 1, 1),
            Fraction = 11.2M,
            OwnedReferenceSharedLeaf = e1_c1_c2_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_c1_c2_c1_shared, e1_c1_c2_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        var e1_c1_shared = new MyOwnedRootShared
        {
            Name = "e1_c1_shared",
            Number = 11,
            OwnedReferenceSharedBranch = e1_c1_r_shared,
            OwnedCollectionSharedBranch = new List<MyOwnedBranchShared> { e1_c1_c1_shared, e1_c1_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        var e1_c2_r_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_r_r_shared" };
        var e1_c2_r_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_r_c1_shared" };
        var e1_c2_r_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_r_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_c2_r_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2120, 1, 1),
            Fraction = 12.0M,
            OwnedReferenceSharedLeaf = e1_c2_r_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_c2_r_c1_shared, e1_c2_r_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_c2_c1_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_c1_r_shared" };
        var e1_c2_c1_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_c1_c1_shared" };
        var e1_c2_c1_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_c1_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_c2_c1_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2121, 1, 1),
            Fraction = 12.1M,
            OwnedReferenceSharedLeaf = e1_c2_c1_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_c2_c1_c1_shared, e1_c2_c1_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var e1_c2_c2_r_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_c2_r_shared" };
        var e1_c2_c2_c1_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_c2_c1_shared" };
        var e1_c2_c2_c2_shared = new MyOwnedLeafShared { SomethingSomething = "e1_c2_c2_c2_shared" };

        //-------------------------------------------------------------------------------------------

        var e1_c2_c2_shared = new MyOwnedBranchShared
        {
            Date = new DateTime(2122, 1, 1),
            Fraction = 12.2M,
            OwnedReferenceSharedLeaf = e1_c2_c2_r_shared,
            OwnedCollectionSharedLeaf = new List<MyOwnedLeafShared> { e1_c2_c2_c1_shared, e1_c2_c2_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        var e1_c2_shared = new MyOwnedRootShared
        {
            Name = "e1_c2_shared",
            Number = 12,
            OwnedReferenceSharedBranch = e1_c2_r_shared,
            OwnedCollectionSharedBranch = new List<MyOwnedBranchShared> { e1_c2_c1_shared, e1_c2_c2_shared }
        };

        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------

        var entity1 = new JsonBasicEntity
        {
            Id = 1,
            Name = "JsonBasicEntity1",
            OwnedReferenceSharedRoot = e1_r_shared,
            OwnedCollectionSharedRoot = new List<MyOwnedRootShared> { e1_c1_shared, e1_c2_shared }
        };

        return new List<JsonBasicEntity> { entity1 };
    }

    public IQueryable<TEntity> Set<TEntity>()
        where TEntity : class
    {
        if (typeof(TEntity) == typeof(JsonBasicEntity))
        {
            return (IQueryable<TEntity>)JsonBasicEntities.AsQueryable();
        }

        throw new InvalidOperationException("Invalid entity type: " + typeof(TEntity));
    }
}