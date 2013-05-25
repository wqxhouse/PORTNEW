namespace WineSearchBar
{
    using System;
    using System.Collections.Generic;

    public interface IControlInfo : IStatusInfo, IPlatformInfo
    {
        List<IExampleGroupInfo> ExampleGroups { get; }

        List<IExampleInfo> Examples { get; }

        string Name { get; }
    }
}

