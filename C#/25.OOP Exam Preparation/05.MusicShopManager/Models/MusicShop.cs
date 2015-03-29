using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal class MusicShop : IMusicShop
    {
        private string name;
        private List<IArticle> articles;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The parameter Name is required.");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get { return new List<IArticle>(this.articles); }
        }

        internal MusicShop(string name)
        {
            this.Name = name;
            this.articles = new List<IArticle>();
        }

        public void AddArticle(IArticle article)
        {
            if (this.articles.Contains(article))
                throw new InvalidOperationException("The operation cannot be performed");

            this.articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            if (!this.articles.Contains(article))
                throw new InvalidOperationException("The operation cannot be performed");

            this.articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("===== {0} =====", this.Name));

            if (this.articles.Count == 0)
            {
                result.AppendLine("The shop is empty. Come back soon.");
                return result.ToString();
            }
            else
            {
                List<IMicrophone> microphones = new List<IMicrophone>();
                foreach (IArticle article in this.articles)
                {
                    Microphone artAsMic = article as Microphone;

                    if (artAsMic != null)
                        microphones.Add(artAsMic);
                }

                List<IDrums> drums = new List<IDrums>();
                foreach (IArticle article in this.articles)
                {
                    Drums artAsDrum = article as Drums;

                    if (artAsDrum != null)
                        drums.Add(artAsDrum);
                }

                List<IElectricGuitar> electricGuitars = new List<IElectricGuitar>();
                foreach (IArticle article in this.articles)
                {
                    ElectricGuitar artAsElGuit = article as ElectricGuitar;

                    if (artAsElGuit != null)
                        electricGuitars.Add(artAsElGuit);
                }

                List<IAcousticGuitar> acousticGuitars = new List<IAcousticGuitar>();
                foreach (IArticle article in this.articles)
                {
                    AcousticGuitar artAsAcGuit = article as AcousticGuitar;

                    if (artAsAcGuit != null)
                        acousticGuitars.Add(artAsAcGuit);
                }

                List<IBassGuitar> bassGuitars = new List<IBassGuitar>();
                foreach (IArticle article in this.articles)
                {
                    BassGuitar artAsBass = article as BassGuitar;

                    if (artAsBass != null)
                        bassGuitars.Add(artAsBass);
                }

                if (microphones != null && microphones.Count != 0)
                {
                    result.AppendLine("----- Microphones -----");
                    var orderedMicrophones = microphones.OrderBy(m => m.Make + " " + m.Model);

                    foreach (Microphone mic in orderedMicrophones)
                        result.AppendLine(mic.ToString().Trim());
                }
                if (drums != null && drums.Count != 0)
                {
                    result.AppendLine("----- Drums -----");
                    var orderedDrums = drums.OrderBy(d => d.Make + " " + d.Model);

                    foreach (Drums drum in orderedDrums)
                        result.AppendLine(drum.ToString().Trim());
                }
                if (electricGuitars != null && electricGuitars.Count != 0)
                {
                    result.AppendLine("----- Electric guitars -----");
                    var orderedElGuitars = electricGuitars.OrderBy(eg => eg.Make + " " + eg.Model);

                    foreach (ElectricGuitar eg in orderedElGuitars)
                        result.AppendLine(eg.ToString().Trim());
                }
                if (acousticGuitars != null && acousticGuitars.Count != 0)
                {
                    result.AppendLine("----- Acoustic guitars -----");
                    var orderedAcGuitars = acousticGuitars.OrderBy(ag => ag.Make + " " + ag.Model);

                    foreach (AcousticGuitar ag in orderedAcGuitars)
                        result.AppendLine(ag.ToString().Trim());
                }
                if (bassGuitars != null && bassGuitars.Count != 0)
                {
                    result.AppendLine("----- Bass guitars -----");
                    var orderedBassGuitars = bassGuitars.OrderBy(bg => bg.Make + " " + bg.Model);

                    foreach (BassGuitar bg in orderedBassGuitars)
                        result.AppendLine(bg.ToString().Trim());
                }

                return result.ToString();
            }
        }
    }
}
