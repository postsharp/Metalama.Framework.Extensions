﻿// Copyright (c) SharpCrafters s.r.o.All rights reserved.
// This project is not open source.Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.DependencyInjection.Implementation;

namespace Metalama.Framework.DependencyInjection.ServiceLocator;

[CompileTime]
public class ServiceLocatorDependencyInjectionFramework : DefaultDependencyInjectionFramework
{
    protected override DefaultDependencyInjectionStrategy GetStrategy( DependencyContext context )
        => context.DependencyAttribute.GetIsLazy().GetValueOrDefault( context.Project.DependencyInjectionOptions().IsLazyByDefault )
            ? new LazyServiceLocatorDependencyInjectionStrategy( context )
            : new EarlyServiceLocatorDependencyInjectionStrategy( context );
}