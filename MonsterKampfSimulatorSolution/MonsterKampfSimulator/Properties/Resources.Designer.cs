﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonsterKampfSimulator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MonsterKampfSimulator.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure with this choice? [Y/n].
        /// </summary>
        internal static string confirmInput {
            get {
                return ResourceManager.GetString("confirmInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This battle lasted .
        /// </summary>
        internal static string lastedBattle {
            get {
                return ResourceManager.GetString("lastedBattle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to lost against.
        /// </summary>
        internal static string lostFight {
            get {
                return ResourceManager.GetString("lostFight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To simulate a combat, choose a Monster.
        /// </summary>
        internal static string selectMonster {
            get {
                return ResourceManager.GetString("selectMonster", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press enter to start.
        /// </summary>
        internal static string startGameMessage {
            get {
                return ResourceManager.GetString("startGameMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Let&apos;s start the fight.
        /// </summary>
        internal static string startSimulation {
            get {
                return ResourceManager.GetString("startSimulation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to won against.
        /// </summary>
        internal static string winFight {
            get {
                return ResourceManager.GetString("winFight", resourceCulture);
            }
        }
    }
}