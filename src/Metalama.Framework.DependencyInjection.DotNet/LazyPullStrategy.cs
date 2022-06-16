﻿// Copyright (c) SharpCrafters s.r.o.All rights reserved.
// This project is not open source.Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using Metalama.Framework.DependencyInjection.Implementation;
using System;

namespace Metalama.Framework.DependencyInjection.DotNet;

internal class LazyPullStrategy : DefaultPullStrategy
{
    private readonly IField _funcField;
    private readonly INamedType _funcType;

    protected override IType ParameterType => this._funcType;

    public LazyPullStrategy( DependencyInjectionContext context, IProperty mainProperty, IField funcField ) : base( context, mainProperty )
    {
        this._funcField = funcField;
        this._funcType = ((INamedType) TypeFactory.GetType( typeof(Func<>) )).ConstructGenericInstance( mainProperty.Type ).ConstructNullable();
    }

    protected override IFieldOrProperty AssignedFieldOrProperty => this._funcField;
}