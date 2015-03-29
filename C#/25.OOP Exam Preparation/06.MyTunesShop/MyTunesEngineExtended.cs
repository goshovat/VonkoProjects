namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MyTunesEngineExtended : MyTunesEngine
    {
        #region InsertCommands
        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "performer":
                    this.ExecuteInsertPerformerCommand(commandWords);
                    break;
                case "media":
                    this.ExecuteInsertMediaCommand(commandWords);
                    break;
                case "song_to_album":
                    this.ExecuteInsertSongToAlbumCommand(commandWords);
                    break;
                case "member_to_band":
                    this.ExecuteInsertMemberToBand(commandWords);
                    break;
                default:
                    break;
            }
        }

        protected virtual void ExecuteInsertSongToAlbumCommand(string[] commandWords)
        {
            var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]) as IAlbum;
            if (album == null)
            {
                this.Printer.PrintLine("The album does not exist in the database.");
                return;
            }

            this.InsertSongToAlbum(song, album);
        }

        private void ExecuteInsertMemberToBand(string[] commandWords)
        {
            var band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[2]) as IBand;
            if (band == null)
            {
                this.Printer.PrintLine("The band does not exist in the database.");
                return;
            }

            string member = commandWords[3];

            this.InsertMemberToBand(member, band);
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "song":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    ISong song = new Song(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]),
                        commandWords[8]);

                    this.InsertSong(song, performer);
                    break;

                case "album":
                    performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    IAlbum album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]));

                    this.InsertAlbum(album, performer);
                    break;
            }
        }

        private void InsertSong(ISong song, IPerformer performer)
        {
            this.media.Add(song);
            this.mediaSupplies.Add(song, new SalesInfo());
            performer.Songs.Add(song);
            this.Printer.PrintLine("Song {0} by {1} added successfully", song.Title, performer.Name);
        }

        private void InsertAlbum(IAlbum album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            //performer.Songs.Add(song);
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        private void InsertSongToAlbum(ISong song, IAlbum album)
        {
            album.AddSong(song);
            this.Printer.PrintLine("The song {0} has been added to the album {1}.", song.Title, album.Title);
        }
        private void InsertMemberToBand(string member, IBand band)
        {
            band.AddMember(member);
            this.Printer.PrintLine("The member {0} has been added to the band {1}.", member, band.Name);
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "singer":
                    var singer = new Singer(commandWords[3]);
                    this.InsertPerformer(singer);
                    break;

                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region ReportCommands
        protected override void ExecuteRateCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]) as ISong;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    song.PlaceRating(int.Parse(commandWords[3]));
                    this.Printer.PrintLine("The rating has been placed successfully.");
                    break;

                default: //if needed can be estended to rate other things
                    break;
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetSongReport(song));
                    break;

                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;

                default:
                    break;
            }
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();

            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
                .AppendFormat("Rating: {0}", song.Ratings.Count == 0 ? 0 : Math.Floor((song.Ratings.Average(r => r)) + 0.5)).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);

            return songInfo.ToString();
        }

        protected virtual string GetAlbumReport(IAlbum album)
        {
            var albumSalesInfo = this.mediaSupplies[album];
            StringBuilder albumInfo = new StringBuilder();

            albumInfo.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold).AppendLine();

            if (album.Songs.Count == 0)
            {
                albumInfo.AppendLine("No songs");
            }
            else 
            {
                albumInfo.AppendLine("Songs:");
                foreach (ISong song in album.Songs)
                {
                    albumInfo.AppendFormat("{0} ({1})", song.Title, song.Duration).AppendLine();
                }
            }

            return albumInfo.ToString();
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "singer":
                    var singer = this.performers.FirstOrDefault(p => p is Singer && p.Name == commandWords[3]) as Singer;
                    if (singer == null)
                    {
                        this.Printer.PrintLine("The singer does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetSingerReport(singer));
                    break;

                case "band":
                    var band = this.performers.FirstOrDefault(p => p is Band && p.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;

                default:
                    break;
            }
        }

        protected virtual string GetBandReport(Band band)
        {
            StringBuilder bandInfo = new StringBuilder();
            bandInfo.Append(band.Name);
            bandInfo.Append(": ");

            if (band.Members.Any())
            {
                bandInfo.Append(string.Join(", ", band.Members));
            }
            bandInfo.AppendLine();

            if (band.Songs.Any())
            {
                var songs = band.Songs
                  .Select(s => s.Title)
                  .OrderBy(s => s);
                bandInfo.Append(string.Join("; ", songs));
                //bandInfo.Append(";");
            }
            else
            {
                bandInfo.Append("no songs");
            }

            return bandInfo.ToString();
        }

        #endregion

        #region OtherCommands
        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]);
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[song].Supply(quantity);
                    this.Printer.PrintLine("{0} items of song {1} successfully supplied.", quantity, song.Title);
                    break;

                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;

                default:
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]);
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[song].Sell(quantity);
                    this.Printer.PrintLine("{0} items of song {1} successfully sold.", quantity, song.Title);
                    break;

                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The salbum does not exist in the database.");
                        return;
                    }

                    quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
