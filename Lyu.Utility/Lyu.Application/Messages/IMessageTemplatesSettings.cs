using Abp.Dependency;

namespace Lyu.Application.Messages
{
    public interface IMessageTemplatesSettings: ITransientDependency
    {
        /// <summary>
        /// Gets or sets a value indicating whether to replace message tokens according to case invariant rules
        /// </summary>
        bool CaseInvariantReplacement { get;  }

        /// <summary>
        /// Gets or sets a color1 in  hex format ("#hhhhhh") to use in workflow message formatting
        /// </summary>
        string Color1 { get;  }

        /// <summary>
        /// Gets or sets a color2 in  hex format ("#hhhhhh") to use in workflow message formatting
        /// </summary>
        string Color2 { get; }

        /// <summary>
        /// Gets or sets a color3 in  hex format ("#hhhhhh") to use in workflow message formatting
        /// </summary>
        string Color3 { get; }
    }
}