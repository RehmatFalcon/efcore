// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
///     Provides a simple API for configuring a <see cref="IMutableStoredProcedure" /> that an entity type is mapped to.
/// </summary>
public class NamingStoredProcedureBuilder : StoredProcedureBuilder
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    [EntityFrameworkInternal]
    public NamingStoredProcedureBuilder(IMutableStoredProcedure sproc, EntityTypeBuilder entityTypeBuilder)
        : base(sproc, entityTypeBuilder)
    {
    }

    /// <summary>
    ///     Sets the name of the database function.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see> for more information and examples.
    /// </remarks>
    /// <param name="name">The name of the function in the database.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public virtual NamingStoredProcedureBuilder HasName(string name)
    {
        Check.NullButNotEmpty(name, nameof(name));

        Builder.HasName(name, ConfigurationSource.Explicit);

        return this;
    }

    /// <summary>
    ///     Sets the schema of the database function.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see> for more information and examples.
    /// </remarks>
    /// <param name="schema">The schema of the function in the database.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public virtual NamingStoredProcedureBuilder HasSchema(string? schema)
    {
        Builder.HasSchema(schema, ConfigurationSource.Explicit);

        return this;
    }

    /// <summary>
    ///     Resets the currently configured parameter order.
    /// </summary>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public virtual NamingStoredProcedureBuilder WithNewParameterOrder()
        => this;

    /// <summary>
    ///     Configures a new parameter if no parameter mapped to the given property exists.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public new virtual NamingStoredProcedureBuilder HasParameter(string propertyName)
        => (NamingStoredProcedureBuilder)base.HasParameter(propertyName);

    /// <summary>
    ///     Configures a new parameter if no parameter mapped to the given property exists.
    /// </summary>
    /// <param name="propertyName">The parameter name.</param>
    /// <param name="buildAction">An action that performs configuration of the parameter.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public new virtual NamingStoredProcedureBuilder HasParameter(
        string propertyName, Action<StoredProcedureParameterBuilder> buildAction)
        => (NamingStoredProcedureBuilder)base.HasParameter(propertyName, buildAction);
}
