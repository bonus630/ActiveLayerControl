using System.Windows.Controls;

namespace br.corp.bonus630.ActiveLayerControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LayerControl : UserControl
    {
        
        public LayerControl(VGCore.Application app)
        {
            InitializeComponent();
            LayerControlController layerControlController = new LayerControlController(app);
            layerControlController.LayerChange += (e) => {  lba_layer.Content = e.LayerName; };
        }

       
    }
}
