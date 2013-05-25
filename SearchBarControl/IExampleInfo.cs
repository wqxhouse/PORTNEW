namespace WineSearchBar
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public interface IExampleInfo : IStatusInfo, IPlatformInfo
    {
        List<string> CommonFolders { get; }

        string Description { get; set; }

        IExampleGroupInfo ExampleGroup { get; }

        bool IsDefault { get; }

        string Keywords { get; }

        string Name { get; }

        string PackageName { get; }

        ObservableCollection<IExampleFile> Resources { get; }

        string Text { get; }

        Enums.ExampleType Type { get; }
    }
}

