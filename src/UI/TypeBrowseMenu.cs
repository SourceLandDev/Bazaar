using Hosihikari.Minecraft;
using Hosihikari.Minecraft.Extension.UI.Data;
using Hosihikari.Minecraft.Extension.UI.Element;
using LiteDB;
using SourceLand.Bazaar;
using SourceLand.Bazaar.Utils;
using SourceLand.Bazaar.Type;

namespace SourceLand.Bazaar.UI;

internal sealed class TypeBrowseMenu<TData> : ActionFormData where TData : BaseData
{
    public TypeBrowseMenu()
    {
        Title = "ui.menu.item.title";
        Body = "ui.menu.item.body";
        Elements = [];
    }

    public override void Show(ServerPlayer player)
    {
        ILiteCollection<TData> collection = Main.Database.GetCollection<TData>();
        foreach (TData item in collection.Find(item => item.Owner != player.Xuid.ToString()))
        {
            string languageCode = string.Empty; // player.GetLanguageCode();
            Localizer localizer = Main.L10NProvider.GetLocalizer(languageCode);
            // TODO：获取物品数据
            Button button = new()
            {
                Text = localizer.Translate("ui.menu.item.text", item.Count,
                    item.Price) //, itemData.Name, itemData.Aux, item.Count, item.Price)
            };
            button.Clicked += playerCurr =>
            {
                ItemBrowseMenu menu = new(item.Id);
                menu.Show(playerCurr);
            };
            Elements!.Add(button);
        }

        base.Show(player);
    }
}