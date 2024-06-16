using Discovered.Models;
using Discovered.Repository;
using Discovered.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Discovered.Bases
{
    public class FeaturesBase : ComponentBase
    {
        
        [Parameter]
        public EventCallback OnClickRandom { get; set; }
        [Parameter]
        public BibleData BibleScripture { get; set; }

        [Parameter]
        public EventCallback<VerseDTO> OnClickSripture { get; set; }
      
        [Parameter]
        public string verse { get; set; }


        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async void OnClickWebHandler()
        {
            VerseDTO verseDTO = new(verse, "web");
            await OnClickSripture.InvokeAsync(verseDTO);
        }
        protected async void OnClickBbeHandler()
        {
            VerseDTO verseDTO = new(verse, "bbe");
            await OnClickSripture.InvokeAsync(verseDTO);
        }
        protected async void OnClickKjvHandler()
        {
            VerseDTO verseDTO = new(verse, "kjv");
            await OnClickSripture.InvokeAsync(verseDTO);
        }
    }
}
