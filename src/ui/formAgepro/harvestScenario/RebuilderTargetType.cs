namespace Nmfs.Agepro.Gui
{
  /// <summary>
  /// A BindingList object to populate the "Rebulider Target Type" Combo Box. 
  /// </summary>
  class RebuilderTargetType : AgeproPropertyChanged
  {

    private string _RebuilderTargetTypename;

    public int Index { get; set; }
    public string RebuilderTargetTypeName
    {
      get => _RebuilderTargetTypename;
      set => SetProperty(ref _RebuilderTargetTypename, value);
    }

  }
}
