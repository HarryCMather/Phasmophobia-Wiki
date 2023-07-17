using System.ComponentModel;

namespace Phasmophobia_Wiki.Models;

/// <summary>
/// Evidence a ghost will provide that assists in determining its type.
/// Flag enum used to allow different combinations to be specified, without requiring a list.
/// </summary>
[Flags]
public enum Activity
{
    [Description("D.O.T.S Projector")]
    Dots = 1 << 0, // 1
    
    [Description("EMF Level 5")]
    Emf = 1 << 1, // 2
    
    [Description("Fingerprints")]
    Fingerprints = 1 << 2, // 4
    
    [Description("Freezing Temperatures")]
    FreezingTemperatures = 1 << 3, // 8
    
    [Description("Ghost Orbs")]
    GhostOrbs = 1 << 4, // 16
    
    [Description("Ghost Writing")]
    GhostWriting = 1 << 5, // 32
    
    [Description("Spirit Box")]
    SpiritBox = 1 << 6 // 64
}
