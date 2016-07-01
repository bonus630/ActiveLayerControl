using VGCore;
namespace br.corp.bonus630.ActiveLayerControl
{
    public class LayerControlController
    {
        Application app;
        public event LayerChangeEventHandler LayerChange;

        public delegate void LayerChangeEventHandler(LayerChangeEventArgs e);


        public LayerControlController(Application app)
        {
            this.app = app;
            if (this.app.ActiveDocument != null)
            {
                if (this.app.ActiveDocument.ActiveLayer != null)
                    eventDispatcher(this.app.ActiveDocument.ActiveLayer.Name);
            }
            this.app.DocumentOpen += app_DocumentOpen;
            this.app.DocumentNew += app_DocumentNew;
            this.app.DocumentClose+=app_DocumentClose;
            this.app.WindowActivate += app_WindowActivate;
        }
        private void eventDispatcher(string layerName)
        {
            if (LayerChange != null )
                LayerChange(new LayerChangeEventArgs(layerName));
        }

        void app_WindowActivate(Document Doc, Window Window)
        {
            if(Doc != null)
            {
                if (Doc.ActiveLayer != null)
                    eventDispatcher(Doc.ActiveLayer.Name);
            }
        }

        void app_DocumentClose(Document Doc)
        {
            global::System.Windows.MessageBox.Show(this.app.ActiveDocument.ActiveLayer.Name);
           eventDispatcher(this.app.ActiveDocument.ActiveLayer.Name);
        }

        void app_DocumentNew(Document Doc, bool FromTemplate, string Template, bool IncludeGraphics)
        {
            
            Doc.LayerActivate += Doc_LayerActivate;
            Doc.LayerChange += Doc_LayerChange;
            Doc.LayerCreate += Doc_LayerCreate;
            eventDispatcher(Doc.ActiveLayer.Name);
        }

        void Doc_LayerCreate(Layer Layer)
        {
            eventDispatcher(Layer.Name);
        }

        void Doc_LayerChange(Layer Layer)
        {
           eventDispatcher(Layer.Name);
        }

        void Doc_LayerActivate(Layer Layer)
        {
            
            eventDispatcher(Layer.Name);
        }

        void app_DocumentOpen(Document Doc, string FileName)
        {
           
            Doc.LayerActivate+=Doc_LayerActivate;
            Doc.LayerChange += Doc_LayerChange;
            Doc.LayerCreate += Doc_LayerCreate;
            eventDispatcher(Doc.ActiveLayer.Name);

        }
       

    }
}
