using Hosihikari.Minecraft.Extension.Events;

namespace SourceLand.Bazaar.Feature;

internal static class HandleTransactions
{
    public static void Initialize()
    {
        Events.PlayerJoin.Before += (sender, e) =>
        {
            throw new NotImplementedException();
        };
    }
}