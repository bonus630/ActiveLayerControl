
namespace br.corp.bonus630.ActiveLayerControl
{
    public class LayerChangeEventArgs
    {
        public string LayerName { get; set; }
        public LayerChangeEventArgs(string layerName)
        {
            LayerName = layerName;
        }
    }
}
