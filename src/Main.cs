using Hosihikari.PluginManagement;
using LiteDB;
using SourceLand.Bazaar;
using SourceLand.Bazaar.Utils;
using SourceLand.Bazaar.Feature;
using System.Diagnostics.CodeAnalysis;

[assembly: EntryPoint<Main>]

namespace SourceLand.Bazaar;

public sealed class Main : IEntryPoint
{
    internal static LiteDatabase Database;
    internal static L10nProvider L10NProvider;

    [MemberNotNull(nameof(Database), nameof(L10NProvider))]
    public void Initialize(AssemblyPlugin plugin)
    {
        Database = new("");
        L10NProvider = new("");
        Command.Initialize();
        HandleTransactions.Initialize();
    }
}