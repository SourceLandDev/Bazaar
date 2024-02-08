using Hosihikari.Minecraft;
using Hosihikari.Minecraft.Extension.UI.Data;
using LiteDB;
using SourceLand.Bazaar;
using SourceLand.Bazaar.Utils;
using SourceLand.Bazaar.Type;
using SourceLand.Bazaar.UI.Element;

namespace SourceLand.Bazaar.UI;

internal sealed class MainMenu : MessageFormData
{
    public MainMenu()
    {
        Title = "ui.menu.main.title";
        Body = "ui.menu.main.body";
        Elements =
        [
            new ShowUIButton<TypeBrowseMenu<SellingItem>>
            {
                Text = "ui.menu.main.button.item"
            },
            new ShowUIButton<TypeBrowseMenu<OfferData>>
            {
                Text = "ui.menu.main.button.offer"
            }
        ];
    }

    public override void Show(ServerPlayer player)
    {
        string languageCode = string.Empty; // player.GetLanguageCode();
        Localizer localizer = Main.L10NProvider.GetLocalizer(languageCode);
        Title = localizer[Title!];
        Body = localizer[Body!];
        ILiteCollection<SellingItem> collectionItem = Main.Database.GetCollection<SellingItem>();
        ILiteCollection<OfferData> collectionOffer = Main.Database.GetCollection<OfferData>();
        Elements![0].Text = localizer.Translate(Elements![0].Text!,
            collectionItem.Find(item => item.Owner == player.Xuid.ToString()).Count(), collectionItem.Count());
        Elements![1].Text = localizer.Translate(Elements![1].Text!,
            collectionOffer.Find(offer => offer.Owner == player.Xuid.ToString()).Count(), collectionOffer.Count());
        base.Show(player);
    }
}