namespace WineSearchBar
{
    using System;
    using System.Collections.Generic;

    public interface IExampleGroupInfo
    {
        IControlInfo Control { get; }

        List<IExampleInfo> Examples { get; }

        string Name { get; }
    }
}

