using Discovered.Models;
using Discovered.Repository;
using Discovered.ViewModels;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Globalization;

namespace Discovered.Bases
{
    public class HomeBase : ComponentBase
    {
        [Inject]
        public IDiscovered Discovered { get; set; }
        [Inject]
        public IBibleApi BibleApi { get; set; }
        public DiscoveredResults Discovery { get; set; }
        public BibleData VerseScripture { get; set; }

        public string ErrorMessage { get; set; }
        public string Header { get; set; } = "";
        public string _verse { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Header = "Discovery for today";
                Discovery = await Discovered.GetTodayDiscovery();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                _verse = Discovery is not null ? GetVerse() : "";
            }

        }
       
        public async Task GetRandomDiscovery()
        {
            try
            {
                Header = "Random discovery";
                Discovery = await Discovered.GetRandomDiscovery();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                _verse = Discovery is not null ? GetVerse() : "";
            }
        }
        protected async Task GetScriptures(VerseDTO verseDTO)
        {
            try
            {
                VerseScripture = await BibleApi.GetScriptures(verseDTO.verse,verseDTO.version);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected string GetVerse()
        {
            return Discovery.Results.FirstOrDefault().Context;
        }
    }
}
