using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GestionImmobiliere.DataContext;
using GestionImmobiliere.Models;
using MathNet.Numerics.IntegralTransforms;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace GestionImmobiliere.Controllers
{

    public class OwnersController : Controller
        //Cette ligne de code représente la déclaration d'une classe publique nommée "OwnersController" 
        //qui étend (ou hérite de) la classe "Controller". Cette classe est probablement utilisée pour implémenter la logique de 
        //contrôle pour une application web.

        //En utilisant l'héritage de la classe "Controller", la classe "OwnersController" est capable d'utiliser toutes
        //les propriétés et méthodes définies dans la classe "Controller". Cette classe peut donc fournir des fonctionnalités communes à toutes les classes 
        //de contrôleurs dans une application web, telles que la gestion des demandes HTTP, l'accès à la session, etc.

        //En outre, le mot clé "public" signifie que la classe peut être utilisée et accédée à partir de n'importe quelle autre classe dans le projet ou l'assemblage.
         
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /**
         "ApplicationDbContext" est un nom de classe souvent utilisé dans les applications ASP.NET Core pour représenter un contexte de 
        base de données. Cette classe est généralement utilisée pour accéder à une base de données relationnelle à partir d'une 
        application ASP.NET Core, et elle est créée en héritant de la classe "DbContext" fournie par le framework Entity Framework Core.

        Plus précisément, la classe "ApplicationDbContext" est généralement utilisée pour configurer les relations entre les modèles d'entités 
        (classes qui représentent des tables dans la base de données) et les tables dans la base de données elle-même. Elle contient également 
        des propriétés DbSet qui permettent de définir des ensembles d'entités associées à des tables spécifiques dans la base de données.

        En utilisant la classe "ApplicationDbContext", les développeurs peuvent facilement interagir avec la base de données à partir de 
        leur application ASP.NET Core en utilisant des requêtes LINQ ou des méthodes d'extension fournies par Entity Framework Core.
         */



        // GET: Owners
        public ActionResult Index()
        /**
         "public ActionResult Index()" est une signature de méthode courante dans les applications ASP.NET MVC. Cette méthode est 
        généralement utilisée comme action par défaut pour une vue spécifique. Elle est définie comme étant publique 
        (accessible à partir d'autres classes), renvoie un objet "ActionResult" et s'appelle "Index".
        Plus précisément, cette méthode est appelée lorsque l'utilisateur navigue vers une certaine URL de l'application web, 
        qui est associée à cette action "Index". Lorsque la méthode est appelée, elle peut effectuer des opérations comme
        récupérer des données à partir d'une source de données, puis les formater pour une utilisation dans une vue, 
        ou renvoyer directement une vue sans traitement de données préalable.
        Le type de retour "ActionResult" peut représenter différentes actions à effectuer, telles que la redirection vers 
        une autre page, le renvoi d'une vue (une page web) ou d'un contenu brut (par exemple, une chaîne de caractères ou un 
        fichier). La vue renvoyée par cette méthode doit être nommée "Index.cshtml" par défaut, sauf si un autre nom de vue est spécifié explicitement.
        */
        {
            return View(db.Owners.ToList());
            /**
            La ligne de code "return View(db.Owners.ToList());" renvoie une vue (une page web) contenant les données de la 
            liste des propriétaires stockées dans une base de données.
            Plus précisément, cette ligne de code utilise l'objet "db" (qui doit être une instance de la classe DbContext)
            pour accéder à la liste des propriétaires stockés dans la base de données, puis appelle la méthode "ToList()" 
            pour convertir ces données en une liste d'objets.
            Ensuite, la méthode "View()" est appelée avec cette liste d'objets en tant que paramètre. Cette méthode renvoie 
            une vue nommée d'après la méthode qui l'appelle (dans ce cas, probablement "Index.cshtml") et transmet la liste 
            des propriétaires en tant que modèle à cette vue. Cela signifie que la vue peut utiliser cette liste pour afficher 
            les données à l'utilisateur.
            En fin de compte, cette ligne de code renvoie une page web qui affiche la liste des propriétaires stockés dans la 
            base de données.
             */
        }

        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        /**
         "public ActionResult Details(int? id)" est une signature de méthode courante dans les applications ASP.NET MVC. 
        Cette méthode est généralement utilisée pour afficher les détails d'un enregistrement spécifique dans une base de données.
        Plus précisément, cette méthode est appelée lorsque l'utilisateur navigue vers une URL qui correspond à 
        l'action "Details" d'un contrôleur spécifique. L'URL peut inclure un paramètre "id" qui spécifie l'identifiant 
        unique de l'enregistrement dont les détails sont à afficher.
        Le paramètre "int? id" indique que la méthode prend un paramètre "id" de type entier (int), mais ce paramètre peut
        également être null (d'où le signe "?"). Cela permet de gérer les cas où aucun identifiant n'est fourni dans l'URL.

        La méthode "Details" peut ensuite utiliser l'objet "db" (qui doit être une instance de la classe DbContext) pour 
        accéder à l'enregistrement spécifique dans la base de données correspondant à l'identifiant fourni. 
        La méthode peut ensuite renvoyer une vue contenant les détails de cet enregistrement, généralement en utilisant 
        le même modèle de vue que celui utilisé pour l'action "Index" (mais avec des données différentes).

        En fin de compte, cette ligne de code définit une méthode qui peut être appelée pour afficher les détails d'un 
        enregistrement spécifique dans une base de données à partir d'une URL correspondant à l'action "Details" d'un contrôleur.
         */
        {
            if (id == null)
            // L'instruction "if (id == null)" vérifie si une variable "id" est null (c'est-à-dire qu'elle ne contient
            // pas de valeur).
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                /**
                "return new HttpStatusCodeResult(HttpStatusCode.BadRequest);" est une instruction de code qui renvoie 
                une réponse HTTP avec un code d'état "BadRequest" (mauvaise requête) au client qui a effectué la requête HTTP.
                Le code d'état "BadRequest" est utilisé pour indiquer au client que la requête qu'il a envoyée n'est pas 
                correcte et ne peut pas être traitée par le serveur. Cela peut se produire si les paramètres de la
                requête sont manquants, incorrects ou hors de portée, ou si le client essaie d'accéder à une ressource 
                à laquelle il n'a pas accès.
                Dans le contexte d'une méthode d'un contrôleur dans une application ASP.NET MVC, cette instruction est
                souvent utilisée pour renvoyer une réponse HTTP au client lorsque la requête ne peut pas être traitée. 
                Par exemple, si un utilisateur essaie d'accéder aux détails d'un enregistrement qui n'existe pas ou qui 
                est inaccessible, 
                le contrôleur peut renvoyer un code d'état "BadRequest" pour signaler que la requête ne peut pas être traitée.
                En fin de compte, cette instruction permet au contrôleur de renvoyer une réponse HTTP appropriée au client
                en cas d'erreur, ce qui peut aider à améliorer la convivialité et la sécurité de l'application.*/
            }
            Owner ownerClass = db.Owners.Find(id);
            /**
             * La ligne de code "Owner ownerClass = db.Owners.Find(id);" est utilisée dans les applications ASP.NET pour récupérer un enregistrement spécifique de la base de données. Dans ce cas, la méthode "Find" est utilisée pour rechercher un objet Owner avec l'identifiant spécifié (stocké dans la variable "id").
             Plus précisément, la variable "db" doit être une instance d'une classe DbContext qui représente une connexion à une base de données. La propriété "Owners" est un DbSet qui représente la table "Owners" dans la base de données.
             La méthode "Find" de DbSet est utilisée pour rechercher un enregistrement spécifique dans la table, en utilisant la valeur de la clé primaire de l'enregistrement (dans ce cas, l'identifiant stocké dans la variable "id").
             La méthode "Find" retourne l'objet Owner correspondant à l'identifiant spécifié ou null s'il n'y a pas d'enregistrement correspondant. Cette méthode est souvent utilisée dans les actions "Details" et "Edit" des contrôleurs ASP.NET MVC pour récupérer les détails ou les propriétés d'un enregistrement spécifique à partir de la base de données.
             En fin de compte, cette ligne de code permet de récupérer un enregistrement spécifique de la base de données en utilisant son identifiant, ce qui peut être utilisé pour afficher les détails de l'enregistrement ou pour effectuer des opérations de mise à jour sur cet enregistrement.
             */
            if (ownerClass == null)
            {
                return HttpNotFound();
                /**
                "return HttpNotFound();" est une instruction de code utilisée dans les applications ASP.NET pour renvoyer une réponse HTTP avec un code d'état "404 Not Found" au client qui a effectué la requête HTTP.
                Le code d'état "404 Not Found" est utilisé pour indiquer que la ressource demandée n'a pas été trouvée sur le serveur. Cela peut se produire si l'URL demandée n'existe pas ou si la ressource a été supprimée ou déplacée.
                Dans le contexte d'une méthode d'un contrôleur dans une application ASP.NET MVC, cette instruction est souvent utilisée pour renvoyer une réponse HTTP au client lorsque la ressource demandée n'a pas été trouvée dans la base de données ou n'est pas accessible pour une raison quelconque.
                Par exemple, si un utilisateur essaie d'accéder aux détails d'un enregistrement qui n'existe pas ou qui est inaccessible, le contrôleur peut renvoyer un code d'état "404 Not Found" pour signaler que la ressource demandée n'a pas été trouvée.
                En fin de compte, cette instruction permet au contrôleur de renvoyer une réponse HTTP appropriée au client en cas d'erreur, ce qui peut aider à améliorer la convivialité et la sécurité de l'application.
                 */
            }
            return View(ownerClass);
            /**
            "return View(ownerClass);" est une instruction de code utilisée dans les applications ASP.NET pour renvoyer une vue qui affiche les données d'un objet Owner à l'utilisateur.
            Dans ce cas, la variable "ownerClass" est une instance de la classe Owner qui représente un enregistrement de la table "Owners" dans la base de données. Cette variable contient les données de l'enregistrement, telles que l'ID, le nom, l'adresse et le numéro de téléphone de l'Owner.
            La méthode "View" est utilisée pour créer une vue qui affiche les données de l'objet Owner. Cette vue peut être une page HTML, un formulaire web ou tout autre type de contenu web que vous souhaitez afficher à l'utilisateur.
            En fin de compte, cette instruction permet de renvoyer une vue qui affiche les détails de l'objet Owner à l'utilisateur, ce qui peut être utile pour afficher les propriétés de l'objet dans une page web et permettre à l'utilisateur de les modifier si nécessaire.
            */
        }

        // GET: Owners/Create
        /**
        "public ActionResult Create()" est une méthode d'action dans un contrôleur ASP.NET qui est appelée lorsqu'un utilisateur demande une page pour créer un nouvel enregistrement.
        Dans ce cas, la méthode "Create" retourne une vue qui permet à l'utilisateur de saisir les informations pour un nouvel enregistrement.
        La méthode "View" est utilisée pour créer une vue qui affiche un formulaire vide que l'utilisateur peut remplir avec les informations nécessaires pour créer un nouvel enregistrement. Cette vue peut contenir des champs de saisie de texte, des cases à cocher, des boutons radio ou tout autre élément d'interface utilisateur qui permet à l'utilisateur de saisir les informations nécessaires.
        En fin de compte, cette méthode permet de renvoyer une vue qui affiche un formulaire vide que l'utilisateur peut remplir pour créer un nouvel enregistrement dans la base de données.
         */
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerClasses/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /**
         * "[HttpPost]" et "[ValidateAntiForgeryToken]" sont des attributs utilisés dans les applications ASP.NET pour sécuriser les actions de formulaire.
        "HttpPost" est un attribut qui spécifie que la méthode d'action doit être appelée lorsqu'un formulaire est soumis avec la méthode HTTP POST plutôt qu'avec la méthode HTTP GET. La méthode HTTP POST est généralement utilisée pour soumettre des données de formulaire sensibles, telles que les noms d'utilisateur et les mots de passe.
        "ValidateAntiForgeryToken" est un attribut qui empêche les attaques CSRF (Cross-Site Request Forgery). Il ajoute un jeton de sécurité à chaque formulaire soumis, ce qui permet à l'application de vérifier que la demande provient bien du formulaire créé par l'application et non d'un site tiers malveillant.
        Ensemble, ces attributs permettent de s'assurer que les données soumises par l'utilisateur proviennent bien du formulaire créé par l'application, ce qui permet de prévenir les attaques CSRF et de garantir que les données soumises sont fiables.
        En fin de compte, ces attributs sont utilisés pour améliorer la sécurité des applications ASP.NET en s'assurant que les données soumises par l'utilisateur sont fiables et proviennent bien du formulaire créé par l'application.
         */
        public ActionResult Create([Bind(Include = "Id_owner,Name_owner,First_name_owner,E_mail_owner,Phone_owner")] Owner ownerClass)
        /**
         * est une méthode d'action ASP.NET qui permet de créer un nouvel enregistrement dans la base de données.
        Dans ce cas, la méthode "Create" prend un paramètre "ownerClass" qui représente les données soumises par 
        l'utilisateur lorsqu'il soumet le formulaire de création. Le paramètre est annoté avec 
        l'attribut "[Bind(Include = "Id_owner,Name_owner,First_name_owner,E_mail_owner,Phone_owner")]", 
        qui spécifie les propriétés de l'objet Owner qui peuvent être liées lors de la soumission du formulaire. 
        Cette annotation est utilisée pour empêcher la survenue d'erreurs de sur-liage ("overbinding") qui peuvent 
        être exploitées par des attaquants pour injecter des données malveillantes dans les formulaires.
        En fin de compte, cette méthode permet de créer un nouvel objet Owner avec les données soumises par 
        l'utilisateur et de l'ajouter à la base de données.
         */
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(ownerClass);
                /**
                "db.Owners.Add(ownerClass);" est une méthode qui ajoute un nouvel objet Owner à la base de données.
                Dans ce cas, "ownerClass" est l'objet Owner créé à partir des données soumises par l'utilisateur dans 
                le formulaire de création. Cette méthode ajoute cet objet à la collection "Owners" du contexte de base 
                de données "db". La méthode "Add" ajoute l'objet à la collection en vue de sa sauvegarde dans la base de 
                données.
                En fin de compte, cette méthode permet d'ajouter un nouvel enregistrement à la base de données, 
                qui contient les informations fournies par l'utilisateur lorsqu'il a soumis le formulaire de création.
                 */
                db.SaveChanges();
                /**
                "db.SaveChanges();" est une méthode qui enregistre les modifications apportées à la base de données.
                Dans ce cas, cette méthode est utilisée après l'ajout de l'objet Owner à la base de données avec la 
                méthode "db.Owners.Add(ownerClass);". La méthode "SaveChanges()" est appelée pour enregistrer les
                modifications apportées à la base de données, c'est-à-dire pour ajouter le nouvel enregistrement.
                En fin de compte, cette méthode permet de sauvegarder les modifications apportées à la base de données, 
                y compris l'ajout du nouvel enregistrement créé avec la méthode "db.Owners.Add(ownerClass);".
                 */
                return RedirectToAction("Index");
                /**
                 * La méthode RedirectToActionretourne une redirection vers une autre méthode d'action dans le même 
                 * contrôleur ou dans un autre contrôleur. Dans le cas de return RedirectToAction("Index");, cela redirige 
                 * vers la méthode d'action "Index" dans le même contrôleur.

                Cela signifie que, lorsqu'un utilisateur effectue une action qui nécessite une redirection, comme la 
                suppression d'un enregistrement dans la méthode d'action "Delete", le contrôleur peut rediriger l'utilisateur 
                vers une autre vue ou méthode d'action pour afficher des informations mises à jour ou d'autres informations 
                pertinentes.

                Dans ce cas, la redirection vers la méthode d'action "Index" signifie que l'utilisateur sera redirigé vers 
                la liste de tous les enregistrés "Propriétaire" après que l'enregistrement spécifié a été supprimé. 
                Cela permet à l'utilisateur de voir les modifications dégradées à la liste d'enregistrements Propriétaire 
                après la suppression.
                 */
            }

            return View(ownerClass);
            /**
             * La méthode Viewdans ASP.NET MVC est utilisée pour renvoyer une vue à l'utilisateur. Dans le cas de return 
             * View(ownerClass);, cela signifie que la vue ownerClasssera retournée à l'utilisateur.

            Plus précisément, la vue ownerClassaffichera les détails de l'objet ownerClassqui a été récupéré dans la méthode d'action. 
            Les détails seront affichés dans la vue correspondante, qui est généralement un fichier .cshtml dans le 
            dossier Views du projet ASP.NET MVC.

            Ainsi, lorsque cette méthode d'action est appelée, elle renvoie une vue qui affiche les détails de l'objet ownerClassdans
            l'interface utilisateur de l'application.
             */
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner ownerClass = db.Owners.Find(id);
            if (ownerClass == null)
            {
                return HttpNotFound();
            }
            return View(ownerClass);
        }

        // POST: Owners/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_owner,Name_owner,First_name_owner,E_mail_owner,Phone_owner")] Owner ownerClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownerClass).State = EntityState.Modified;
                /**
                 * db.Entry(ownerClass).State = EntityState.Modified est une instruction qui indique au contexte 
                 * de base de données d'Entity Framework que l'objet ownerClass a été modifié.

                Lorsque l'utilisateur soumet le formulaire d'édition pour l'enregistrement et que les
                modifications sont enregistrées, le contexte de base de données doit être informé des modifications
                apportées à l'objet. C'est là que la ligne de code db.Entry(ownerClass).State = EntityState.Modified entre en jeu.

                L'objet ownerClass est passé à la méthode Entry pour créer une entrée correspondante dans le 
                contexte de base de données. La propriété State de cette entrée est alors modifiée en EntityState.
                Modified, ce qui indique au contexte de base de données que l'objet a été modifié et qu'il doit 
                être mis à jour dans la base de données.

                En résumé, cette ligne de code permet de mettre à jour l'état de l'objet ownerClass dans le 
                contexte de base de données d'Entity Framework, afin de pouvoir enregistrer les modifications 
                apportées à l'enregistrement dans la base de données.
                 */
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ownerClass);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner ownerClass = db.Owners.Find(id);
            if (ownerClass == null)
            {
                return HttpNotFound();
            }
            return View(ownerClass);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner ownerClass = db.Owners.Find(id);
            db.Owners.Remove(ownerClass);
            /**
            db.Owners.Remove(ownerClass) est une instruction qui indique au contexte de base de données d'Entity Framework de supprimer un enregistrement de la table Owners.

Plus précisément, cette instruction est utilisée dans une méthode d'action de contrôleur pour supprimer un enregistrement de la base de données. L'objet ownerClass qui doit être supprimé est passé en tant que paramètre à la méthode.

La ligne de code db.Owners.Remove(ownerClass) indique au contexte de base de données de supprimer l'enregistrement correspondant de la table Owners. Cette suppression ne sera effective dans la base de données que lorsque la méthode SaveChanges() sera appelée sur le contexte de base de données.

En résumé, cette ligne de code permet de supprimer un enregistrement de la table Owners dans la base de données, en utilisant le contexte de base de données d'Entity Framework.
             */
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /**
         * En résumé, la méthode Dispose(bool disposing) est utilisée pour libérer les ressources non managées que le contrôleur utilise, en particulier le contexte de base de données d'Entity Framework.
         */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
