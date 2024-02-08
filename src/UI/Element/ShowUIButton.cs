using Hosihikari.Minecraft.Extension.UI;
using Hosihikari.Minecraft.Extension.UI.Element;

namespace SourceLand.Bazaar.UI.Element;

internal sealed class ShowUIButton<TForm> : Button where TForm : FormBase, new()
{
    public ShowUIButton()
    {
        Clicked += new TForm().Show;
    }
}