namespace MyFirstBlazor.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class DismissableAlert
    {
        private bool _show;

        [Parameter]
        public bool Show
        {
            get { return _show; }

            set
            {
                if (_show != value)
                {
                    _show = value;
                    ShowChanged.InvokeAsync(_show);
                }
            }
        }

        [Parameter]
        public EventCallback<bool> ShowChanged { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void Dismiss()
        {
            Show = false;
        }
    }
}