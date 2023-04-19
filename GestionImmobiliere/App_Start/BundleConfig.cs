using System.Data;
using System.Data.Entity.Infrastructure;
using System.Web;
using System.Web.Optimization;

namespace GestionImmobiliere
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
          

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js",
                       // Ajout des liens pour ajouter des filtres de recherches et de tris
                       "~/Scripts/DataTables/jquery-3.6.3.js",
                       "~/Scripts/DataTables/jquery.dataTables.min.js",
                       "~/Scripts/DataTables/dataTables.bootstrap.js",
                       "~/Scripts/JavaScript.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  // "~/Content/bootstrapessai.css",
                 "~/Content/bootstrap.css",
                   // Ajout des liens pour ajouter des filtres de recherches et de tris
                "~/Content/DataTables/css/jquery.dataTables.min.css",
                "~/Content/font-awesome.min.css", 
                  "~/Content/site.css"
                  
                   ));
        }
    }
}
