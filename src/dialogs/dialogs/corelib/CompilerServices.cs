// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/f21a2666c577306e437f80fe934d76cdb15072a5/src/libraries/Common/src/Interop/Windows/Shell32/Interop.SHGetKnownFolderPath.cs

#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable CS9113 // Parameter is unread.

namespace System.Runtime.CompilerServices;

/// <summary>   Attribute for required member. </summary>
/// <remarks>   2025-10-10. </remarks>
[AttributeUsage( AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true )]
internal class RequiredMemberAttribute : Attribute { }

/// <summary>   Attribute for compiler feature required. </summary>
/// <remarks>   2025-10-10. </remarks>
/// <param name="name"> The name. </param>
[AttributeUsage( AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true )]
internal class CompilerFeatureRequiredAttribute( string name ) : Attribute { }
